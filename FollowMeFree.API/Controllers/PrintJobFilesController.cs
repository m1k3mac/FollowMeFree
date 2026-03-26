using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FollowMeFree.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FollowMeFree.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PrintJobFilesController : ControllerBase
    {
        private readonly FmfDataContext _db;
        private readonly ILogger<PrintJobFilesController> _logger;

        public PrintJobFilesController(FmfDataContext db, ILogger<PrintJobFilesController> logger)
        {
            _db = db;
            _logger = logger;
        }

        /// <summary>
        /// Returns a list of print job files from the job file directory, filtered by submitter.
        /// </summary>
        /// <param name="submitter">The username of the job submitter to filter by.</param>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrintJobFileDto>>> GetPrintJobFiles([FromQuery] string submitter)
        {
            if (string.IsNullOrWhiteSpace(submitter))
                return BadRequest("Submitter is required.");

            var config = await _db.Configs.OrderBy(c => c.Id).FirstOrDefaultAsync();
            var jobFilePath = config?.JobFilePath;

            if (string.IsNullOrEmpty(jobFilePath))
            {
                _logger.LogError("JobFilePath is not configured in the database.");
                return StatusCode(500, "JobFilePath is not configured.");
            }

            if (!Directory.Exists(jobFilePath))
            {
                _logger.LogWarning("Job file directory does not exist: {Path}", jobFilePath);
                return Ok(Array.Empty<PrintJobFileDto>());
            }

            var files = await Task.Run(() => Directory.GetFiles(jobFilePath, "*.prn"));
            var results = new List<PrintJobFileDto>();

            foreach (var filePath in files)
            {
                var dto = ParseFileName(filePath);
                if (dto != null && dto.Submitter.ToLower().Equals(submitter.ToLower(), StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(dto);
                }
            }

            _logger.LogInformation("Found {Count} job file(s) for submitter '{Submitter}'", results.Count, submitter);
            return Ok(results);
        }

        /// <summary>
        /// Deletes print job files whose document name matches one of the provided names.
        /// Logs each deletion to the Log table with the authenticated user's identity.
        /// </summary>
        /// <param name="request">A list of document names to delete.</param>
        [HttpDelete]
        public async Task<ActionResult<DeletePrintJobFilesResponse>> DeletePrintJobFiles([FromBody] DeletePrintJobFilesRequest request)
        {
            if (request.DocumentNames == null || request.DocumentNames.Count == 0)
                return BadRequest("At least one document name is required.");

            var userName = User.FindFirstValue(ClaimTypes.Name)
                        ?? User.FindFirstValue(JwtRegisteredClaimNames.UniqueName)
                        ?? "Unknown";

            var config = await _db.Configs.OrderBy(c => c.Id).FirstOrDefaultAsync();
            var jobFilePath = config?.JobFilePath;

            if (string.IsNullOrEmpty(jobFilePath))
            {
                _logger.LogError("JobFilePath is not configured in the database.");
                return StatusCode(500, "JobFilePath is not configured.");
            }

            if (!Directory.Exists(jobFilePath))
            {
                _logger.LogWarning("Job file directory does not exist: {Path}", jobFilePath);
                return NotFound("Job file directory does not exist.");
            }

            var files = await Task.Run(() => Directory.GetFiles(jobFilePath, "*.prn"));

            var requestedNames = new HashSet<string>(
                request.DocumentNames, StringComparer.OrdinalIgnoreCase);

            var deleted = new List<string>();
            var notFound = new List<string>(request.DocumentNames);

            foreach (var filePath in files)
            {
                var dto = ParseFileName(filePath);
                if (dto == null || !requestedNames.Contains(dto.JobName))
                    continue;

                try
                {
                    await Task.Run(() => System.IO.File.Delete(filePath));
                    deleted.Add(dto.JobName);
                    notFound.Remove(dto.JobName);

                    _db.Logs.Add(new Log
                    {
                        Timestamp = DateTime.Now,
                        LogLevel = "Information",
                        Source = "API",
                        Category = "PrintJobDeletion",
                        Message = $"Print job '{dto.JobName}' (JobId: {dto.JobId}, Submitter: {dto.Submitter}) was deleted by user '{userName}'."
                    });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to delete print job file: {FilePath}", filePath);
                }
            }

            if (_db.ChangeTracker.HasChanges())
                await _db.SaveChangesAsync();

            _logger.LogInformation(
                "User '{User}' deleted {Count} print job file(s): {Names}",
                userName, deleted.Count, string.Join(", ", deleted));

            return Ok(new DeletePrintJobFilesResponse
            {
                Deleted = deleted,
                NotFound = notFound
            });
        }

        /// <summary>
        /// Parses a PRN filename in the format: submitter;docname;pages;timestamp;jobId;datatype.prn
        /// </summary>
        private static PrintJobFileDto? ParseFileName(string filePath)
        {
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            var parts = fileName.Split(';');

            if (parts.Length < 6)
                return null;

            if (!int.TryParse(parts[4], out int jobId))
                return null;

            if (!int.TryParse(parts[2], out int numberOfPages))
                numberOfPages = 0;

            DateTime timeSubmitted = default;
            if (DateTime.TryParseExact(parts[3], "yyyyMMdd_HHmmss", null, System.Globalization.DateTimeStyles.None, out var parsed))
                timeSubmitted = parsed;

            return new PrintJobFileDto
            {
                JobId = jobId,
                JobName = parts[1],
                Submitter = parts[0],
                TimeSubmitted = timeSubmitted,
                NumberOfPages = numberOfPages,
                Datatype = parts[5],
                OutputFilePath = filePath
            };
        }
    }

    public class PrintJobFileDto
    {
        public int JobId { get; set; }
        public string JobName { get; set; } = string.Empty;
        public string Submitter { get; set; } = string.Empty;
        public DateTime TimeSubmitted { get; set; }
        public int NumberOfPages { get; set; }
        public string Datatype { get; set; } = string.Empty;
        public string OutputFilePath { get; set; } = string.Empty;
    }

    public class DeletePrintJobFilesRequest
    {
        public List<string> DocumentNames { get; set; } = new();
    }

    public class DeletePrintJobFilesResponse
    {
        public List<string> Deleted { get; set; } = new();
        public List<string> NotFound { get; set; } = new();
    }
}
