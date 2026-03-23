using FollowMeFree.API.Services;
using FollowMeFree_Shared;
using Microsoft.AspNetCore.Mvc;

namespace FollowMeFree.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrintController : ControllerBase
    {
        private readonly PipeClient _pipeClient;
        private readonly ILogger<PrintController> _logger;

        public PrintController(PipeClient pipeClient, ILogger<PrintController> logger)
        {
            _pipeClient = pipeClient;
            _logger = logger;
        }

        /// <summary>
        /// Sends a PRN file to a printer by name via the WorkerService.
        /// </summary>
        /// <param name="request">The print job request containing the target printer name and file path.</param>
        [HttpPost("execute")]
        public async Task<IActionResult> ExecutePrintJob([FromBody] PrintJobRequest request)
        {
            if (string.IsNullOrEmpty(request.PrinterName))
                return BadRequest("PrinterName is required");

            if (string.IsNullOrEmpty(request.FilePath))
                return BadRequest("FilePath is required");

            _logger.LogInformation("PrintController: executing print job for '{FilePath}' on '{Printer}'",
                request.FilePath, request.PrinterName);

            var ipcRequest = new IpcRequest
            {
                Command = "PrintJob",
                TargetPrinterName = request.PrinterName,
                FilePath = request.FilePath
            };

            var response = await _pipeClient.SendRequestAsync(ipcRequest);

            if (response.Success)
                return Ok(response);

            return StatusCode(500, response);
        }
    }

    public class PrintJobRequest
    {
        public string PrinterName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
    }
}
