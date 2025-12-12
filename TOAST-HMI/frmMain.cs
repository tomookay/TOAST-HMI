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
            WireMomentary(btnSelectAll, "gHMIButtons.btnSelectAll");

            //gHMIButtons.btnSelectStation1
            WireMomentary(btnStation1, "gHMIButtons.btnSelectStation1");
            WireMomentary(btnStation2, "gHMIButtons.btnSelectStation2");
            WireMomentary(btnStation3, "gHMIButtons.btnSelectStation3");
            WireMomentary(btnStation4, "gHMIButtons.btnSelectStation4");
            WireMomentary(btnStation5, "gHMIButtons.btnSelectStation5");
            WireMomentary(btnStation6, "gHMIButtons.btnSelectStation6");

            WireMomentary(btnAutoCycleStart, "gHMIButtons.btnMode.btnAutoCycleStartPressed");
            WireMomentary(btnAutoCycleStop, "gHMIButtons.btnMode.btnAutoCycleStopPressed");



            //button Pressed BOOLs for mode screen

            ////	|------------------------------------|
            ////	|									 |
            ////	|a	00 01 02 03 04 05 06 07 08 09	x|
            ////	|b	10 11 12 13 14 15 16 17 18 19	y|
            //// 	|   20 21 22 23 24 25 26 27 28 29	 |
            //// 	|   30 31 32 33 34 35 36 37 38 39	 |
            ////	|									 |
            ////	|									 |
            ////	|------------------------------------|

            //button Pressed BOOL in X-Y format
            //a,b,x,y are not included


            WireMomentary(btn00, "gHMIButtons.btnMode.btn00Pressed");
            WireMomentary(btn01, "gHMIButtons.btnMode.btn01Pressed");
            WireMomentary(btn02, "gHMIButtons.btnMode.btn02Pressed");
            WireMomentary(btn03, "gHMIButtons.btnMode.btn03Pressed");
            WireMomentary(btn04, "gHMIButtons.btnMode.btn04Pressed");
            WireMomentary(btn05, "gHMIButtons.btnMode.btn05Pressed");
            WireMomentary(btn06, "gHMIButtons.btnMode.btn06Pressed");
            //WireMomentary(btn07, "gHMIButtons.btnMode.btn07Pressed");
            //WireMomentary(btn08, "gHMIButtons.btnMode.btn08Pressed");
            //WireMomentary(btn09, "gHMIButtons.btnMode.btn09Pressed");
            WireMomentary(btn10, "gHMIButtons.btnMode.btn10Pressed");
            WireMomentary(btn11, "gHMIButtons.btnMode.btn11Pressed");
            WireMomentary(btn12, "gHMIButtons.btnMode.btn12Pressed");
            WireMomentary(btn13, "gHMIButtons.btnMode.btn13Pressed");
            WireMomentary(btn14, "gHMIButtons.btnMode.btn14Pressed");
            WireMomentary(btn15, "gHMIButtons.btnMode.btn15Pressed");
            WireMomentary(btn16, "gHMIButtons.btnMode.btn16Pressed");
            //WireMomentary(btn17, "gHMIButtons.btnMode.btn17Pressed");
            //WireMomentary(btn18, "gHMIButtons.btnMode.btn18Pressed");
            //WireMomentary(btn19, "gHMIButtons.btnMode.btn19Pressed");
            WireMomentary(btn20, "gHMIButtons.btnMode.btn20Pressed");
            WireMomentary(btn21, "gHMIButtons.btnMode.btn21Pressed");
            WireMomentary(btn22, "gHMIButtons.btnMode.btn22Pressed");
            WireMomentary(btn23, "gHMIButtons.btnMode.btn23Pressed");
            WireMomentary(btn24, "gHMIButtons.btnMode.btn24Pressed");
            WireMomentary(btn25, "gHMIButtons.btnMode.btn25Pressed");
            WireMomentary(btn26, "gHMIButtons.btnMode.btn26Pressed");
            //WireMomentary(btn27, "gHMIButtons.btnMode.btn27Pressed");
            //WireMomentary(btn28, "gHMIButtons.btnMode.btn28Pressed");
            //WireMomentary(btn29, "gHMIButtons.btnMode.btn29Pressed");


            //WireMomentary(btn30, "gHMIButtons.btnMode.btn30Pressed");
            //WireMomentary(btn31, "gHMIButtons.btnMode.btn31Pressed");
            //WireMomentary(btn32, "gHMIButtons.btnMode.btn32Pressed");
            //WireMomentary(btn33, "gHMIButtons.btnMode.btn33Pressed");
            //WireMomentary(btn34, "gHMIButtons.btnMode.btn34Pressed");
            //WireMomentary(btn35, "gHMIButtons.btnMode.btn35Pressed");
            //WireMomentary(btn36, "gHMIButtons.btnMode.btn36Pressed");
            //WireMomentary(btn37, "gHMIButtons.btnMode.btn37Pressed");
            //WireMomentary(btn38, "gHMIButtons.btnMode.btn38Pressed");
            //WireMomentary(btn39, "gHMIButtons.btnMode.btn39Pressed");

            ////special case buttons	
            //btnPowerOnPressed: BOOL; //TRUE to power the machine on
            //btnPowerOffPressed: BOOL; //TRUE to power the machine off

            //btnAutoCycleStartPressed: BOOL; //TRUE to start auto cycle
            //btnAutoCycleStopPressed: BOOL; //TRUE to stop auto cycle immediately

            //btnFooterAutoCycleStart: BOOL;
            //btnFooterAutoCycleStopEOC: BOOL;
            //btnFooterReturnHome: BOOL;
            //btnFooterAutoMode: BOOL;
            //btnFooterManualMode: BOOL;


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

        private int ReadInt32(string plcSymbol)
        {
            if (_adsClient == null || !_adsClient.IsConnected)
                throw new InvalidOperationException("Not connected to PLC.");

            uint handle = 0;
            try
            {
                handle = _adsClient.CreateVariableHandle(plcSymbol);

                // Beckhoff stores this integer as a 16-bit value; read 2 bytes
                int readLength = sizeof(short);
                var result = _adsClient.ReadAsResult(handle, readLength);
                result.ThrowOnError();

                byte[] buffer = result.Data.ToArray();
                if (buffer.Length < readLength)
                    throw new InvalidOperationException($"Unexpected read length: got {buffer.Length} bytes, expected {readLength}.");

                // Convert 16-bit value and return as int for callers
                short val16 = BitConverter.ToInt16(buffer, 0);
                return (int)val16;
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
                WriteBool("gHMIButtons.gAnyButtonPressed", true);
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
                    WriteBool("gHMIButtons.gAnyButtonPressed", true);
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
                        btnStation1.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        btnStation1.BackColor = SystemColors.Control;
                    }

                    if (gStationSelected[1] == true)
                    {
                        btnStation2.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        btnStation2.BackColor = SystemColors.Control;
                    }

                    if (gStationSelected[2] == true)
                    {
                        btnStation3.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        btnStation3.BackColor = SystemColors.Control;
                    }

                    if (gStationSelected[3] == true)
                    {
                        btnStation4.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        btnStation4.BackColor = SystemColors.Control;
                    }

                    if (gStationSelected[4] == true)
                    {
                        btnStation5.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        btnStation5.BackColor = SystemColors.Control;
                    }

                    if (gStationSelected[5] == true)
                    {
                        btnStation6.BackColor = Color.LightGreen;
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

                // --- read integer station state and update lblStationState background ---
                try
                {
                    int stationState = ReadInt32("gHMIData.hmiHeader.stationstate");

                    // Map PLC integer values to colours. Adjust mapping as required.
                    string stateText = stationState switch
                    {
                        0 => "No State",               // no state or data not read from plc
                        1 => "Power Off",             // powered off baseline
                        2 => "Power On",              // Powered on baseline
                        3 => "Manual",              // manual mode on the manual buttons
                        4 => "Auto",                  // auto but not cycling
                        5 => "Auto Cycle",           // normal auto cycling state
                        6 => "Semi Auto",           // semi auto state
                        7 => "Fault",               // normal fault state
                        8 => "Bypass",              // bypass station, some auto possible?
                        9 => "Auto Cycle Stopping",  // stopping
                       _ => "Unknown"               // unknown
                    };

                    lblStationState.Text = stateText;
                }
                catch
                {
                    // ignore read errors for stationstate (optionally log)
                }


                //header.cycleTypeFeedback.
                try
                {
                    int cycletypefeedback = ReadInt32("gHMIData.hmiHeader.cycleTypeFeedback");

                    // Map PLC integer values to colours. Adjust mapping as required.
                    string stateText = cycletypefeedback switch
                    {
                        0 => "No State",                // no data read from plc
                        1 => "Continuous Cycle",       // normal auto cycle
                        2 => "Single Cycle",           // single cycle, then stop auto cycle
                        3 => "other state",           // error
                        _ => "Unknown"              // unknown
                    };

                    lblCycleTypeState.Text = stateText;
                }
                catch
                {
                    // ignore read errors for stationstate (optionally log)
                }
            }
            catch
            {
                // ignore read errors here
            }
        }

        private void btn26_Click(object sender, EventArgs e)
        {

        }


    }
}


