using FollowMeFree.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FollowMeFree.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrintJobFilesController : ControllerBase
    {
        private readonly PrintJobFileSettings _settings;
        private readonly ILogger<PrintJobFilesController> _logger;

        public PrintJobFilesController(PrintJobFileSettings settings, ILogger<PrintJobFilesController> logger)
        {
            _settings = settings;
            _logger = logger;
        }

        /// <summary>
        /// Returns a list of print job files from the job file directory, filtered by submitter.
        /// </summary>
        /// <param name="submitter">The username of the job submitter to filter by.</param>
        [HttpGet]
        public async Task<IActionResult> GetPrintJobFiles([FromQuery] string submitter)
        {
            if (string.IsNullOrWhiteSpace(submitter))
                return BadRequest("Submitter is required.");

            if (string.IsNullOrEmpty(_settings.JobFilePath))
            {
                _logger.LogError("JobFilePath is not configured in App.config.");
                return StatusCode(500, "JobFilePath is not configured.");
            }

            if (!Directory.Exists(_settings.JobFilePath))
            {
                _logger.LogWarning("Job file directory does not exist: {Path}", _settings.JobFilePath);
                return Ok(Array.Empty<PrintJobFileDto>());
            }

            var files = await Task.Run(() => Directory.GetFiles(_settings.JobFilePath, "*.prn"));
            var results = new List<PrintJobFileDto>();

            foreach (var filePath in files)
            {
                var dto = ParseFileName(filePath);
                if (dto != null && dto.Submitter.Equals(submitter, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(dto);
                }
            }

            _logger.LogInformation("Found {Count} job file(s) for submitter '{Submitter}'", results.Count, submitter);
            return Ok(results);
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
}
