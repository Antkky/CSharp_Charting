using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MMREAPER
{
    internal class Client
    {
        private ClientWebSocket _webSocket;
        public bool Connected = false;

        private async Task SendJsonToWebSocket(string json)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(json);
                await _webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Sending Message: " + ex.Message);
            }
        }

        public async Task ReceiveMessages()
        {
            var buffer = new byte[1024 * 4];
            while (_webSocket.State == WebSocketState.Open)
            {
                try
                {
                    WebSocketReceiveResult result;
                    using (var memoryStream = new System.IO.MemoryStream())
                    {
                        do
                        {
                            result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                            memoryStream.Write(buffer, 0, result.Count);
                        } while (!result.EndOfMessage);

                        byte[] receivedBytes = memoryStream.ToArray();
                        string message = Encoding.UTF8.GetString(receivedBytes);

                        _ = Task.Run(() => OnData(response));

                        MessageBox.Show("Received: " + message);
                    }
                }
                catch (Exception ex)
                {
                    if (_webSocket.State == WebSocketState.Open)
                    {
                        MessageBox.Show("Error receiving message: " + ex.Message);
                    }
                    break;
                }
            }
        }

        public async Task<bool> Connect(string url)
        {
            try
            {
                _webSocket = new ClientWebSocket();
                await _webSocket.ConnectAsync(new Uri(url), CancellationToken.None);
                MessageBox.Show("Connected to Server");
                Connected = true;
                return Connected;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Websocket error: " + ex.Message);
                Connected = false;
                return Connected;
            }
        }

    }
}
