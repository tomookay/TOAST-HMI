using TwinCAT.Ads;

namespace TOAST_HMI
{
    public partial class frmMain : Form
    {
        // Use a nullable field and a consistent camelCase name to match usages below.
        private AdsClient? _adsClient;
        // TODO: set to your PLC AMS Net ID (e.g. "5.25.123.1.1") and port (default 851)
        private readonly string _amsNetId = "5.132.152.5.1.1";
        private readonly int _adsPort = 851;

        private bool[] gStationSelected = new bool[6];

        public frmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
            this.FormClosing += FrmMain_FormClosing;

            // Wire momentary behaviour for buttons (press = TRUE, release = FALSE)
            WireMomentary(btnPowerOn, "gHMIButtons.btnMode.btnPowerOnPressed");
            WireMomentary(btnPowerOff, "gHMIButtons.btnMode.btnPowerOffPressed");

            //gHMIButtons.btnSelectStation1
            WireMomentary(btnStation1, "gHMIButtons.btnSelectStation1");
            WireMomentary(btnStation2, "gHMIButtons.btnSelectStation2");
            WireMomentary(btnStation3, "gHMIButtons.btnSelectStation3");
            WireMomentary(btnStation4, "gHMIButtons.btnSelectStation4");
            WireMomentary(btnStation5, "gHMIButtons.btnSelectStation5");
            WireMomentary(btnStation6, "gHMIButtons.btnSelectStation6");


            // Add more buttons here: WireMomentary(button2, "PLC.Symbol.ForButton2");
        }

        private void FrmMain_Load(object? sender, EventArgs e)
        {
            ConnectAds();
        }

        private void FrmMain_FormClosing(object? sender, FormClosingEventArgs e)
        {
            DisconnectAds();
        }

        private void ConnectAds()
        {
            try
            {
                _adsClient = new AdsClient();
                _adsClient.Connect(_amsNetId, _adsPort);
                if (_adsClient.IsConnected)
                {
                    // Optionally show status to the user or update UI
                    Console.WriteLine($"Connected to {_amsNetId}:{_adsPort}");

                    timGetPLCData.Start();



                }
            }
            catch (AdsErrorException ex)
            {
                MessageBox.Show($"ADS connect error: {ex.Message}", "ADS Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _adsClient = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connect error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _adsClient = null;
            }
        }

        private void DisconnectAds()
        {
            try
            {
                if (_adsClient != null)
                {
                    if (_adsClient.IsConnected)
                        _adsClient.Dispose();
                    _adsClient = null;

                    timGetPLCData.Stop();
                }
            }
            catch
            {
                // swallow - we're closing
                _adsClient = null;
            }
        }

        private void WriteBool(string plcSymbol, bool value)
        {
            if (_adsClient == null || !_adsClient.IsConnected)
            {
                MessageBox.Show("Not connected to PLC.", "ADS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            uint handle = 0;
            try
            {
                handle = _adsClient.CreateVariableHandle(plcSymbol);
                _adsClient.WriteAny(handle, value);
            }
            catch (AdsErrorException ex)
            {
                MessageBox.Show($"ADS write error: {ex.Message}", "ADS Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Write error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (handle != 0)
                {
                    try { _adsClient?.DeleteVariableHandle(handle); } catch { /* ignore */ }
                }
            }
        }

         private bool[] ReadBoolArray(string plcSymbol, int elementCount)
        {
            if (_adsClient == null || !_adsClient.IsConnected)
                throw new InvalidOperationException("Not connected to PLC.");

            uint handle = 0;
            try
            {
                handle = _adsClient.CreateVariableHandle(plcSymbol);

                // each boolean encoded as one byte on PLC here
                int elementSize = sizeof(byte);
                int readLength = checked(elementCount * elementSize);

                var result = _adsClient.ReadAsResult(handle, readLength);
                result.ThrowOnError();

                byte[] buffer = result.Data.ToArray();
                if (buffer.Length < elementCount)
                    throw new InvalidOperationException($"Unexpected read length: got {buffer.Length} bytes, expected {readLength}.");

                var values = new bool[elementCount];
                for (int i = 0; i < elementCount; i++)
                    values[i] = buffer[i] != 0;

                return values;
            }
            finally
            {
                if (handle != 0)
                {
                    try { _adsClient?.DeleteVariableHandle(handle); } catch { /* ignore */ }
                }
            }
        }

       

        private void WireMomentary(Button btn, string plcSymbol)
        {
            // mouse press
            btn.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left) WriteBool(plcSymbol, true);
            };

            // mouse release
            btn.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Left) WriteBool(plcSymbol, false);
            };

            // covers release when pointer leaves control while pressed
            btn.MouseCaptureChanged += (s, e) =>
            {
                if ((Control.MouseButtons & MouseButtons.Left) == 0) WriteBool(plcSymbol, false);
            };

            // keyboard support (Space / Enter)
            btn.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
                {
                    WriteBool(plcSymbol, true);
                    e.Handled = true;
                }
            };

            btn.KeyUp += (s, e) =>
            {
                if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
                {
                    WriteBool(plcSymbol, false);
                    e.Handled = true;
                }
            };

            // ensure FALSE when leaving and mouse isn't down
            btn.MouseLeave += (s, e) =>
            {
                if ((Control.MouseButtons & MouseButtons.Left) == 0) WriteBool(plcSymbol, false);
            };
        }

        private void frmMain_Load_1(object sender, EventArgs e)
        {

        }

        private void timGetPLCData_Tick(object sender, EventArgs e)
        {
            //read gStationSelected

            try
            {
                var values = ReadBoolArray("gHMIData.gStationSelected", 6);
                if (values.Length == gStationSelected.Length)
                {
                   Array.Copy(values, gStationSelected, values.Length);
                    if (gStationSelected[0] == true)
                    {
                        btnStation1.BackColor = Color.Lime;
                    }
                    else
                    {
                        btnStation1.BackColor = SystemColors.Control;
                    }

                    if (gStationSelected[1] == true)
                    {
                        btnStation2.BackColor = Color.Lime;
                    }
                    else
                    {
                        btnStation2.BackColor = SystemColors.Control;
                    }

                    if (gStationSelected[2] == true)
                    {
                        btnStation3.BackColor = Color.Lime;
                    }
                    else
                    {
                        btnStation3.BackColor = SystemColors.Control;
                    }

                    if (gStationSelected[3] == true)
                    {
                        btnStation4.BackColor = Color.Lime;
                    }
                    else
                    {
                        btnStation4.BackColor = SystemColors.Control;
                    }

                    if (gStationSelected[4] == true)
                    {
                        btnStation5.BackColor = Color.Lime;
                    }
                    else
                    {
                        btnStation5.BackColor = SystemColors.Control;
                    }

                    if (gStationSelected[5] == true)
                    {
                        btnStation6.BackColor = Color.Lime;
                    }
                    else
                    {
                        btnStation6.BackColor = SystemColors.Control;
                    }
                }
                else
                {
                    gStationSelected = values;
                }

            }
            catch
            {
                // ignore read errors here
            }
        }
    }
}
