using Newtonsoft.Json;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EXAPI
{
    public class WS_CLIENT
    {
        private ClientWebSocket _webSocket;
        private CancellationTokenSource _cts;
        public bool Connected() => _webSocket?.State == WebSocketState.Open;

        public async Task<CancellationTokenSource> Connect(string url)
        {
            try
            {
                _webSocket = new ClientWebSocket();
                await _webSocket.ConnectAsync(new Uri(url), CancellationToken.None);

                _cts = new CancellationTokenSource();

                Console.WriteLine("Connected to server");
                return _cts;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to connect to server");
                return _cts;
            }

        }

        public async Task Receive(CancellationToken cancellationToken, Func<string, int> onData)
        {
            var buffer = new byte[1024 * 4];
            while (Connected() && !cancellationToken.IsCancellationRequested)
            {
                try
                {
                    using (var memoryStream = new System.IO.MemoryStream())
                    {
                        WebSocketReceiveResult result;
                        do
                        {
                            result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);
                            memoryStream.Write(buffer, 0, result.Count);
                        } while (!result.EndOfMessage);

                        var decompressedResponse = Translator.DecompressResponse(memoryStream.ToArray());

                        if (decompressedResponse is string jsonResponse)
                        {
                            await Task.Run(() => onData(jsonResponse));
                        }
                        else
                        {
                            Print("Invalid response type received.", ConsoleColor.Red);
                        }
                    }
                }
                catch (Exception e)
                {
                    string msg = "Error receiving message: " + e.Message;
                    Print(msg, ConsoleColor.Red);
                }
            }
        }

        public async Task<bool> Send(string package)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(package);
                await _webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
                return true;
            }
            catch (Exception e)
            {
                string msg = "Error Sending Message: " + e.Message;
                Print(msg, ConsoleColor.Red);
                return false;
            }
        }

        public async Task Disconnect()
        {
            try
            {
                if (_webSocket != null && _webSocket.State == WebSocketState.Open)
                {
                    // Cancel the receive task if it's running
                    _cts?.Cancel();
                    await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                    Print("WebSocket Connection Closed", ConsoleColor.Green);
                }
            }
            catch (Exception e)
            {
                Print("WebSocket Connection Closed", ConsoleColor.Red);
            }
        }

        public void Print(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }
    }
}
