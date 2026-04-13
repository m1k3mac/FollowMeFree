using System.Text;
using FollowMeFree.API.Data;
using FollowMeFree.API.Middleware;
using FollowMeFree.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// For Debug: Listen on all network interfaces so other devices on the LAN can connect.
//builder.WebHost.UseUrls("http://0.0.0.0:5224", "https://0.0.0.0:7178");

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFlutterApp", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<FmfDataContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()));

builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var jwtKey = builder.Configuration["Jwt:Key"]!;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = "FollowMeFree",
        ValidateAudience = true,
        ValidAudience = "FollowMeFreeApp",
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
        ValidateLifetime = false // tokens do not expire
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<PipeClient>();
builder.Services.AddSingleton<ILoggerProvider, DbLoggerProvider>();
builder.Services.AddSingleton<IpWhitelistOptions>();

var app = builder.Build();

// Load allowed network from database Config table.
// Retry logic handles the case where SQL Server has a delayed start (e.g. after a reboot)
// and is not yet available when IIS starts the application.
const int maxRetries = 20;
const int delaySeconds = 6;

for (int attempt = 1; attempt <= maxRetries; attempt++)
{
    try
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<FmfDataContext>();
        var config = db.Configs.OrderBy(o => o.Id).FirstOrDefault();

        if (string.IsNullOrWhiteSpace(config?.JobFilePath))
        {
            app.Logger.LogInformation("JobFilePath has not been configured! Use the FollowMeFree Commander to configure it.");
        }

        //if (!string.IsNullOrWhiteSpace(config?.ApiallowedNetwork))
        //{
        //    var options = app.Services.GetRequiredService<IpWhitelistOptions>();
        //    options.SetNetwork(config.ApiallowedNetwork);
        //    app.Logger.LogInformation("IP whitelist configured: {Network}", config.ApiallowedNetwork);
        //}
        //else
        //{
        //    app.Logger.LogWarning("No APIAllowedNetwork configured – all IPs are allowed");
        //}

        break; // Success — exit the retry loop
    }
    catch (Exception ex) when (attempt < maxRetries)
    {
        app.Logger.LogWarning(
            "Database not available on startup (attempt {Attempt}/{MaxRetries}). Retrying in {Delay}s... Error: {Message}",
            attempt, maxRetries, delaySeconds, ex.Message);
        Thread.Sleep(TimeSpan.FromSeconds(delaySeconds));
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex,
            "Database not available after {MaxRetries} attempts. The application will continue but startup configuration could not be loaded.",
            maxRetries);
    }
}

// Restrict access to the configured allowed network
app.UseMiddleware<IpWhitelistMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFlutterApp");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
