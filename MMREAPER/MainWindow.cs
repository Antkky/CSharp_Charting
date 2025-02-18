using System;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using EXAPI;
using Newtonsoft.Json;
using rtChart;

namespace MMREAPER
{
    public partial class MainWindow : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        readonly string secret_key = "";
        readonly string access_id = "";


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        private readonly int chartDataBufferSize = 100;

        private bool ChartStart = false;
        public kayChart bidSeries;
        public kayChart askSeries;

        public PData pData;

        readonly private WS_CLIENT wsClient = new WS_CLIENT();
        readonly private Handlers cbHandler = new Handlers();
        private CancellationTokenSource _cts;

        public MainWindow()
        {
            InitializeComponent();
            bidSeries = new kayChart(Chart, chartDataBufferSize)
            {
                serieName = "Bid"
            };

            askSeries = new kayChart(Chart, chartDataBufferSize)
            {
                serieName = "Ask"
            };
        }

        private async void Connect(object sender, EventArgs e)
        {
            string serverUri = "wss://socket.coinex.com/v2/futures";
            try
            {
                _cts = await wsClient.Connect(serverUri);

                await Task.Run(() => wsClient.Receive(_cts.Token, OnData));

                MessageBox.Show("Connected to the WebSocket server");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Start(object sender, EventArgs e)
        {
            StartButton.Text = ChartStart ? "Start" : "Stop";

            ChartStart = !ChartStart;

            Task.Factory.StartNew(() =>
            {
                bidSeries.updateChart(pData.Bid(), 1);
                askSeries.updateChart(pData.Ask(), 1);
                
            });
        }

        private void ReScaleY(object chart)
        {
            double max = Double.MinValue;
            double min = Double.MaxValue;
            Chart tmpChart = (Chart)chart;

            int dataPointCount = tmpChart.Series[0].Points.Count;
            int startIndex = Math.Max(0, dataPointCount - chartDataBufferSize);

            for (int i = startIndex; i < dataPointCount; i++)
            {
                var dp = tmpChart.Series[0].Points[i];
                min = Math.Min(min, dp.YValues[0]);
                max = Math.Max(max, dp.YValues[0]);
            }

            double margin = (max - min) * 0.1;
            tmpChart.ChartAreas[0].AxisY.Minimum = min - margin;
            tmpChart.ChartAreas[0].AxisY.Maximum = max + margin;

            double range = tmpChart.ChartAreas[0].AxisY.Maximum - tmpChart.ChartAreas[0].AxisY.Minimum;
            double interval = range / 10;


            if (interval < 1)
            {
                tmpChart.ChartAreas[0].AxisY.Interval = 0.1;
            }
            else if (interval < 10)
            {
                tmpChart.ChartAreas[0].AxisY.Interval = 1;
            }
            else
            {
                tmpChart.ChartAreas[0].AxisY.Interval = 5;
            }

            tmpChart.ChartAreas[0].AxisY.IsStartedFromZero = false;
        }


        private int OnData(string json) 
        {
            try
            {
                var baseResponse = JsonConvert.DeserializeObject<dynamic>(json);

                if (baseResponse.data != null)
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        cbHandler.HandleUpdate(baseResponse, bidSeries, askSeries);
                        ReScaleY(Chart); // Rescale the Y-axis after updating
                    }));
                }
                else
                {
                    Console.WriteLine($"{baseResponse.message}");
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing response: " + ex.Message);
                return 0;
            }
        }

        // Authenticate Button Click
        private async void Authenticate(object sender, EventArgs e)
        {
            if (!wsClient.Connected())
            {
                MessageBox.Show("WebSocket is not connected");
                return;
            }

            try
            {
                string signedStr = EXAPI.Translator.GenerateHMACSHA256(secret_key);

                var payload = new
                {
                    id = 10,
                    method = "server.sign",
                    @params = new
                    {
                        access_id,
                        signed_str = signedStr,
                        timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                    }
                };

                string package = Newtonsoft.Json.JsonConvert.SerializeObject(payload);

                await wsClient.Send(package);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error authenticating: {ex.Message}");
            }
        }

        // Subscribe Button Click
        private async void Subscribe(object sender, EventArgs e)
        {
            if (!wsClient.Connected())
            {
                MessageBox.Show("WebSocket is not connected");
                return;
            }

            try
            {
                var subscribeMessage = new
                {
                    method = "bbo.subscribe",
                    @params = new
                    {
                        market_list = new[] { "BTCUSDT" }
                    },
                    id = 3,
                };

                string message = Newtonsoft.Json.JsonConvert.SerializeObject(subscribeMessage);
                await wsClient.Send(message);
                MessageBox.Show("Subscribed to market depth updates for BTCUSDT");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error subscribing: {ex.Message}");
            }
        }

        private double UpdatePrice(dynamic data)
        {
            Random rnd = new Random();
            double price = rnd.NextDouble();

            return price;
        }


        // Close Application Safely
        private async void Close(object sender, EventArgs e)
        {
            await Task.Run(() => wsClient.Disconnect());
            Application.Exit();
        }

        private void Drag(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
