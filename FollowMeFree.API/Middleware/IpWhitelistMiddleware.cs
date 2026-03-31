using System.Net;

namespace FollowMeFree.API.Middleware;

public class IpWhitelistMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<IpWhitelistMiddleware> _logger;
    private readonly IpWhitelistOptions _options;

    public IpWhitelistMiddleware(RequestDelegate next, ILogger<IpWhitelistMiddleware> logger, IpWhitelistOptions options)
    {
        _next = next;
        _logger = logger;
        _options = options;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (_options.AllowedNetwork is null)
        {
            // No network restriction configured – allow all
            await _next(context);
            return;
        }

        var remoteIp = context.Connection.RemoteIpAddress;

        if (remoteIp is null || !IsAllowed(remoteIp))
        {
            _logger.LogWarning("Blocked request from {RemoteIp}", remoteIp);
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("Forbidden");
            return;
        }

        await _next(context);
    }

    private bool IsAllowed(IPAddress ip)
    {
        // Allow loopback (localhost) so local development/testing still works
        if (IPAddress.IsLoopback(ip))
            return true;

        // Handle IPv4-mapped IPv6 addresses (e.g. ::ffff:10.1.1.5)
        if (ip.IsIPv4MappedToIPv6)
            ip = ip.MapToIPv4();

        return _options.AllowedNetwork.Value.Contains(ip);
    }
}
