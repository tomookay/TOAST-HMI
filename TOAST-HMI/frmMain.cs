using TwinCAT.Ads;
using System.Xml.Linq;
using System.Diagnostics.Eventing.Reader;

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

        private string tc3ProjectPath = string.Empty;


        bool isConnectionFaulted = false;

        string[] StationNames = new string[]
        {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"
        };



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
                isConnectionFaulted = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connect error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _adsClient = null;
                isConnectionFaulted = true;
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
                isConnectionFaulted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Write error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isConnectionFaulted = true;
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
            //isConnectionFaulted = true;

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

        private int ReadInt16(string plcSymbol)
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

            if (isConnectionFaulted == false)
            {
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
                        int stationState = ReadInt16("gHMIData.hmiHeader.stationstate");

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
                        int cycletypefeedback = ReadInt16("gHMIData.hmiHeader.cycleTypeFeedback");

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

                    //header.FaultStateHeader.
                    try
                    {
                        int faultStateHeader = ReadInt16("gHMIData.hmiHeader.FaultStateHeader");

                        // Map PLC integer values to colours. Adjust mapping as required.
                        string stateText = faultStateHeader switch
                        {
                            0 => " ",                // no data read from plc
                            1 => "Fault",       // normal auto cycle
                            2 => "Fault",           // single cycle, then stop auto cycle
                            3 => "Fault",           // error
                            _ => "Unknown"              // unknown
                        };

                        lblFaultState.Text = stateText;

                        //change background colour since its a fault indicator
                        if (faultStateHeader == 0)
                        {
                            lblFaultState.BackColor = SystemColors.Control;
                            //  lblFaultState.BackColor = Color.RebeccaPurple;
                        }
                        else
                        {
                            lblFaultState.BackColor = Color.Red;
                        }

                    }
                    catch
                    {
                        // ignore read errors for stationstate (optionally log)
                    }



                    //header.homestate.
                    try
                    {
                        int homestate = ReadInt16("gHMIData.hmiHeader.homestate");

                        // Map PLC integer values to colours. Adjust mapping as required.
                        string stateText = homestate switch
                        {
                            0 => "Not Home",                // not home
                            1 => "Homing",                     // in the state of homing
                            2 => "Home",           // in home state
                            3 => "Fault",           // error
                            _ => "Unknown"              // unknown
                        };

                        lblHomeState.Text = stateText;

                        //change background colour since its a fault indicator
                        if (homestate == 0)
                        {
                            lblHomeState.BackColor = SystemColors.Control;
                            //lblHomeState.BackColor = Color.RebeccaPurple;
                        }
                        else
                        {
                            lblFaultState.BackColor = Color.Green;
                        }


                    }
                    catch
                    {
                        // ignore read errors for stationstate (optionally log)
                    }

                    //header.AnyStationWarningHeader.
                    try
                    {
                        int homestate = ReadInt16("gHMIData.hmiHeader.AnyStationWarningHeader");

                        // Map PLC integer values to colours. Adjust mapping as required.
                        string stateText = homestate switch
                        {
                            0 => "Not Home",                // not home
                            1 => "Homing",                     // in the state of homing
                            2 => "Home",           // in home state
                            3 => "Fault",           // error
                            _ => "Unknown"              // unknown
                        };

                        lblHomeState.Text = stateText;

                        //change background colour since its a fault indicator
                        if (homestate == 0)
                        {
                            lblHomeState.BackColor = SystemColors.Control;
                            //lblHomeState.BackColor = Color.RebeccaPurple;
                        }
                        else
                        {
                            lblFaultState.BackColor = Color.Green;
                        }


                    }
                    catch
                    {
                        // ignore read errors for stationstate (optionally log)
                    }


                    //Station Name, header.stationNameSelect, StationNames
                    try
                    {
                        int stationName = ReadInt16("gHMIData.hmiHeader.stationNameSelect");
                                           

                        // Map PLC integer values to colours. Adjust mapping as required.
                        string stateText = stationName switch
                        {
                            0 => "No Value",                // no data read from plc
                            1 => "Station 1",                     //
                            2 => "Station 2",           //
                            3 => "Station 3",           //
                            4 => "Station 4",           //
                            5 => "Station 5",           //
                            6 => "Station 6",           //
                            _ => "Unknown"              // unknown
                        };

                        //if the contents of StationNames contains text entries, use those instead of the default mapping
                        if (StationNames.Length >= 6 && stationName >= 1 && stationName <= 6)
                        {
                            lblStationName.Text = StationNames[stationName - 1];
                            return;
                        }

                        lblStationName.Text = stateText;




                    }
                    catch
                    {
                        // ignore read errors for stationstate (optionally log)
                    }





                }
                catch
                {
                    // ignore read errors here
                    isConnectionFaulted = true;

                }



                //

            }

            //dont bother using timer anymore
            if (isConnectionFaulted)
            {
                timGetPLCData.Stop();
            }

        }

        private void btn26_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //load tc3 project
            ofdTc3Project.ShowDialog();
            tc3ProjectPath = ofdTc3Project.FileName;

            // Clear previous results in the listbox (if present)
            lbFoundFiles?.Items.Clear();

            if (!string.IsNullOrEmpty(tc3ProjectPath))
            {
                MessageBox.Show($"Loaded TC3 project: {tc3ProjectPath}", "TC3 Project", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //search for all textlist files
            //.TcTLO

            string projectDirectory = Path.GetDirectoryName(tc3ProjectPath) ?? string.Empty;
            var textListFiles = Directory.GetFiles(projectDirectory, "*.TcTLO", SearchOption.AllDirectories);

            // Populate the listbox with every found file (show full path)
            if (textListFiles.Length == 0)
            {
                MessageBox.Show("No .TcTLO files found in the selected project.", "TC3 Text List", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (var file in textListFiles)
                {
                    lbFoundFiles?.Items.Add(file);
                }

                // Select first item for convenience
                if (lbFoundFiles != null && lbFoundFiles.Items.Count > 0)
                    lbFoundFiles.SelectedIndex = 0;

                MessageBox.Show($"Found {textListFiles.Length} .TcTLO file(s).", "TC3 Text List", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //each .TcTLO file is an XML file
            //parse each file and extract the text entries
            foreach (var file in textListFiles)
            {
                try
                {
                    var xmlDoc = new System.Xml.XmlDocument();
                    xmlDoc.Load(file);
                    var textEntries = xmlDoc.GetElementsByTagName("TextListEntry");
                    foreach (System.Xml.XmlNode entry in textEntries)
                    {
                        var idNode = entry.SelectSingleNode("ID");
                        var textNode = entry.SelectSingleNode("Text");
                        if (idNode != null && textNode != null)
                        {
                            string id = idNode.InnerText;
                            string text = textNode.InnerText;
                            // For demonstration, show each text entry found
                            // In a real application, you might want to store these in a data structure
                            // or display them in a list.
                            MessageBox.Show($"ID: {id}, Text: {text}", "Text List Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error parsing file {file}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



            //find the text file called ScreenNames 
            string StationNamesFile = textListFiles.FirstOrDefault(f => Path.GetFileNameWithoutExtension(f).Equals("StationNames", StringComparison.OrdinalIgnoreCase));
            //if found, parse it and put the entries into StationNames[] using FindAllTextDefaults
            if (StationNamesFile != null) {
                try
                {
                    string fileContent = File.ReadAllText(StationNamesFile);
                    var entries = FindAllTextDefaults(fileContent);
                    //update StationNames array
                    for (int i = 0; i < entries.Count && i < StationNames.Length; i++)
                    {
                        StationNames[i] = entries[i].TextDefault;
                    }
                    MessageBox.Show($"Loaded {entries.Count} station names from StationNames.", "TC3 Text List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading or parsing StationNames file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }
        }

        private void ofdTc3Project_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        // Add this helper to your frmMain class
        private List<(string Id, string Text)> ParseTextListEntriesFromXml(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
                return new List<(string, string)>();

            // Parse with XDocument — works with or without namespaces
            var doc = XDocument.Parse(xml);

            // Use LocalName to ignore namespace prefixes (if any)
            var entries = doc
                .Descendants()
                .Where(e => e.Name.LocalName == "TextListEntry")
                .Select(e =>
                {
                    var idEl = e.Elements().FirstOrDefault(x => x.Name.LocalName == "ID");
                    var textEl = e.Elements().FirstOrDefault(x => x.Name.LocalName == "Text");
                    return (Id: idEl?.Value ?? string.Empty, Text: textEl?.Value ?? string.Empty);
                })
                .ToList();

            return entries;
        }

        // Add to frmMain class
        private List<(string TextId, string TextDefault)> FindTextDefaultsForTextId(string xml, string textId = "0")
        {
            if (string.IsNullOrWhiteSpace(xml))
                return new List<(string, string)>();

            var doc = XDocument.Parse(xml);

            var results = new List<(string, string)>();

            var textIdNodes = doc.Descendants()
                .Where(x => x.Name.LocalName == "v" && (string?)x.Attribute("n") == "TextID");

            foreach (var idNode in textIdNodes)
            {
                // Value may include surrounding quotes e.g. "0"
                var idValue = (idNode.Value ?? string.Empty).Trim().Trim('"');

                if (string.Equals(idValue, textId, StringComparison.Ordinal))
                {
                    var textDefaultNode = idNode.ElementsAfterSelf()
                        .FirstOrDefault(x => x.Name.LocalName == "v" && (string?)x.Attribute("n") == "TextDefault");

                    if (textDefaultNode != null)
                    {
                        var textDefault = (textDefaultNode.Value ?? string.Empty).Trim().Trim('"');
                        results.Add((idValue, textDefault));
                    }
                }
            }

            return results;
        }

        // Replace your existing FindAllTextDefaults and btnParse_Click with these implementations

        private List<(string TextId, string TextDefault)> FindAllTextDefaults(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
                return new List<(string, string)>();

            var doc = XDocument.Parse(xml);
            var results = new List<(string, string)>();

            // Find every <v n="TextID"> node
            var textIdNodes = doc.Descendants()
                .Where(x => x.Name.LocalName == "v" && (string?)x.Attribute("n") == "TextID");

            foreach (var idNode in textIdNodes)
            {
                // Trim surrounding quotes/whitespace
                var idValue = (idNode.Value ?? string.Empty).Trim().Trim('"');

                XElement? parent = idNode.Parent;
                XElement? textDefaultNode = null;

                // 1) Try any TextDefault inside the same parent element
                if (parent != null)
                {
                    textDefaultNode = parent
                        .Descendants()
                        .FirstOrDefault(x => x.Name.LocalName == "v" && (string?)x.Attribute("n") == "TextDefault");
                }

                // 2) Fallback: sibling elements after the TextID element (same parent)
                if (textDefaultNode == null && parent != null)
                {
                    var afterSiblings = parent.Elements().SkipWhile(e => e != idNode).Skip(1);
                    textDefaultNode = afterSiblings
                        .FirstOrDefault(x => x.Name.LocalName == "v" && (string?)x.Attribute("n") == "TextDefault");
                }

                // 3) Broader fallback: search the grandparent container
                if (textDefaultNode == null && parent?.Parent != null)
                {
                    textDefaultNode = parent.Parent
                        .Descendants()
                        .FirstOrDefault(x => x.Name.LocalName == "v" && (string?)x.Attribute("n") == "TextDefault");
                }

                if (textDefaultNode != null)
                {
                    var textDefault = (textDefaultNode.Value ?? string.Empty).Trim().Trim('"');
                    results.Add((idValue, textDefault));
                }
            }

            // Deduplicate by TextId and order numerically when possible
            //var deduped = results
            //    .GroupBy(r => r.TextId)
            //    .Select(g => g.First())
            //    .OrderBy(r => {
            //        if (int.TryParse(r.TextId, out var n)) return n;
            //        return int.MaxValue;
            //    })
            //    .ToList();

            return results;
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            try
            {
                var entries = FindAllTextDefaults(txbSpecialXML.Text);

                if (entries.Count == 0)
                {
                    MessageBox.Show("No TextID / TextDefault pairs found.", "Parse result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var sb = new System.Text.StringBuilder();
                foreach (var entry in entries)
                    sb.AppendLine($"TextID: \"{entry.TextId}\" → TextDefault: \"{entry.TextDefault}\"");

                // If the output is large prefer writing to a file or showing in a dedicated window.
                MessageBox.Show(sb.ToString(), $"Found {entries.Count} entries", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Xml.XmlException ex)
            {
                MessageBox.Show($"XML error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error parsing XML: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbFoundFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            //on the selected file, use the FindAllTextDefaults to parse the path
            if (lbFoundFiles.SelectedItem != null)
            {
                string selectedFilePath = lbFoundFiles.SelectedItem.ToString() ?? string.Empty;
                try
                {
                    string fileContent = File.ReadAllText(selectedFilePath);
                    var entries = FindAllTextDefaults(fileContent);
                    if (entries.Count == 0)
                    {
                        MessageBox.Show("No TextID / TextDefault pairs found in the selected file.", "Parse result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    var sb = new System.Text.StringBuilder();
                    foreach (var entry in entries)
                        sb.AppendLine($"TextID: \"{entry.TextId}\" → TextDefault: \"{entry.TextDefault}\"");
                    // Show results in the text box
                    txbSpecialXML.Text = sb.ToString();
                    //MessageBox.Show($"Found {entries.Count} entries in the selected file.", "Parse result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show(sb.ToString(), $"Found {entries.Count} entries", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading or parsing file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void btn13_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            isConnectionFaulted = false;
            timGetPLCData.Start();


        }

        private void lblStationName_Click(object sender, EventArgs e)
        {

        }
    }
}


































































