using System.IO.Pipes;
using System.Text;
using System.Text.Json;
using FollowMeFree_Shared;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FollowMeFree.WorkerService
{
    public class PipeServer : BackgroundService
    {
        public const string PipeName = "FollowMeFree_Pipe";

        private readonly ILogger<PipeServer> _logger;
        private readonly AppSettingsProvider _appSettings;

        public PipeServer(ILogger<PipeServer> logger, AppSettingsProvider appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("PipeServer started, listening on pipe '{PipeName}'", PipeName);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var pipeServer = new NamedPipeServerStream(
                        PipeName,
                        PipeDirection.InOut,
                        NamedPipeServerStream.MaxAllowedServerInstances,
                        PipeTransmissionMode.Byte,
                        PipeOptions.Asynchronous);

                    await pipeServer.WaitForConnectionAsync(stoppingToken);
                    _logger.LogInformation("PipeServer: client connected");

                    await HandleClientAsync(pipeServer, stoppingToken);
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "PipeServer: error handling client connection");
                }
            }

            _logger.LogInformation("PipeServer stopped");
        }

        private async Task HandleClientAsync(NamedPipeServerStream pipeServer, CancellationToken ct)
        {
            try
            {
                var requestJson = await ReadMessageAsync(pipeServer, ct);
                if (string.IsNullOrEmpty(requestJson))
                {
                    _logger.LogWarning("PipeServer: received empty request");
                    return;
                }

                _logger.LogInformation("PipeServer: received request: {Request}", requestJson);

                var request = JsonSerializer.Deserialize<IpcRequest>(requestJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var response = ProcessRequest(request);

                var responseJson = JsonSerializer.Serialize(response);
                await WriteMessageAsync(pipeServer, responseJson, ct);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PipeServer: error processing request");
            }
            finally
            {
                if (pipeServer.IsConnected)
                    pipeServer.Disconnect();
            }
        }

        private IpcResponse ProcessRequest(IpcRequest? request)
        {
            if (request == null)
            {
                return new IpcResponse { Success = false, Message = "Invalid request" };
            }

            switch (request.Command)
            {
                case "PrintJob":
                    return HandlePrintJob(request);

                default:
                    return new IpcResponse
                    {
                        Success = false,
                        Message = $"Unknown command: {request.Command}"
                    };
            }
        }

        private IpcResponse HandlePrintJob(IpcRequest request)
        {
            if (string.IsNullOrEmpty(request.TargetPrinterName))
            {
                return new IpcResponse { Success = false, Message = "TargetPrinterName is required" };
            }

            if (string.IsNullOrEmpty(request.FilePath))
            {
                return new IpcResponse { Success = false, Message = "FilePath is required" };
            }

            try
            {
                _logger.LogInformation("PipeServer: printing '{FilePath}' to '{Printer}'",
                    request.FilePath, request.TargetPrinterName);

                var fullPath = Path.Combine(_appSettings.JobFilePath, request.FilePath);
                string datatype = !string.IsNullOrEmpty(request.Datatype)
                    ? request.Datatype
                    : PrintJobExtractor.ParseDatatypeFromFileName(request.FilePath);
                bool result = PrnPrinter.SendToPrinterByName(request.TargetPrinterName, fullPath, datatype);

                return new IpcResponse
                {
                    Success = result,
                    Message = result
                        ? $"Print job sent to '{request.TargetPrinterName}' successfully"
                        : $"Failed to send print job to '{request.TargetPrinterName}'"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PipeServer: error executing PrintJob");
                return new IpcResponse
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        private static async Task<string> ReadMessageAsync(Stream stream, CancellationToken ct)
        {
            var lengthBuffer = new byte[4];
            int bytesRead = 0;
            while (bytesRead < 4)
            {
                int read = await stream.ReadAsync(lengthBuffer, bytesRead, 4 - bytesRead, ct);
                if (read == 0) return string.Empty;
                bytesRead += read;
            }

            int messageLength = BitConverter.ToInt32(lengthBuffer, 0);
            if (messageLength <= 0 || messageLength > 10 * 1024 * 1024)
                return string.Empty;

            var messageBuffer = new byte[messageLength];
            bytesRead = 0;
            while (bytesRead < messageLength)
            {
                int read = await stream.ReadAsync(messageBuffer, bytesRead, messageLength - bytesRead, ct);
                if (read == 0) break;
                bytesRead += read;
            }

            return Encoding.UTF8.GetString(messageBuffer, 0, bytesRead);
        }

        private static async Task WriteMessageAsync(Stream stream, string message, CancellationToken ct)
        {
            var messageBytes = Encoding.UTF8.GetBytes(message);
            var lengthBytes = BitConverter.GetBytes(messageBytes.Length);
            await stream.WriteAsync(lengthBytes, 0, lengthBytes.Length, ct);
            await stream.WriteAsync(messageBytes, 0, messageBytes.Length, ct);
            await stream.FlushAsync(ct);
        }
    }
}
