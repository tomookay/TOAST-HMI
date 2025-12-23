using System;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Linq;
using TwinCAT;
using TwinCAT.Ads;
using TwinCAT.Ads.Reactive;
using TwinCAT.Ads.TypeSystem;
using TwinCAT.TypeSystem;



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
        string[] CycleType = new string[]
        {
            "0",
            "1",
            "2",
            "3"
        };
        string[] HomeState = new string[]
        {
            " ",
            " ",
            " ",
            " "
        };
        string[] FaultState = new string[]
        {
            " ",
            " ",
            " ",
            " "
        };
        string[] AnyStationAlarmList = new string[]
        {
            " ",
            " ",
            " ",
            " "
        };
        string[] AnyStationWarningList = new string[]
        {
            " ",
            " ",
            " ",
            " "
        };

        private bool[] gStationEnabled = new bool[6];

        private bool[] gButtonFdbk = new bool[40];
        private object symbolLoader;

        public frmMain()
        {
            InitializeComponent();
            SubscribeToRows();

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
            //WireMomentary(btn08, "gHMIButtons.btnMode.btn08Pressed";
            //WireMomentary(btn09, "gHMIButtons.btnMode.btn09Pressed");
            WireMomentary(btn10, "gHMIButtons.btnMode.btn10Pressed");
            WireMomentary(btn11, "gHMIButtons.btnMode.btn11Pressed");
            WireMomentary(btn12, "gHMIButtons.btnMode.btn12Pressed");
            WireMomentary(btn13, "gHMIButtons.btnMode.btn13Pressed");
            WireMomentary(btn14, "gHMIButtons.btnMode.btn14Pressed");
            WireMomentary(btn15, "gHMIButtons.btnMode.btn15Pressed");
            WireMomentary(btn16, "gHMIButtons.btnMode.btn16Pressed");
            //WireMomentary(btn17, "gHMIButtons.btnMode.btn17Pressed";
            //WireMomentary(btn18, "gHMIButtons.btnMode.btn18Pressed";
            //WireMomentary(btn19, "gHMIButtons.btnMode.btn19Pressed";
            WireMomentary(btn20, "gHMIButtons.btnMode.btn20Pressed");
            WireMomentary(btn21, "gHMIButtons.btnMode.btn21Pressed");
            WireMomentary(btn22, "gHMIButtons.btnMode.btn22Pressed");
            WireMomentary(btn23, "gHMIButtons.btnMode.btn23Pressed");
            WireMomentary(btn24, "gHMIButtons.btnMode.btn24Pressed");
            WireMomentary(btn25, "gHMIButtons.btnMode.btn25Pressed");
            WireMomentary(btn26, "gHMIButtons.btnMode.btn26Pressed");
            //WireMomentary(btn27, "gHMIButtons.btnMode.btn27Pressed";
            //WireMomentary(btn28, "gHMIButtons.btnMode.btn28Pressed";
            //WireMomentary(btn29, "gHMIButtons.btnMode.btn29Pressed";


            //WireMomentary(btn30, "gHMIButtons.btnMode.btn30Pressed";
            //WireMomentary(btn31, "gHMIButtons.btnMode.btn31Pressed";
            //WireMomentary(btn32, "gHMIButtons.btnMode.btn32Pressed";
            //WireMomentary(btn33, "gHMIButtons.btnMode.btn33Pressed";
            //WireMomentary(btn34, "gHMIButtons.btnMode.btn34Pressed";
            //WireMomentary(btn35, "gHMIButtons.btnMode.btn35Pressed";
            //WireMomentary(btn36, "gHMIButtons.btnMode.btn36Pressed";
            //WireMomentary(btn37, "gHMIButtons.btnMode.btn37Pressed";
            //WireMomentary(btn38, "gHMIButtons.btnMode.btn38Pressed";
            //WireMomentary(btn39, "gHMIButtons.btnMode.btn39Pressed";


            WireMomentary(btnAutoMode, "gHMIButtons.btnMode.btnFooterAutoMode");
            WireMomentary(btnManualMode, "gHMIButtons.btnMode.btnFooterManualMode");
            WireMomentary(btnStartAutoCycle, "gHMIButtons.btnMode.btnFooterAutoCycleStart");
            WireMomentary(btnSEOC, "gHMIButtons.btnMode.btnFooterAutoCycleStopEOC");
            WireMomentary(btnReturnHome, "gHMIButtons.btnMode.btnFooterReturnHome");

            // Create manual rows for demonstration
            //CreateManualRows(6);
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

        private void timGetPLCData_Tick(object sender, EventArgs e)
        {
            //read gStationSelected

            if (isConnectionFaulted == false)
            {
                try
                {


                    //MotionRowDto/
                    //call MotionRowDto
                    try
                    {
                        // Read and populate all 9 motion rows into matching usrcontRow controls
                        //    UpdateAllUsrcontRowsFromPlc();
                    }
                    catch
                    {
                        // ignore any read/update errors for the motion rows

                        //show a message with the text from the exception
                        //ssageBox
                    }

                    //same with isAnyFaultState
                    bool isAnyFaultState = ReadBoolArray("gHMIData.hmiHeader.isAnyFaultState", 1)[0];
                    //if the isAnyFaultState is true, then dont hide the lblFaultState
                    if (isAnyFaultState == true)
                    {
                        lblFaultState.Visible = true;
                    }
                    else
                    {
                        lblFaultState.Visible = false;
                    }

                    //read in text list 'AnyStationAlarmList' AnyStationAlarmList
                    //read integer header.AnyStationFaultHeader from PLC
                    try
                    {
                        int anyStationAlarmHeader = ReadInt16("gHMIData.hmiHeader.AnyStationFaultHeader");
                        //if AnyStationAlarmList[] array contains text, then fill in the lblFaultState with those texts
                        if (AnyStationAlarmList.Length >= 3 && anyStationAlarmHeader >= 0 && anyStationAlarmHeader <= 4)
                        {
                            lblFaultState.Text = AnyStationAlarmList[anyStationAlarmHeader];
                            // return;
                        }
                    }
                    catch
                    {
                        // ignore read errors for stationstate (optionally log)
                    }

                    //if gHMIData.gHideDisplayElementAlarmView.McEnabled is TRUE, then hide lblmsgViewAlarmMachine
                    bool hideAlarmView = ReadBoolArray("gHMIData.gHideDisplayElementAlarmView.McEnabled", 1)[0];
                    if (hideAlarmView == true)
                    {
                        lblmsgViewAlarmMachine.Visible = false;
                    }
                    else
                    {
                        lblmsgViewAlarmMachine.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgMc.Alarm.topMessage
                        lblmsgViewAlarmMachine.Text = ReadPlcString("GlobalMessages.gMsgMc.Alarm.topMessage");

                    }

                    //if gHMIData.gHideDisplayElementAlarmView.S1Enabled is TRUE then hide lblmsgViewAlarmStation1
                    bool hideAlarmViewS1 = ReadBoolArray("gHMIData.gHideDisplayElementAlarmView.S1Enabled", 1)[0];
                    if (hideAlarmViewS1 == true)
                    {
                        lblmsgViewAlarmS1.Visible = false;
                    }
                    else
                    {
                        lblmsgViewAlarmS1.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS1.Alarm.topMessage
                        lblmsgViewAlarmS1.Text = ReadPlcString("GlobalMessages.gMsgS1.Alarm.topMessage");

                    }
                    //if gHMIData.gHideDisplayElementAlarmView.S2Enabled is TRUE then hide lblmsgViewAlarmStation2
                    bool hideAlarmViewS2 = ReadBoolArray("gHMIData.gHideDisplayElementAlarmView.S2Enabled", 1)[0];
                    if (hideAlarmViewS2 == true)
                    {
                        lblmsgViewAlarmS2.Visible = false;
                    }
                    else
                    {
                        lblmsgViewAlarmS2.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS2.Alarm.topMessage
                        lblmsgViewAlarmS2.Text = ReadPlcString("GlobalMessages.gMsgS2.Alarm.topMessage");

                    }
                    //if gHMIData.gHideDisplayElementAlarmView.S3Enabled is TRUE then hide lblmsgViewAlarmStation3
                    bool hideAlarmViewS3 = ReadBoolArray("gHMIData.gHideDisplayElementAlarmView.S3Enabled", 1)[0];
                    if (hideAlarmViewS3 == true)
                    {
                        lblmsgViewAlarmS3.Visible = false;
                    }
                    else
                    {
                        lblmsgViewAlarmS3.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS3.Alarm.topMessage
                        lblmsgViewAlarmS3.Text = ReadPlcString("GlobalMessages.gMsgS3.Alarm.topMessage");

                    }
                    //if gHMIData.gHideDisplayElementAlarmView.S4Enabled is TRUE then hide lblmsgViewAlarmStation4
                    bool hideAlarmViewS4 = ReadBoolArray("gHMIData.gHideDisplayElementAlarmView.S4Enabled", 1)[0];
                    if (hideAlarmViewS4 == true)
                    {
                        lblmsgViewAlarmS4.Visible = false;
                    }
                    else
                    {
                        lblmsgViewAlarmS4.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS4.Alarm.topMessage
                        lblmsgViewAlarmS4.Text = ReadPlcString("GlobalMessages.gMsgS4.Alarm.topMessage");

                    }
                    //if gHMIData.gHideDisplayElementAlarmView.S5Enabled is TRUE then hide lblmsgViewAlarmStation5
                    bool hideAlarmViewS5 = ReadBoolArray("gHMIData.gHideDisplayElementAlarmView.S5Enabled", 1)[0];
                    if (hideAlarmViewS5 == true)
                    {
                        lblmsgViewAlarmS5.Visible = false;
                    }
                    else
                    {
                        lblmsgViewAlarmS5.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS5.Alarm.topMessage
                        lblmsgViewAlarmS5.Text = ReadPlcString("GlobalMessages.gMsgS5.Alarm.topMessage");

                    }
                    //if gHMIData.gHideDisplayElementAlarmView.S6Enabled is TRUE then hide lblmsgViewAlarmStation6
                    bool hideAlarmViewS6 = ReadBoolArray("gHMIData.gHideDisplayElementAlarmView.S6Enabled", 1)[0];
                    if (hideAlarmViewS6 == true)
                    {
                        lblmsgViewAlarmS6.Visible = false;
                    }
                    else
                    {
                        lblmsgViewAlarmS6.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS6.Alarm.topMessage
                        lblmsgViewAlarmS6.Text = ReadPlcString("GlobalMessages.gMsgS6.Alarm.topMessage");

                    }

                    //read gHMIData.gHideDisplayElementPromptView.McEnabled for prompts
                    bool hidePromptView = ReadBoolArray("gHMIData.gHideDisplayElementPromptView.McEnabled", 1)[0];
                    if (hidePromptView == true)
                    {
                        lblmsgViewPromptMachine.Visible = false;
                    }
                    else
                    {
                        lblmsgViewPromptMachine.Visible = true;
                    }
                    //read gHMIData.gHideDisplayElementPromptView.S1Enabled for prompts
                    bool hidePromptViewS1 = ReadBoolArray("gHMIData.gHideDisplayElementPromptView.S1Enabled", 1)[0];
                    if (hidePromptViewS1 == true)
                    {
                        lblmsgViewPromptsS1.Visible = false;
                    }
                    else
                    {
                        lblmsgViewPromptsS1.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS1.Prompts.topMessage
                        //read string from PLC
                        lblmsgViewPromptsS1.Text = ReadPlcString("GlobalMessages.gMsgS1.Prompts.topMessage");
                    }
                    //read gHMIData.gHideDisplayElementPromptView.S2Enabled for prompts
                    bool hidePromptViewS2 = ReadBoolArray("gHMIData.gHideDisplayElementPromptView.S2Enabled", 1)[0];
                    if (hidePromptViewS2 == true)
                    {
                        lblmsgViewPromptsS2.Visible = false;
                    }
                    else
                    {
                        lblmsgViewPromptsS2.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS2.Prompts.topMessage
                        lblmsgViewPromptsS2.Text = ReadPlcString("GlobalMessages.gMsgS2.Prompts.topMessage");

                    }
                    //read gHMIData.gHideDisplayElementPromptView.S3Enabled for prompts
                    bool hidePromptViewS3 = ReadBoolArray("gHMIData.gHideDisplayElementPromptView.S3Enabled", 1)[0];
                    if (hidePromptViewS3 == true)
                    {
                        lblmsgViewPromptsS3.Visible = false;
                    }
                    else
                    {
                        lblmsgViewPromptsS3.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS3.Prompts.topMessage
                        lblmsgViewPromptsS3.Text = ReadPlcString("GlobalMessages.gMsgS3.Prompts.topMessage");

                    }
                    //read gHMIData.gHideDisplayElementPromptView.S4Enabled for prompts
                    bool hidePromptViewS4 = ReadBoolArray("gHMIData.gHideDisplayElementPromptView.S4Enabled", 1)[0];
                    if (hidePromptViewS4 == true)
                    {
                        lblmsgViewPromptsS4.Visible = false;
                    }
                    else
                    {
                        lblmsgViewPromptsS4.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS4.Prompts.topMessage
                        lblmsgViewPromptsS4.Text = ReadPlcString("GlobalMessages.gMsgS4.Prompts.topMessage");

                    }
                    //read gHMIData.gHideDisplayElementPromptView.S5Enabled for prompts
                    bool hidePromptViewS5 = ReadBoolArray("gHMIData.gHideDisplayElementPromptView.S5Enabled", 1)[0];
                    if (hidePromptViewS5 == true)
                    {
                        lblmsgViewPromptsS5.Visible = false;
                    }
                    else
                    {
                        lblmsgViewPromptsS5.Visible = true;
                    }
                    //read gHMIData.gHideDisplayElementPromptView.S6Enabled for prompts
                    bool hidePromptViewS6 = ReadBoolArray("gHMIData.gHideDisplayElementPromptView.S6Enabled", 1)[0];
                    if (hidePromptViewS6 == true)
                    {
                        lblmsgViewPromptsS6.Visible = false;
                    }
                    else
                    {
                        lblmsgViewPromptsS6.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS6.Prompts.topMessage
                        lblmsgViewPromptsS6.Text = ReadPlcString("GlobalMessages.gMsgS6.Prompts.topMessage");

                    }

                    //now the same for warnings
                    //read gHMIData.gHideDisplayElementWarningView.McEnabled
                    bool hideWarningView = ReadBoolArray("gHMIData.gHideDisplayElementWarningView.McEnabled", 1)[0];
                    if (hideWarningView == true)
                    {
                        lblmsgViewWarningMachine.Visible = false;
                    }
                    else
                    {
                        lblmsgViewWarningMachine.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgMc.Warning.topMessage
                        lblmsgViewWarningMachine.Text = ReadPlcString("GlobalMessages.gMsgMc.Warning.topMessage");

                    }
                    //read gHMIData.gHideDisplayElementWarningView.S1Enabled
                    bool hideWarningViewS1 = ReadBoolArray("gHMIData.gHideDisplayElementWarningView.S1Enabled", 1)[0];
                    if (hideWarningViewS1 == true)
                    {
                        lblmsgViewWarningS1.Visible = false;
                    }
                    else
                    {
                        lblmsgViewWarningS1.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS1.Warning.topMessage
                        lblmsgViewWarningS1.Text = ReadPlcString("GlobalMessages.gMsgS1.Warning.topMessage");

                    }
                    //read gHMIData.gHideDisplayElementWarningView.S2Enabled
                    bool hideWarningViewS2 = ReadBoolArray("gHMIData.gHideDisplayElementWarningView.S2Enabled", 1)[0];
                    if (hideWarningViewS2 == true)
                    {
                        lblmsgViewWarningS2.Visible = false;
                    }
                    else
                    {
                        lblmsgViewWarningS2.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS2.Warning.topMessage
                        lblmsgViewWarningS2.Text = ReadPlcString("GlobalMessages.gMsgS2.Warning.topMessage");

                    }
                    //read gHMIData.gHideDisplayElementWarningView.S3Enabled
                    bool hideWarningViewS3 = ReadBoolArray("gHMIData.gHideDisplayElementWarningView.S3Enabled", 1)[0];
                    if (hideWarningViewS3 == true)
                    {
                        lblmsgViewWarningS3.Visible = false;
                    }
                    else
                    {
                        lblmsgViewWarningS3.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS3.Warning.topMessage
                        lblmsgViewWarningS3.Text = ReadPlcString("GlobalMessages.gMsgS3.Warning.topMessage");

                    }
                    //read gHMIData.gHideDisplayElementWarningView.S4Enabled
                    bool hideWarningViewS4 = ReadBoolArray("gHMIData.gHideDisplayElementWarningView.S4Enabled", 1)[0];
                    if (hideWarningViewS4 == true)
                    {
                        lblmsgViewWarningS4.Visible = false;
                    }
                    else
                    {
                        lblmsgViewWarningS4.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS4.Warning.topMessage
                        lblmsgViewWarningS4.Text = ReadPlcString("GlobalMessages.gMsgS4.Warning.topMessage");

                    }
                    //read gHMIData.gHideDisplayElementWarningView.S5Enabled
                    bool hideWarningViewS5 = ReadBoolArray("gHMIData.gHideDisplayElementWarningView.S5Enabled", 1)[0];
                    if (hideWarningViewS5 == true)
                    {
                        lblmsgViewWarningS5.Visible = false;
                    }
                    else
                    {
                        lblmsgViewWarningS5.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS5.Warning.topMessage
                        lblmsgViewWarningS5.Text = ReadPlcString("GlobalMessages.gMsgS5.Warning.topMessage");

                    }
                    //read gHMIData.gHideDisplayElementWarningView.S6Enabled
                    bool hideWarningViewS6 = ReadBoolArray("gHMIData.gHideDisplayElementWarningView.S6Enabled", 1)[0];
                    if (hideWarningViewS6 == true)
                    {
                        lblmsgViewWarningS6.Visible = false;
                    }
                    else
                    {
                        lblmsgViewWarningS6.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS6.Warning.topMessage
                        lblmsgViewWarningS6.Text = ReadPlcString("GlobalMessages.gMsgS6.Warning.topMessage");

                    }

                    //check warnings status from PLC from  .isAnyWarningState  
                    bool isAnyWarningState = ReadBoolArray("gHMIData.hmiHeader.isAnyWarningState", 1)[0];
                    //if the isAnyWarningState is true, then dont hide the lblAnyWarnings, but if  isAnyFaultState is TRUE then keep it hidden
                    if (isAnyWarningState == true && isAnyFaultState == false)
                    {
                        lblAnyWarnings.Visible = true;
                    }
                    else
                    {
                        lblAnyWarnings.Visible = false;
                    }
                    //read in integer header.AnyStationWarningHeader from PLC
                    try
                    {
                        int anyStationWarningHeader = ReadInt16("gHMIData.hmiHeader.AnyStationWarningHeader");
                        //if AnyStationWarningList[] array contains text, then fill in the lblAnyWarnings with those texts
                        if (AnyStationWarningList.Length >= 3 && anyStationWarningHeader >= 0 && anyStationWarningHeader <= 4)
                        {
                            lblAnyWarnings.Text = AnyStationWarningList[anyStationWarningHeader];
                            // return;
                        }
                    }
                    catch
                    {
                        // ignore read errors for stationstate (optionally log)
                    }

                    //gHMIButtons.btnFdbk.btnIsHomeFdbk
                    //read status of is home feedback
                    bool isHomeFdbk = ReadBoolArray("gHMIButtons.btnFdbk.btnIsHomeFdbk", 1)[0];
                    if (isHomeFdbk == true)
                    {
                        btnReturnHome.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        btnReturnHome.BackColor = SystemColors.Control;
                    }

                    //gHMIButtons.btnFdbk.btnAutoCyclingFdbk
                    //read status of auto cycling feedback
                    bool autoCyclingFdbk = ReadBoolArray("gHMIButtons.btnFdbk.btnAutoCyclingFdbk", 1)[0];
                    if (autoCyclingFdbk == true)
                    {
                        btnAutoCycleStart.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        btnAutoCycleStart.BackColor = SystemColors.Control;
                    }

                    //read power on status from Mc_Global.PowerOnFdbk
                    bool powerOnFdbk = ReadBoolArray("Mc_Global.PowerOnFdbk", 1)[0];
                    if (powerOnFdbk == true)
                    {
                        btnPowerOn.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        btnPowerOn.BackColor = SystemColors.Control;
                    }

                    //read all gHMIButtons.btnFdbk, which is 40 bools into gButtonFdbk array
                    var buttonFdbkValues = ReadBoolArray("gHMIButtons.btnFdbk", 32);
                    if (buttonFdbkValues.Length == gButtonFdbk.Length)
                    {
                        Array.Copy(buttonFdbkValues, gButtonFdbk, buttonFdbkValues.Length);
                        //update button backcolors based on gButtonFdbk values
                        //btn00 to btn39
                        for (int i = 0; i < 40; i++)
                        {
                            Button? btn = this.Controls.Find($"btn{i:D2}", true).FirstOrDefault() as Button;
                            if (btn != null)
                            {
                                if (gButtonFdbk[i] == true)
                                {
                                    btn.BackColor = Color.LightGreen;
                                }
                                else
                                {
                                    btn.BackColor = SystemColors.Control;
                                }
                            }
                        }


                        //carryover buttons
                        if (gButtonFdbk[00] == true)
                        {
                            btnAutoMode.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            btnAutoMode.BackColor = SystemColors.Control;
                        }

                        //btnManualMode
                        if (gButtonFdbk[01] == true)
                        {
                            btnManualMode.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            btnManualMode.BackColor = SystemColors.Control;
                        }


                    }
                    else
                    {
                        gButtonFdbk = buttonFdbkValues;
                    }

                    //read all gHMIButtons.btnHides, which is 32 bools into gButtonHides array
                    var buttonHidesValues = ReadBoolArray("gHMIButtons.btnHides", 32);
                    if (buttonHidesValues.Length == gButtonFdbk.Length)
                    {
                        //update button visibility based on gButtonHides values
                        for (int i = 0; i < 40; i++)
                        {
                            Button? btn = this.Controls.Find($"btn{i:D2}", true).FirstOrDefault() as Button;
                            if (btn != null)
                            {
                                btn.Visible = !buttonHidesValues[i];
                            }
                        }
                    }


                    //hide / show btnStation1, btnStation2, etc based on gStationEnabled
                    var enabledValues = ReadBoolArray("gHMIData.gStationEnabled", 6);
                    if (enabledValues.Length == gStationEnabled.Length)
                    {
                        Array.Copy(enabledValues, gStationEnabled, enabledValues.Length);
                        btnStation1.Visible = gStationEnabled[0];
                        btnStation2.Visible = gStationEnabled[1];
                        btnStation3.Visible = gStationEnabled[2];
                        btnStation4.Visible = gStationEnabled[3];
                        btnStation5.Visible = gStationEnabled[4];
                        btnStation6.Visible = gStationEnabled[5];
                    }
                    else
                    {
                        gStationEnabled = enabledValues;
                    }



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

                        //if the contents of CycleType contains text entries, use those instead of the default mapping
                        if (CycleType.Length >= 3 && cycletypefeedback >= 1 && cycletypefeedback <= 3)
                        {
                            lblCycleTypeState.Text = CycleType[cycletypefeedback];
                            // return;
                        }
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
                        }
                        else
                        {
                            lblFaultState.BackColor = Color.Red;
                        }

                        //lblFaultState
                        //lblFaultState
                        //if FaultState[] array contains text, then fill in the lblFaultState with those texts
                        if (FaultState.Length >= 3 && faultStateHeader >= 0 && faultStateHeader <= 4)
                        {
                            lblFaultState.Text = FaultState[faultStateHeader];
                            // return;
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
                        }
                        else
                        {
                            lblHomeState.BackColor = Color.Green;
                        }

                        //HomeState
                        //if HomeState[] array contains text, then fill in the lblHomeState with those texts
                        if (HomeState.Length >= 3 && homestate >= 0 && homestate <= 4)
                        {
                            lblHomeState.Text = HomeState[homestate];
                            // return;
                        }
                    }

                    catch
                    {
                        // ignore read errors for stationstate (optionally log)
                    }



                    //Station Name, header.stationNameSelect, StationNames
                    try
                    {
                        //
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
                            // return;

                            //set btnStation1, btnStation2, etc text to the station names
                            btnStation1.Text = StationNames[0];
                            btnStation2.Text = StationNames[1];
                            btnStation3.Text = StationNames[2];
                            btnStation4.Text = StationNames[3];
                            btnStation5.Text = StationNames[4];
                            btnStation6.Text = StationNames[5];
                        }
                        else
                        {
                            lblStationName.Text = stateText;
                        }

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
            }

            //dont bother using timer anymore
            if (isConnectionFaulted)
            {
                timGetPLCData.Stop();
            }
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
                // MessageBox.Show($"Loaded TC3 project: {tc3ProjectPath}", "TC3 Project", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                // MessageBox.Show($"Found {textListFiles.Length} .TcTLO file(s).", "TC3 Text List", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            // MessageBox.Show($"ID: {id}, Text: {text}", "Text List Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error parsing file {file}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //find the text file called AnyStationAlarmList
            string AnyStationAlarmListFile = textListFiles.FirstOrDefault(f => Path.GetFileNameWithoutExtension(f).Equals("AnyStationAlarmList", StringComparison.OrdinalIgnoreCase));
            //if found, parse it and put the entries into AnyStationAlarmList[] using FindAllTextDefaults
            if (AnyStationAlarmListFile != null)
            {
                try
                {
                    string fileContent = File.ReadAllText(AnyStationAlarmListFile);
                    var entries = FindAllTextDefaults(fileContent);
                    //update AnyStationAlarmList array
                    for (int i = 0; i < entries.Count && i < AnyStationAlarmList.Length; i++)
                    {
                        AnyStationAlarmList[i] = entries[i].TextDefault;
                    }
                    // MessageBox.Show($"Loaded {entries.Count} alarm states from AnyStationAlarmList.", "TC3 Text List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading or parsing AnyStationAlarmList file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //find the text file called AnyStationWarningList
            string AnyStationWarningListFile = textListFiles.FirstOrDefault(f => Path.GetFileNameWithoutExtension(f).Equals("AnyStationWarningList", StringComparison.OrdinalIgnoreCase));
            //if found, parse it and put the entries into AnyStationWarningList[] using FindAllTextDefaults
            if (AnyStationWarningListFile != null)
            {
                try
                {
                    string fileContent = File.ReadAllText(AnyStationWarningListFile);
                    var entries = FindAllTextDefaults(fileContent);
                    //update AnyStationWarningList array
                    for (int i = 0; i < entries.Count && i < AnyStationWarningList.Length; i++)
                    {
                        AnyStationWarningList[i] = entries[i].TextDefault;
                    }
                    // MessageBox.Show($"Loaded {entries.Count} warning states from AnyStationWarningList.", "TC3 Text List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading or parsing AnyStationWarningList file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



            //find the text file called FaultState
            string FaultStateFile = textListFiles.FirstOrDefault(f => Path.GetFileNameWithoutExtension(f).Equals("FaultState", StringComparison.OrdinalIgnoreCase));
            //if found, parse it and put the entries into FaultState[] using FindAllTextDefaults
            if (FaultStateFile != null)
            {
                try
                {
                    string fileContent = File.ReadAllText(FaultStateFile);
                    var entries = FindAllTextDefaults(fileContent);
                    //update FaultState array
                    for (int i = 0; i < entries.Count && i < FaultState.Length; i++)
                    {
                        FaultState[i] = entries[i].TextDefault;
                    }
                    // MessageBox.Show($"Loaded {entries.Count} fault states from FaultState.", "TC3 Text List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading or parsing FaultState file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            //find the text file called HomeState
            string HomeStateFile = textListFiles.FirstOrDefault(f => Path.GetFileNameWithoutExtension(f).Equals("HomeState", StringComparison.OrdinalIgnoreCase));
            //if found, parse it and put the entries into HomeState[] using FindAllTextDefaults
            if (HomeStateFile != null)
            {
                try
                {
                    string fileContent = File.ReadAllText(HomeStateFile);
                    var entries = FindAllTextDefaults(fileContent);
                    //update HomeState array
                    for (int i = 0; i < entries.Count && i < HomeState.Length; i++)
                    {
                        HomeState[i] = entries[i].TextDefault;
                    }
                    // MessageBox.Show($"Loaded {entries.Count} home states from HomeState.", "TC3 Text List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading or parsing HomeState file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            //find the text file called ScreenNames 
            string StationNamesFile = textListFiles.FirstOrDefault(f => Path.GetFileNameWithoutExtension(f).Equals("StationNames", StringComparison.OrdinalIgnoreCase));
            //if found, parse it and put the entries into StationNames[] using FindAllTextDefaults
            if (StationNamesFile != null)
            {
                try
                {
                    string fileContent = File.ReadAllText(StationNamesFile);
                    var entries = FindAllTextDefaults(fileContent);
                    //update StationNames array
                    for (int i = 0; i < entries.Count && i < StationNames.Length; i++)
                    {
                        StationNames[i] = entries[i].TextDefault;
                    }
                    // MessageBox.Show($"Loaded {entries.Count} station names from StationNames.", "TC3 Text List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading or parsing StationNames file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                //find the next file called CycleType
                string CycleTypeFile = textListFiles.FirstOrDefault(f => Path.GetFileNameWithoutExtension(f).Equals("CycleType", StringComparison.OrdinalIgnoreCase));
                //if found, parse it and put the entries into CycleType[] using FindAllTextDefaults
                if (CycleTypeFile != null)
                {
                    try
                    {
                        string fileContent = File.ReadAllText(CycleTypeFile);
                        var entries = FindAllTextDefaults(fileContent);
                        //update CycleType array
                        for (int i = 0; i < entries.Count && i < CycleType.Length; i++)
                        {
                            CycleType[i] = entries[i].TextDefault;
                        }
                        //   MessageBox.Show($"Loaded {entries.Count} cycle types from CycleType.", "TC3 Text List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error reading or parsing CycleType file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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

            return results;
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
                    //  txbSpecialXML.Text = sb.ToString();
                    //MessageBox.Show($"Found {entries.Count} entries in the selected file.", "Parse result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show(sb.ToString(), $"Found {entries.Count} entries", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading or parsing file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            isConnectionFaulted = false;
            timGetPLCData.Start();
        }

        // Read a PLC STRING (e.g. GlobalMessages.gMsgS1.Prompts.topMessage).
        // maxBytes should match the PLC STRING maximum length (buffer size) you expect.
        private string ReadPlcString(string plcSymbol, int maxBytes = 256)
        {
            if (_adsClient == null || !_adsClient.IsConnected)
                throw new InvalidOperationException("Not connected to PLC.");

            uint handle = 0;
            try
            {
                handle = _adsClient.CreateVariableHandle(plcSymbol);

                int readLength = checked(maxBytes);
                var result = _adsClient.ReadAsResult(handle, readLength);
                result.ThrowOnError();

                byte[] buffer = result.Data.ToArray();
                if (buffer.Length == 0)
                    return string.Empty;

                // Find first NUL (0) — common terminator for PLC strings
                int firstNull = Array.IndexOf(buffer, (byte)0);
                int usedLength = firstNull >= 0 ? firstNull : buffer.Length;

                // Detect and skip common Beckhoff/TwinCAT STRING length prefix if present:
                // Many PLC STRING implementations include a leading length byte.
                int startIndex = 0;
                if (buffer.Length >= 1)
                {
                    byte possibleLen = buffer[0];
                    // Heuristic: if first byte is small and <= maxBytes and non-printable,
                    // treat it as length prefix and skip it.
                    if (possibleLen > 0 && possibleLen <= maxBytes && possibleLen < 32)
                    {
                        startIndex = 1;
                        // adjust usedLength (reportedLen cannot exceed remaining buffer)
                        int reportedLen = Math.Min(possibleLen, usedLength - 1);
                        usedLength = Math.Max(0, reportedLen);
                    }
                }

                if (usedLength <= 0 || startIndex >= buffer.Length)
                    return string.Empty;

                // Decode bytes. Use ASCII which is commonly used for TwinCAT TEXT; change if you need UTF8/ANSI.
                string decoded = System.Text.Encoding.ASCII.GetString(buffer, startIndex, usedLength);

                // Trim any trailing NULs or control characters
                int trimAt = decoded.IndexOf('\0');
                if (trimAt >= 0)
                    decoded = decoded.Substring(0, trimAt);

                return decoded;
            }
            catch (AdsErrorException ex)
            {
                isConnectionFaulted = true;
                MessageBox.Show($"ADS read error ({plcSymbol}): {ex.Message}", "ADS Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            catch (Exception ex)
            {
                isConnectionFaulted = true;
                MessageBox.Show($"Read error ({plcSymbol}): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            finally
            {
                if (handle != 0)
                {
                    try { _adsClient?.DeleteVariableHandle(handle); } catch { /* ignore */ }
                }
            }
        }

        private void btnMode_Click(object sender, EventArgs e)
        {



        }

        private void btnControl_Click(object sender, EventArgs e)
        {


        }



        private void OnRowAdvanceClicked(object? sender, EventArgs e)
        {
            if (sender is usrcontRow row)
            {
                // Wire the row's inner advance button for momentary mouse-down / mouse-up behaviour.
                // We try to find a button named "btnAdvance" inside the usrcontRow; if not found,
                // find the first button whose name contains "advance" (case-insensitive).
                try
                {
                    Button? advanceBtn = row.Controls.Find("btnAdvance", true).FirstOrDefault() as Button;
                    if (advanceBtn == null)
                    {
                        advanceBtn = row.Controls.OfType<Button>()
                            .FirstOrDefault(b => b.Name.IndexOf("advance", StringComparison.OrdinalIgnoreCase) >= 0);
                    }

                    if (advanceBtn != null)
                    {
                        string plcSymbol = $"gHMIMotionRows.gMotionRowButtons.gMotionRow{row.RowIndex}btn.btnAdvance";

                        // Avoid double-wiring: use Tag to mark wired controls.
                        var tagKey = $"MomentaryWired:{plcSymbol}";
                        if (!(advanceBtn.Tag is string existingTag && existingTag == tagKey))
                        {
                            WireMomentary(advanceBtn, plcSymbol);
                            advanceBtn.Tag = tagKey;
                        }
                    }
                }
                catch
                {
                    // ignore wiring errors
                }

                // existing behavior: show info and/or call PLC directly if desired
                //  MessageBox.Show($"Advance clicked on row {row.RowIndex} ({row.RowName})", "Row Action", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // If you need to call PLC writes directly for a simple click, use:
                // WriteBool($"gManual.Row[{row.RowIndex}].AdvanceCmd", true);
            }
        }

        private void OnRowReturnClicked(object? sender, EventArgs e)
        {
            if (sender is usrcontRow row)
            {
                // Wire the row's inner return button for momentary mouse-down / mouse-up behaviour.
                try
                {
                    Button? returnBtn = row.Controls.Find("btnReturn", true).FirstOrDefault() as Button;
                    if (returnBtn == null)
                    {
                        returnBtn = row.Controls.OfType<Button>()
                            .FirstOrDefault(b => b.Name.IndexOf("return", StringComparison.OrdinalIgnoreCase) >= 0);
                    }

                    if (returnBtn != null)
                    {
                        string plcSymbol = $"gHMIMotionRows.gMotionRowButtons.gMotionRow{row.RowIndex}btn.btnReturn";
                        var tagKey = $"MomentaryWired:{plcSymbol}";
                        if (!(returnBtn.Tag is string existingTag && existingTag == tagKey))
                        {
                            WireMomentary(returnBtn, plcSymbol);
                            returnBtn.Tag = tagKey;
                        }
                    }
                }
                catch
                {
                    // ignore wiring errors
                }

                //  MessageBox.Show($"Return clicked on row {row.RowIndex} ({row.RowName})", "Row Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // WriteBool($"gManual.Row[{row.RowIndex}].ReturnCmd", true);
            }
        }

        private void btnAutoMode_Click(object sender, EventArgs e)
        {

        }

        private void usrcontRow1_Load(object sender, EventArgs e)
        {

        }

        private void SubscribeToRows()
        {
            // 1) Attach handlers for any designer-created usrcontRow controls placed on the form
            foreach (var row in this.Controls.Find("usrcontRow1", true).OfType<usrcontRow>())
            {
                // remove first to avoid duplicate subscriptions after designer reloads
                row.AdvanceClicked -= OnRowAdvanceClicked;
                row.ReturnClicked -= OnRowReturnClicked;

                row.AdvanceClicked += OnRowAdvanceClicked;
                row.ReturnClicked += OnRowReturnClicked;

                // optionally make the buttons visible
                row.EnsureActionButtonsVisible();
            }

            // 2) Attach handlers for all usrcontRow instances inside the manual rows container (if you use tpManualRows)
            if (tpManualRows != null)
            {
                foreach (var row in tpManualRows.Controls.OfType<usrcontRow>())
                {
                    row.AdvanceClicked -= OnRowAdvanceClicked;
                    row.ReturnClicked -= OnRowReturnClicked;

                    row.AdvanceClicked += OnRowAdvanceClicked;
                    row.ReturnClicked += OnRowReturnClicked;

                    row.EnsureActionButtonsVisible();
                }
            }
        }

        private void frmMain_Load_1(object sender, EventArgs e)
        {

        }

        // DTOs and helpers added to frmMain (same partial class)
        private record MotionSideDto
        {
            public bool RequestCoil { get; init; }
            public bool Depth { get; init; }
            public bool Prompt { get; init; }
            public bool InterlockOK { get; init; }
            public int NumberOrder { get; init; }
            public uint TimeTaken { get; init; }
            public int ValCoil { get; init; }
            public int ValDepth { get; init; }
            public bool HideCoil { get; init; }
            public bool HideDepth { get; init; }
            public bool HideInterlock { get; init; }
            public bool HidePrompt { get; init; }
            public bool HideTime { get; init; }
            public bool HideButton { get; init; }
            public uint FdbkColour { get; init; }
            public uint CoilColour { get; init; }
        }

        private record MotionRowDto
        {
            public MotionSideDto Advance { get; init; } = new();
            public MotionSideDto Return { get; init; } = new();
            public string StrPosn { get; init; } = string.Empty;
            public int IndexLocation { get; init; }
            public bool HidePosn { get; init; }
            public bool HideName { get; init; }
            public bool IsAbsSymSwitch { get; init; }
        }

        private bool ReadBool(string plcSymbol)
        {
            if (_adsClient == null || !_adsClient.IsConnected) throw new InvalidOperationException("Not connected to PLC.");
            uint handle = 0;
            try
            {
                handle = _adsClient.CreateVariableHandle(plcSymbol);
                var result = _adsClient.ReadAsResult(handle, sizeof(byte));
                result.ThrowOnError();
                byte[] buf = result.Data.ToArray();
                return buf.Length > 0 && buf[0] != 0;
            }
            finally
            {
                if (handle != 0) try { _adsClient?.DeleteVariableHandle(handle); } catch { }
            }
        }

        private int ReadInt32(string plcSymbol)
        {
            if (_adsClient == null || !_adsClient.IsConnected) throw new InvalidOperationException("Not connected to PLC.");
            uint handle = 0;
            try
            {
                handle = _adsClient.CreateVariableHandle(plcSymbol);
                var result = _adsClient.ReadAsResult(handle, sizeof(int));
                result.ThrowOnError();
                byte[] buf = result.Data.ToArray();
                if (buf.Length < 4) throw new InvalidOperationException($"Unexpected read length for {plcSymbol}");
                return BitConverter.ToInt32(buf, 0);
            }
            finally
            {
                if (handle != 0) try { _adsClient?.DeleteVariableHandle(handle); } catch { }
            }
        }

        private uint ReadUInt32(string plcSymbol)
        {
            if (_adsClient == null || !_adsClient.IsConnected) throw new InvalidOperationException("Not connected to PLC.");
            uint handle = 0;
            try
            {
                handle = _adsClient.CreateVariableHandle(plcSymbol);
                var result = _adsClient.ReadAsResult(handle, sizeof(uint));
                result.ThrowOnError();
                byte[] buf = result.Data.ToArray();
                if (buf.Length < 4) throw new InvalidOperationException($"Unexpected read length for {plcSymbol}");
                return BitConverter.ToUInt32(buf, 0);
            }
            finally
            {
                if (handle != 0) try { _adsClient?.DeleteVariableHandle(handle); } catch { }
            }
        }

        /// <summary>
        /// Read gHMIMotionRows.gMotionRows.gMotionRow{rowIndex} into a MotionRowDto.
        /// rowIndex: use the index that matches PLC naming (1-based in your sample).
        /// </summary>
        private MotionRowDto ReadMotionRowFromPlc(int rowIndex)
        {
            string baseSym = $"gHMIMotionRows.gMotionRows.gMotionRow{rowIndex}";

            MotionSideDto ReadSide(string sideName)
            {
                string prefix = $"{baseSym}.{sideName}";
                return new MotionSideDto
                {
                    RequestCoil = ReadBool($"{prefix}.RequestCoil"),
                    Depth = ReadBool($"{prefix}.Depth"),
                    Prompt = ReadBool($"{prefix}.Prompt"),
                    InterlockOK = ReadBool($"{prefix}.InterlockOK"),
                    NumberOrder = ReadInt16($"{prefix}.NumberOrder"),
                    TimeTaken = ReadUInt32($"{prefix}.TimeTaken"),
                    ValCoil = ReadInt16($"{prefix}.valCoil"),
                    ValDepth = ReadInt16($"{prefix}.valDepth"),
                    HideCoil = ReadBool($"{prefix}.bHideCoil"),
                    HideDepth = ReadBool($"{prefix}.bHideDepth"),
                    HideInterlock = ReadBool($"{prefix}.bHideInterlock"),
                    HidePrompt = ReadBool($"{prefix}.bHidePrompt"),
                    HideTime = ReadBool($"{prefix}.bHideTime"),
                    HideButton = ReadBool($"{prefix}.bHideButton"),
                    FdbkColour = ReadUInt32($"{prefix}.FdbkColour"),
                    CoilColour = ReadUInt32($"{prefix}.CoilColour")
                };
            }

            var row = new MotionRowDto
            {
                Advance = ReadSide("Advance"),
                Return = ReadSide("Returned"),
                StrPosn = ReadPlcString($"{baseSym}.strPosn", 80),
                IndexLocation = ReadInt16($"{baseSym}.IndexLocation"),
                HidePosn = ReadBool($"{baseSym}.bHidePosn"),
                HideName = ReadBool($"{baseSym}.bHideName"),
                IsAbsSymSwitch = ReadBool($"{baseSym}.bIsAbsSymSwitch")
            };

            return row;
        }

        private void UpdateUsrcontRowFromMotionRow(usrcontRow rowCtrl, MotionRowDto dto)
        {
            // Buttons visibility
            rowCtrl.ShowAdvanceButton = !dto.Advance.HideButton;
            rowCtrl.ShowReturnButton = !dto.Return.HideButton;

            // Basic textual mapping (use numeric values from PLC)
            rowCtrl.AdvanceName = dto.Advance.ValCoil.ToString();
            rowCtrl.AdvancedName = dto.Advance.ValDepth.ToString();
            rowCtrl.ReturnName = dto.Return.ValCoil.ToString();
            rowCtrl.ReturnedName = dto.Return.ValDepth.ToString();

            // Set 'IsReturned' based on a PLC boolean (we choose InterlockOK as returned indicator)
            rowCtrl.IsReturned = dto.Return.InterlockOK;

            // Map feedback colours if present (safe conversion)
            try
            {
                if (dto.Advance.FdbkColour != 0)
                    rowCtrl.AdvancedNameBackColor = Color.FromArgb((int)dto.Advance.FdbkColour);
            }
            catch { /* ignore invalid colour */ }

            try
            {
                if (dto.Return.FdbkColour != 0)
                    rowCtrl.ReturnedNameBackColor = Color.FromArgb((int)dto.Return.FdbkColour);
            }
            catch { /* ignore invalid colour */ }
        }


        private void UpdateAllUsrcontRowsFromPlc()
        {
            MotionRowDto dto;
            dto = ReadMotionRowFromPlc(1);
            UpdateUsrcontRowFromMotionRow(usrcontRow1, dto);



        }

        private void btnReadStructure_Click(object sender, EventArgs e)
        {
            if (_adsClient == null || !_adsClient.IsConnected)
            {
                MessageBox.Show("Not connected to PLC.", "ADS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Use the ISymbolLoaderFactory interface to get the symbol loader
                //  var symbolLoader = TwinCAT.Ads.SymbolLoaderFactory.Create(_adsClient, SymbolLoaderSettings.Default);


                var symbolLoader = (IDynamicSymbolLoader)SymbolLoaderFactory.Create(_adsClient, new SymbolLoaderSettings(SymbolsLoadMode.DynamicTree));

                var symbols = (DynamicSymbolsCollection)symbolLoader.SymbolsDynamic;


                // Load all symbols from the PLC's symbol table.
                //    var symbols = symbolLoader.Symbols;

                //    // Clear any previous results
                lsbReadSymbols?.Items.Clear();

                // Enumerate and display useful information about each symbol.
                foreach (var symbol in symbols)
                {
                    try
                    {
                        string path = symbol.InstancePath + "" + symbol.InstanceName + "(unknown)";
                        string typeName = symbol.DataType + "" + symbol.TypeName ?? "(type)";
                        int size = symbol.Size;
                        lsbReadSymbols?.Items.Add($"{path}  —  {typeName}  [{size} bytes]");
                    }
                    catch
                    {
                        lsbReadSymbols?.Items.Add("(symbol metadata unavailable)");
                    }
                }

                if (lsbReadSymbols != null && lsbReadSymbols.Items.Count > 0)
                    lsbReadSymbols.SelectedIndex = 0;
            }
            catch (AdsErrorException ex)
            {
                MessageBox.Show($"ADS error while reading symbol table: {ex.Message}", "ADS Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while reading symbol table: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lsbReadSymbols_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var symbolLoader = (IDynamicSymbolLoader)SymbolLoaderFactory.Create(_adsClient, new SymbolLoaderSettings(SymbolsLoadMode.DynamicTree));

            var symbols = (DynamicSymbolsCollection)symbolLoader.SymbolsDynamic;

            //search for gHMIData in symbols and populate the treeViewSymbols with the dynamic members
            try
            {

                treeViewSymbols.Nodes.Clear();
                DynamicSymbol? gHMIDataSymbol = (DynamicSymbol?)symbols.FirstOrDefault(s => s.InstanceName == "gHMIData");
                if (gHMIDataSymbol != null)
                {
                    // Populate the TreeView with the dynamic structure of gHMIData
                    PopulateDynamicSymbolTree(gHMIDataSymbol);
                }
                else
                {
                    MessageBox.Show("gHMIData symbol not found.");
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }






            //treeViewSymbols.Nodes.Clear();
            //try
            //{
            //    if (!cbFlat.Checked)
            //    {
            //        TcAdsSymbolInfo symbol = symbolLoader.GetFirstSymbol(true);
            //        while (symbol != null)
            //        {
            //            treeViewSymbols.Nodes.Add(CreateNewNode(symbol));
            //            symbol = symbol.NextSymbol;
            //        }
            //    }
            //    else
            //    {
            //        foreach (TcAdsSymbolInfo symbol in symbolLoader)
            //        {
            //            TreeNode node = new TreeNode(symbol.Name);
            //            node.Tag = symbol;
            //            treeViewSymbols.Nodes.Add(node);
            //        }
            //    }
            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show(err.Message);
            //}
        }

        // Added helper methods and a small change in button1_Click to populate treeViewSymbols
        // with the dynamic members of gHMIDataSymbol using reflection so it works regardless
        // of the concrete collection property name used by the TwinCAT dynamic symbol type.

        private void PopulateDynamicSymbolTree(DynamicSymbol rootSymbol)
        {
            if (rootSymbol == null) return;

            treeViewSymbols.BeginUpdate();
            try
            {
                treeViewSymbols.Nodes.Clear();
                var rootNode = CreateNodeForSymbol(rootSymbol);
                treeViewSymbols.Nodes.Add(rootNode);
                AddDynamicMembersRecursive(rootNode, rootSymbol);
                rootNode.Expand();
            }
            finally
            {
                treeViewSymbols.EndUpdate();
            }
        }

        private TreeNode CreateNodeForSymbol(object symbolObj)
        {
            if (symbolObj == null) return new TreeNode("(null)");

            var t = symbolObj.GetType();
            string name = GetPropertyString(symbolObj, "InstanceName")
                        ?? GetPropertyString(symbolObj, "Name")
                        ?? "(unnamed)";
            string path = GetPropertyString(symbolObj, "InstancePath") ?? string.Empty;
            string typeName = GetPropertyString(symbolObj, "TypeName")
                            ?? GetPropertyString(symbolObj, "DataType")
                            ?? GetPropertyString(symbolObj, "Type");
            string text = string.IsNullOrEmpty(path) ? $"{name} : {typeName}" : $"{path}.{name} : {typeName}";

            var node = new TreeNode(text) { Tag = symbolObj };
            return node;
        }

        private string? GetPropertyString(object obj, string propName)
        {
            var p = obj.GetType().GetProperty(propName, BindingFlags.Public | BindingFlags.Instance);
            if (p == null) return null;
            var v = p.GetValue(obj);
            return v?.ToString();
        }

        private void AddDynamicMembersRecursive(TreeNode parentNode, object symbolObj)
        {
            if (symbolObj == null) return;

            // Candidate property names used by different versions of TwinCAT dynamic types
            string[] candidateProps = new[] { "Members", "Children", "ChildSymbols", "Symbols", "NestedSymbols" };

            foreach (var propName in candidateProps)
            {
                var prop = symbolObj.GetType().GetProperty(propName, BindingFlags.Public | BindingFlags.Instance);
                if (prop == null) continue;

                var val = prop.GetValue(symbolObj);
                if (val is IEnumerable enumerable)
                {
                    foreach (var child in enumerable)
                    {
                        if (child == null) continue;

                        // Ensure child looks like a symbol (has InstanceName or Name)
                        if (child.GetType().GetProperty("InstanceName") == null && child.GetType().GetProperty("Name") == null)
                            continue;

                        var childNode = CreateNodeForSymbol(child);
                        parentNode.Nodes.Add(childNode);

                        // Recurse into child's members
                        AddDynamicMembersRecursive(childNode, child);
                    }

                    // Found a members collection and handled it — stop searching further candidates
                    return;
                }
            }

            // No standard members collection found — try scanning all public properties that are IEnumerable
            // and contain symbol-like elements (fallback).
            var allProps = symbolObj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var p in allProps)
            {
                if (p.GetIndexParameters().Length > 0) continue; // skip indexers
                if (!typeof(IEnumerable).IsAssignableFrom(p.PropertyType)) continue;

                var val = p.GetValue(symbolObj);
                if (val is IEnumerable enumerable)
                {
                    foreach (var child in enumerable)
                    {
                        if (child == null) continue;
                        if (child.GetType().GetProperty("InstanceName") == null && child.GetType().GetProperty("Name") == null)
                            continue;

                        var childNode = CreateNodeForSymbol(child);
                        parentNode.Nodes.Add(childNode);
                        AddDynamicMembersRecursive(childNode, child);
                    }
                }
            }
        }
    }
}


     


