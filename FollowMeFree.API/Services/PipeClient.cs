using System.IO.Pipes;
using System.Text;
using System.Text.Json;
using FollowMeFree_Shared;

// This class handles IPC communication with the WorkerService using named pipes.

namespace FollowMeFree.API.Services
{
    public class PipeClient
    {
        private const string PipeName = "FollowMeFree_Pipe";
        private const int ConnectionTimeoutMs = 5000;

        private readonly ILogger<PipeClient> _logger;

        public PipeClient(ILogger<PipeClient> logger)
        {
            _logger = logger;
        }

        public async Task<IpcResponse> SendRequestAsync(IpcRequest request, CancellationToken ct = default)
        {
            try
            {
                using var pipeClient = new NamedPipeClientStream(".", PipeName, PipeDirection.InOut, PipeOptions.Asynchronous);

                await pipeClient.ConnectAsync(ConnectionTimeoutMs, ct);
                _logger.LogInformation("PipeClient: connected to WorkerService pipe");

                var requestJson = JsonSerializer.Serialize(request);
                await WriteMessageAsync(pipeClient, requestJson, ct);

                var responseJson = await ReadMessageAsync(pipeClient, ct);
                if (string.IsNullOrEmpty(responseJson))
                {
                    return new IpcResponse { Success = false, Message = "Empty response from WorkerService" };
                }

                var response = JsonSerializer.Deserialize<IpcResponse>(responseJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return response ?? new IpcResponse { Success = false, Message = "Failed to deserialize response" };
            }
            catch (TimeoutException)
            {
                _logger.LogError("PipeClient: connection to WorkerService timed out");
                return new IpcResponse { Success = false, Message = "WorkerService is not available (connection timed out)" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PipeClient: error communicating with WorkerService");
                return new IpcResponse { Success = false, Message = $"Communication error: {ex.Message}" };
            }
        }

        private static async Task WriteMessageAsync(Stream stream, string message, CancellationToken ct)
        {
            var messageBytes = Encoding.UTF8.GetBytes(message);
            var lengthBytes = BitConverter.GetBytes(messageBytes.Length);
            await stream.WriteAsync(lengthBytes, 0, lengthBytes.Length, ct);
            await stream.WriteAsync(messageBytes, 0, messageBytes.Length, ct);
            await stream.FlushAsync(ct);
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
    }
}
