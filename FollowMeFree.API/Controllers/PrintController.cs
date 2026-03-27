using FollowMeFree.API.Data;
using FollowMeFree.API.Services;
using FollowMeFree_Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FollowMeFree.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PrintController : ControllerBase
    {
        private readonly FmfDataContext _db;
        private readonly PipeClient _pipeClient;
        private readonly ILogger<PrintController> _logger;

        public PrintController(PipeClient pipeClient, ILogger<PrintController> logger, FmfDataContext db)
        {
            _pipeClient = pipeClient;
            _logger = logger;
            _db = db;
        }

        /// <summary>
        /// Sends one or more PRN files to printers by name via the WorkerService.
        /// </summary>
        /// <param name="requests">A list of print job requests, each containing the target printer name and file path.</param>
        [HttpPost("Print")]
        public async Task<IActionResult> ExecutePrintJob([FromBody] List<PrintJobRequest> requests)
        {
            if (requests == null || requests.Count == 0)
                return BadRequest("At least one print job request is required");

            foreach (var request in requests)
            {
                if (string.IsNullOrEmpty(request.PrinterName))
                    return BadRequest("PrinterName is required for all print jobs");

                if (string.IsNullOrEmpty(request.FileName))
                    return BadRequest("FilePath is required for all print jobs");
            }

            _logger.LogInformation("PrintController: executing {Count} print job(s)", requests.Count);

            var ipcRequest = new IpcRequest
            {
                Command = "PrintJobs",
                PrintJobs = requests.Select(r => new PrintJobItem
                {
                    TargetPrinterName = r.PrinterName,
                    FilePath = r.FileName,
                    Datatype = r.Datatype
                }).ToList()
            };

            var response = await _pipeClient.SendRequestAsync(ipcRequest);

            if (response.Success)
                return Ok(response);

            return StatusCode(500, response);
        }

        /// <summary>
        /// GetPrinters - Returns all configured printers ordered by printer name.
        /// </summary>
        [HttpGet("GetPrinters")]
        public async Task<ActionResult<IEnumerable<Printer>>> GetPrinters()
        {
            var printers = await _db.Printers.OrderBy(p => p.Printer1).ToListAsync();
            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            var printerIds = user.AllowedPrinterIds?.Split(',').Select(id => int.Parse(id)).ToList();
            var allowedPrinters = printerIds == null
                ? new List<Printer>()
                : printers.Where(p => printerIds.Contains(p.Id)).ToList();

            return Ok(allowedPrinters);
        }
    }

    public class PrintJobRequest
    {
        public string PrinterName { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string Datatype { get; set; }
    }
}
