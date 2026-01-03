using Microsoft.Win32;
using System.Collections;
using System.Reflection;
using System.Xml.Linq;
using TwinCAT;
using TwinCAT.Ads;
using TwinCAT.Ads.TypeSystem;
using TwinCAT.TypeSystem;

namespace TOAST_HMI
{
    public partial class frmMain : Form
    {
        // Use a nullable field and a consistent camelCase name to match usages below.
        private AdsClient? _adsClient;

        //set connection data to PLC
        amsdata connectionData = new amsdata();



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


        public frmMain()
        {
            InitializeComponent();
            SubscribeToRows();

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

        private void frmMain_Load(object? sender, EventArgs e)
        {
            connectionData = regHelper.LoadSettingsFromRegistry();
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
                _adsClient.Connect(connectionData.amsNetId, connectionData.amsPort);
                if (_adsClient.IsConnected)
                {
                    // Optionally show status to the user or update UI
                    Console.WriteLine($"Connected to {connectionData.amsNetId}:{connectionData.amsPort}");
                    timGetPLCData.Start();
                }
            }
            catch (AdsErrorException ex)
            {
                MessageBox.Show($"ADS connect error 1: {ex.Message}", "ADS Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _adsClient = null;
                isConnectionFaulted = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connect error 2: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void WireMomentary(Button btn, string plcSymbol)
        {
            // mouse press
            btn.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left) adsIO.WriteBool(plcSymbol, true, _adsClient);
                adsIO.WriteBool("gHMIButtons.gAnyButtonPressed", true, _adsClient);
            };

            // mouse release
            btn.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Left) adsIO.WriteBool(plcSymbol, false, _adsClient);
            };

            // covers release when pointer leaves control while pressed
            btn.MouseCaptureChanged += (s, e) =>
            {
                if ((Control.MouseButtons & MouseButtons.Left) == 0) adsIO.WriteBool(plcSymbol, false, _adsClient);
            };

            // keyboard support (Space / Enter)
            btn.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
                {
                    adsIO.WriteBool(plcSymbol, true, _adsClient);
                    e.Handled = true;
                    adsIO.WriteBool("gHMIButtons.gAnyButtonPressed", true, _adsClient);
                }
            };

            btn.KeyUp += (s, e) =>
            {
                if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
                {
                    adsIO.WriteBool(plcSymbol, false, _adsClient);
                    e.Handled = true;
                }
            };

            // ensure FALSE when leaving and mouse isn't down
            btn.MouseLeave += (s, e) =>
            {
                if ((Control.MouseButtons & MouseButtons.Left) == 0) adsIO.WriteBool(plcSymbol, false, _adsClient);
            };
        }

        private void timGetPLCData_Tick(object sender, EventArgs e)
        {
            if (isConnectionFaulted == false)
            {
                try
                {
                    var symbolLoader = (IDynamicSymbolLoader)SymbolLoaderFactory.Create
                      (
                          _adsClient,
                          new SymbolLoaderSettings(SymbolsLoadMode.DynamicTree)
                      );

                    var symbols = (DynamicSymbolsCollection)symbolLoader.SymbolsDynamic;

                    //assign the symbols of gTOASTHMI to a dynamic variable
                    dynamic gTOASTHMI = symbols["gTOASTHMI"];

                    //pick out the gHMI and gButtons
                    dynamic gHMI = gTOASTHMI.gData.hmi.ReadValue();
                    dynamic gbtns = gTOASTHMI.gData.btns.ReadValue();
                    dynamic gMsgs = gTOASTHMI.gData.GlobalMessages.ReadValue();


                    //gData now contains;
                    //hmi: structHMI;
                    //btns: structHMIBtns;

                    try
                    {
                        // Read and populate all 9 motion rows into matching usrcontRow controls
                        //    UpdateAllUsrcontRowsFromPlc();
                    }
                    catch
                    {

                    }

                    //same with isAnyFaultState
                    // bool isAnyFaultState = ReadBoolArray("gHMIData.hmiHeader.isAnyFaultState", 1)[0];
                    bool isAnyFaultState = gHMI.hmiHeader.isAnyFaultState;

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
                        //int anyStationAlarmHeader = ReadInt16("gHMIData.hmiHeader.AnyStationFaultHeader");
                        int anyStationAlarmHeader = gHMI.hmiHeader.AnyStationFaultHeader;
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
                    //bool hideAlarmView = ReadBoolArray("gHMIData.gHideDisplayElementAlarmView.McEnabled", 1)[0];
                    bool hideAlarmView = gHMI.gHideDisplayElementAlarmView.McEnabled;
                    if (hideAlarmView == true)
                    {
                        lblmsgViewAlarmMachine.Visible = false;
                    }
                    else
                    {
                        lblmsgViewAlarmMachine.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgMc.Alarm.topMessage
                        //lblmsgViewAlarmMachine.Text = ReadPlcString("GlobalMessages.gMsgMc.Alarm.topMessage");
                        lblmsgViewAlarmMachine.Text = gMsgs.gMsgMc.Alarm.topMessage;

                    }

                    //if gHMIData.gHideDisplayElementAlarmView.S1Enabled is TRUE then hide lblmsgViewAlarmStation1
                    //bool hideAlarmViewS1 = ReadBoolArray("gHMIData.gHideDisplayElementAlarmView.S1Enabled", 1)[0];
                    bool hideAlarmViewS1 = gHMI.gHideDisplayElementAlarmView.S1Enabled;

                    if (hideAlarmViewS1 == true)
                    {
                        lblmsgViewAlarmS1.Visible = false;
                    }
                    else
                    {
                        lblmsgViewAlarmS1.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS1.Alarm.topMessage
                        // lblmsgViewAlarmS1.Text = ReadPlcString("GlobalMessages.gMsgS1.Alarm.topMessage");
                        lblmsgViewAlarmS1.Text = gMsgs.gMsgS1.Alarm.topMessage;

                    }
                    //if gHMIData.gHideDisplayElementAlarmView.S2Enabled is TRUE then hide lblmsgViewAlarmStation2
                    // bool hideAlarmViewS2 = ReadBoolArray("gHMIData.gHideDisplayElementAlarmView.S2Enabled", 1)[0];
                    bool hideAlarmViewS2 = gHMI.gHideDisplayElementAlarmView.S2Enabled;
                    if (hideAlarmViewS2 == true)
                    {
                        lblmsgViewAlarmS2.Visible = false;
                    }
                    else
                    {
                        lblmsgViewAlarmS2.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS2.Alarm.topMessage
                        //lblmsgViewAlarmS2.Text = ReadPlcString("GlobalMessages.gMsgS2.Alarm.topMessage");
                        lblmsgViewAlarmS2.Text = gMsgs.gMsgS2.Alarm.topMessage;

                    }
                    //if gHMIData.gHideDisplayElementAlarmView.S3Enabled is TRUE then hide lblmsgViewAlarmStation3
                    // bool hideAlarmViewS3 = ReadBoolArray("gHMIData.gHideDisplayElementAlarmView.S3Enabled", 1)[0];
                    bool hideAlarmViewS3 = gHMI.gHideDisplayElementAlarmView.S3Enabled;
                    if (hideAlarmViewS3 == true)
                    {
                        lblmsgViewAlarmS3.Visible = false;
                    }
                    else
                    {
                        lblmsgViewAlarmS3.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS3.Alarm.topMessage
                        //lblmsgViewAlarmS3.Text = ReadPlcString("GlobalMessages.gMsgS3.Alarm.topMessage");
                        lblmsgViewAlarmS3.Text = gMsgs.gMsgS3.Alarm.topMessage;

                    }
                    //if gHMIData.gHideDisplayElementAlarmView.S4Enabled is TRUE then hide lblmsgViewAlarmStation4
                    //bool hideAlarmViewS4 = ReadBoolArray("gHMIData.gHideDisplayElementAlarmView.S4Enabled", 1)[0];
                    bool hideAlarmViewS4 = gHMI.gHideDisplayElementAlarmView.S4Enabled;
                    if (hideAlarmViewS4 == true)
                    {
                        lblmsgViewAlarmS4.Visible = false;
                    }
                    else
                    {
                        lblmsgViewAlarmS4.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS4.Alarm.topMessage
                        //lblmsgViewAlarmS4.Text = ReadPlcString("GlobalMessages.gMsgS4.Alarm.topMessage");
                        lblmsgViewAlarmS4.Text = gMsgs.gMsgS4.Alarm.topMessage;

                    }
                    //if gHMIData.gHideDisplayElementAlarmView.S5Enabled is TRUE then hide lblmsgViewAlarmStation5
                    //bool hideAlarmViewS5 = ReadBoolArray("gHMIData.gHideDisplayElementAlarmView.S5Enabled", 1)[0];
                    bool hideAlarmViewS5 = gHMI.gHideDisplayElementAlarmView.S5Enabled;
                    if (hideAlarmViewS5 == true)
                    {
                        lblmsgViewAlarmS5.Visible = false;
                    }
                    else
                    {
                        lblmsgViewAlarmS5.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS5.Alarm.topMessage
                        //lblmsgViewAlarmS5.Text = ReadPlcString("GlobalMessages.gMsgS5.Alarm.topMessage");
                        lblmsgViewAlarmS5.Text = gMsgs.gMsgS5.Alarm.topMessage;


                    }
                    //if gHMIData.gHideDisplayElementAlarmView.S6Enabled is TRUE then hide lblmsgViewAlarmStation6
                    // bool hideAlarmViewS6 = ReadBoolArray("gHMIData.gHideDisplayElementAlarmView.S6Enabled", 1)[0];
                    bool hideAlarmViewS6 = gHMI.gHideDisplayElementAlarmView.S6Enabled;
                    if (hideAlarmViewS6 == true)
                    {
                        lblmsgViewAlarmS6.Visible = false;
                    }
                    else
                    {
                        lblmsgViewAlarmS6.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS6.Alarm.topMessage
                        //lblmsgViewAlarmS6.Text = ReadPlcString("GlobalMessages.gMsgS6.Alarm.topMessage");
                        lblmsgViewAlarmS6.Text = gMsgs.gMsgS6.Alarm.topMessage;

                    }

                    //read gHMIData.gHideDisplayElementPromptView.McEnabled for prompts
                    // bool hidePromptView = ReadBoolArray("gHMIData.gHideDisplayElementPromptView.McEnabled", 1)[0];
                    bool hidePromptView = gHMI.gHideDisplayElementPromptView.McEnabled;
                    if (hidePromptView == true)
                    {
                        lblmsgViewPromptMachine.Visible = false;
                    }
                    else
                    {
                        lblmsgViewPromptMachine.Visible = true;
                    }
                    //read gHMIData.gHideDisplayElementPromptView.S1Enabled for prompts
                    //bool hidePromptViewS1 = ReadBoolArray("gHMIData.gHideDisplayElementPromptView.S1Enabled", 1)[0];
                    bool hidePromptViewS1 = gHMI.gHideDisplayElementPromptView.S1Enabled;
                    if (hidePromptViewS1 == true)
                    {
                        lblmsgViewPromptsS1.Visible = false;
                    }
                    else
                    {
                        lblmsgViewPromptsS1.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS1.Prompts.topMessage
                        //read string from PLC
                        //lblmsgViewPromptsS1.Text = ReadPlcString("GlobalMessages.gMsgS1.Prompts.topMessage");
                        lblmsgViewPromptsS1.Text = gMsgs.gMsgS1.Prompts.topMessage;
                    }
                    //read gHMIData.gHideDisplayElementPromptView.S2Enabled for prompts
                    //bool hidePromptViewS2 = ReadBoolArray("gHMIData.gHideDisplayElementPromptView.S2Enabled", 1)[0];
                    bool hidePromptViewS2 = gHMI.gHideDisplayElementPromptView.S2Enabled;
                    if (hidePromptViewS2 == true)
                    {
                        lblmsgViewPromptsS2.Visible = false;
                    }
                    else
                    {
                        lblmsgViewPromptsS2.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS2.Prompts.topMessage
                        //lblmsgViewPromptsS2.Text = ReadPlcString("GlobalMessages.gMsgS2.Prompts.topMessage");
                        lblmsgViewPromptsS2.Text = gMsgs.gMsgS2.Prompts.topMessage;

                    }
                    //read gHMIData.gHideDisplayElementPromptView.S3Enabled for prompts
                    //bool hidePromptViewS3 = ReadBoolArray("gHMIData.gHideDisplayElementPromptView.S3Enabled", 1)[0];
                    bool hidePromptViewS3 = gHMI.gHideDisplayElementPromptView.S3Enabled;
                    if (hidePromptViewS3 == true)
                    {
                        lblmsgViewPromptsS3.Visible = false;
                    }
                    else
                    {
                        lblmsgViewPromptsS3.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS3.Prompts.topMessage
                        //lblmsgViewPromptsS3.Text = ReadPlcString("GlobalMessages.gMsgS3.Prompts.topMessage");
                        lblmsgViewPromptsS3.Text = gMsgs.gMsgS3.Prompts.topMessage;

                    }
                    //read gHMIData.gHideDisplayElementPromptView.S4Enabled for prompts
                    //bool hidePromptViewS4 = ReadBoolArray("gHMIData.gHideDisplayElementPromptView.S4Enabled", 1)[0];
                    bool hidePromptViewS4 = gHMI.gHideDisplayElementPromptView.S4Enabled;
                    if (hidePromptViewS4 == true)
                    {
                        lblmsgViewPromptsS4.Visible = false;
                    }
                    else
                    {
                        lblmsgViewPromptsS4.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS4.Prompts.topMessage
                        //    lblmsgViewPromptsS4.Text = ReadPlcString("GlobalMessages.gMsgS4.Prompts.topMessage");
                        lblmsgViewPromptsS4.Text = gMsgs.gMsgS4.Prompts.topMessage;

                    }
                    //read gHMIData.gHideDisplayElementPromptView.S5Enabled for prompts
                    //bool hidePromptViewS5 = ReadBoolArray("gHMIData.gHideDisplayElementPromptView.S5Enabled", 1)[0];
                    bool hidePromptViewS5 = gHMI.gHideDisplayElementPromptView.S5Enabled;
                    if (hidePromptViewS5 == true)
                    {
                        lblmsgViewPromptsS5.Visible = false;
                    }
                    else
                    {
                        lblmsgViewPromptsS5.Visible = true;
                    }
                    //read gHMIData.gHideDisplayElementPromptView.S6Enabled for prompts
                    //bool hidePromptViewS6 = ReadBoolArray("gHMIData.gHideDisplayElementPromptView.S6Enabled", 1)[0];
                    bool hidePromptViewS6 = gHMI.gHideDisplayElementPromptView.S6Enabled;
                    if (hidePromptViewS6 == true)
                    {
                        lblmsgViewPromptsS6.Visible = false;
                    }
                    else
                    {
                        lblmsgViewPromptsS6.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS6.Prompts.topMessage
                        //lblmsgViewPromptsS6.Text = ReadPlcString("GlobalMessages.gMsgS6.Prompts.topMessage");
                        lblmsgViewPromptsS6.Text = gMsgs.gMsgS6.Prompts.topMessage;

                    }

                    //now the same for warnings
                    //read gHMIData.gHideDisplayElementWarningView.McEnabled
                    //bool hideWarningView = ReadBoolArray("gHMIData.gHideDisplayElementWarningView.McEnabled", 1)[0];
                    bool hideWarningView = gHMI.gHideDisplayElementWarningView.McEnabled;
                    if (hideWarningView == true)
                    {
                        lblmsgViewWarningMachine.Visible = false;
                    }
                    else
                    {
                        lblmsgViewWarningMachine.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgMc.Warning.topMessage
                        //lblmsgViewWarningMachine.Text = ReadPlcString("GlobalMessages.gMsgMc.Warning.topMessage");
                        lblmsgViewWarningMachine.Text = gMsgs.gMsgMc.Warning.topMessage;

                    }
                    //read gHMIData.gHideDisplayElementWarningView.S1Enabled
                    //bool hideWarningViewS1 = ReadBoolArray("gHMIData.gHideDisplayElementWarningView.S1Enabled", 1)[0];
                    bool hideWarningViewS1 = gHMI.gHideDisplayElementWarningView.S1Enabled;

                    if (hideWarningViewS1 == true)
                    {
                        lblmsgViewWarningS1.Visible = false;
                    }
                    else
                    {
                        lblmsgViewWarningS1.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS1.Warning.topMessage
                        //lblmsgViewWarningS1.Text = ReadPlcString("GlobalMessages.gMsgS1.Warning.topMessage");
                        lblmsgViewWarningS1.Text = gMsgs.gMsgS1.Warning.topMessage;

                    }
                    //read gHMIData.gHideDisplayElementWarningView.S2Enabled
                    //bool hideWarningViewS2 = ReadBoolArray("gHMIData.gHideDisplayElementWarningView.S2Enabled", 1)[0];
                    bool hideWarningViewS2 = gHMI.gHideDisplayElementWarningView.S2Enabled;
                    if (hideWarningViewS2 == true)
                    {
                        lblmsgViewWarningS2.Visible = false;
                    }
                    else
                    {
                        lblmsgViewWarningS2.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS2.Warning.topMessage
                        //lblmsgViewWarningS2.Text = ReadPlcString("GlobalMessages.gMsgS2.Warning.topMessage");
                        lblmsgViewWarningS2.Text = gMsgs.gMsgS2.Warning.topMessage;

                    }
                    //read gHMIData.gHideDisplayElementWarningView.S3Enabled
                    //bool hideWarningViewS3 = ReadBoolArray("gHMIData.gHideDisplayElementWarningView.S3Enabled", 1)[0];
                    bool hideWarningViewS3 = gHMI.gHideDisplayElementWarningView.S3Enabled;
                    if (hideWarningViewS3 == true)
                    {
                        lblmsgViewWarningS3.Visible = false;
                    }
                    else
                    {
                        lblmsgViewWarningS3.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS3.Warning.topMessage
                        //lblmsgViewWarningS3.Text = ReadPlcString("GlobalMessages.gMsgS3.Warning.topMessage");
                        lblmsgViewWarningS3.Text = gMsgs.gMsgS3.Warning.topMessage;

                    }
                    //read gHMIData.gHideDisplayElementWarningView.S4Enabled
                    //bool hideWarningViewS4 = ReadBoolArray("gHMIData.gHideDisplayElementWarningView.S4Enabled", 1)[0];
                    bool hideWarningViewS4 = gHMI.gHideDisplayElementWarningView.S4Enabled;
                    if (hideWarningViewS4 == true)
                    {
                        lblmsgViewWarningS4.Visible = false;
                    }
                    else
                    {
                        lblmsgViewWarningS4.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS4.Warning.topMessage
                        //lblmsgViewWarningS4.Text = ReadPlcString("GlobalMessages.gMsgS4.Warning.topMessage");
                        lblmsgViewWarningS4.Text = gMsgs.gMsgS4.Warning.topMessage;

                    }
                    //read gHMIData.gHideDisplayElementWarningView.S5Enabled
                    //bool hideWarningViewS5 = ReadBoolArray("gHMIData.gHideDisplayElementWarningView.S5Enabled", 1)[0];
                    bool hideWarningViewS5 = gHMI.gHideDisplayElementWarningView.S5Enabled;
                    if (hideWarningViewS5 == true)
                    {
                        lblmsgViewWarningS5.Visible = false;
                    }
                    else
                    {
                        lblmsgViewWarningS5.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS5.Warning.topMessage
                        //lblmsgViewWarningS5.Text = ReadPlcString("GlobalMessages.gMsgS5.Warning.topMessage");
                        lblmsgViewWarningS5.Text = gMsgs.gMsgS5.Warning.topMessage;

                    }
                    //read gHMIData.gHideDisplayElementWarningView.S6Enabled
                    //bool hideWarningViewS6 = ReadBoolArray("gHMIData.gHideDisplayElementWarningView.S6Enabled", 1)[0];
                    bool hideWarningViewS6 = gHMI.gHideDisplayElementWarningView.S6Enabled;
                    if (hideWarningViewS6 == true)
                    {
                        lblmsgViewWarningS6.Visible = false;
                    }
                    else
                    {
                        lblmsgViewWarningS6.Visible = true;
                        //set the lbl to the string GlobalMessages.gMsgS6.Warning.topMessage
                        //lblmsgViewWarningS6.Text = ReadPlcString("GlobalMessages.gMsgS6.Warning.topMessage");
                        lblmsgViewWarningS6.Text = gMsgs.gMsgS6.Warning.topMessage;

                    }

                    //check warnings status from PLC from  .isAnyWarningState  
                    //bool isAnyWarningState = ReadBoolArray("gHMIData.hmiHeader.isAnyWarningState", 1)[0];
                    bool isAnyWarningState = gHMI.hmiHeader.isAnyWarningState;
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
                        //int anyStationWarningHeader = ReadInt16("gHMIData.hmiHeader.AnyStationWarningHeader");
                        int anyStationWarningHeader = gHMI.hmiHeader.AnyStationWarningHeader;
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
                    //bool isHomeFdbk = ReadBoolArray("gHMIButtons.btnFdbk.btnIsHomeFdbk", 1)[0];
                    bool isHomeFdbk = gbtns.btnFdbk.btnIsHomeFdbk;
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
                    //bool autoCyclingFdbk = ReadBoolArray("gHMIButtons.btnFdbk.btnAutoCyclingFdbk", 1)[0];
                    bool autoCyclingFdbk = gbtns.btnFdbk.btnAutoCyclingFdbk;
                    if (autoCyclingFdbk == true)
                    {
                        btnAutoCycleStart.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        btnAutoCycleStart.BackColor = SystemColors.Control;
                    }

                    //read power on status from Mc_Global.PowerOnFdbk
                    bool powerOnFdbk = adsIO.ReadBoolArray("Mc_Global.PowerOnFdbk", 1, _adsClient)[0];
                    //bool powerOnFdbk = gbtns.btnModes.PowerOnFdbk;
                    if (powerOnFdbk == true)
                    {
                        btnPowerOn.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        btnPowerOn.BackColor = SystemColors.Control;
                    }

                    //read all gHMIButtons.btnFdbk, which is 40 bools into gButtonFdbk array
                    // var buttonFdbkValues = ReadBoolArray("gHMIButtons.btnFdbk", 32);
                    bool[] buttonFdbkValues;
                    //gbtns.btnFdbk contains multiple bools inside it, so we need to read it into a bool array called buttonFdbkValues
                    buttonFdbkValues = new bool[40];
                    //for the length of the structure of btnFdbk, we need to read each bool into the array using a for loop
                    for (int i = 0; i < 40; i++)
                    {
                        //use reflection to get the value of each bool inside the btnFdbk structure
                        var propertyInfo = gbtns.btnFdbk.GetType().GetProperty($"btn{i}");
                        if (propertyInfo != null)
                        {
                            buttonFdbkValues[i] = (bool)propertyInfo.GetValue(gbtns.btnFdbk);
                        }
                    }

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
                    //var buttonHidesValues = ReadBoolArray("gHMIButtons.btnHides", 32);

                    //  dynamic gbtnHides = gTOASTHMI.gData.btns.btnHides.ReadValue();
                    //gbtnHides contains multiple bytes inside it, so we need to read it into a bool array called buttonHidesValues

                    // bool[] buttonHidesValues = gTOASTHMI.gData.btns.btnHides.ReadValue();
                    bool[] buttonHidesValues;

                    // using System.Linq;
                    // Read dynamic wrapper

                    buttonHidesValues = adsIO.ReadBoolArray("gHMIButtons.btnHides", 40, _adsClient);


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
                    //var enabledValues = ReadBoolArray("gHMIData.gStationEnabled", 6);
                    var enabledValues = gHMI.gStationEnabled;
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



                    //var values = ReadBoolArray("gHMIData.gStationSelected", 6);
                    var values = gHMI.gStationSelected;
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
                        //int stationState = ReadInt16("gHMIData.hmiHeader.stationstate");
                        int stationState = gHMI.hmiHeader.stationstate;


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
                        //int cycletypefeedback = ReadInt16("gHMIData.hmiHeader.cycleTypeFeedback");
                        int cycletypefeedback = gHMI.hmiHeader.cycleTypeFeedback;
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
                        //int faultStateHeader = ReadInt16("gHMIData.hmiHeader.FaultStateHeader");
                        int faultStateHeader = gHMI.hmiHeader.FaultStateHeader;

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
                        //int homestate = ReadInt16("gHMIData.hmiHeader.homestate");
                        int homestate = gHMI.hmiHeader.homestate;

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
                        //int stationName = ReadInt16("gHMIData.hmiHeader.stationNameSelect");
                        int stationName = gHMI.hmiHeader.stationNameSelect;
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


                        //update manual row's usrcont from plc
                        UpdateAllUsrcontRowsFromPlc();

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
                    RequestCoil = adsIO.ReadBool($"{prefix}.RequestCoil", _adsClient),
                    Depth = adsIO.ReadBool($"{prefix}.Depth", _adsClient),
                    Prompt = adsIO.ReadBool($"{prefix}.Prompt", _adsClient),
                    InterlockOK = adsIO.ReadBool($"{prefix}.InterlockOK", _adsClient),
                    NumberOrder = adsIO.ReadInt16($"{prefix}.NumberOrder", _adsClient),
                    TimeTaken = adsIO.ReadUInt32($"{prefix}.TimeTaken", _adsClient),
                    ValCoil = adsIO.ReadInt16($"{prefix}.valCoil", _adsClient),
                    ValDepth = adsIO.ReadInt16($"{prefix}.valDepth", _adsClient),
                    HideCoil = adsIO.ReadBool($"{prefix}.bHideCoil", _adsClient),
                    HideDepth = adsIO.ReadBool($"{prefix}.bHideDepth", _adsClient),
                    HideInterlock = adsIO.ReadBool($"{prefix}.bHideInterlock", _adsClient),
                    HidePrompt = adsIO.ReadBool($"{prefix}.bHidePrompt", _adsClient),
                    HideTime = adsIO.ReadBool($"{prefix}.bHideTime", _adsClient),
                    HideButton = adsIO.ReadBool($"{prefix}.bHideButton", _adsClient),
                    FdbkColour = adsIO.ReadUInt32($"{prefix}.FdbkColour", _adsClient),
                    CoilColour = adsIO.ReadUInt32($"{prefix}.CoilColour", _adsClient)
                };
            }

            var row = new MotionRowDto
            {
                Advance = ReadSide("Advance"),
                Return = ReadSide("Returned"),
                StrPosn = adsIO.ReadPlcString($"{baseSym}.strPosn", 80, _adsClient),
                IndexLocation = adsIO.ReadInt16($"{baseSym}.IndexLocation", _adsClient),
                HidePosn = adsIO.ReadBool($"{baseSym}.bHidePosn", _adsClient),
                HideName = adsIO.ReadBool($"{baseSym}.bHideName", _adsClient),
                IsAbsSymSwitch = adsIO.ReadBool($"{baseSym}.bIsAbsSymSwitch", _adsClient)
            };


            return row;
        }

        private void UpdateUsrcontRowFromMotionRow(usrcontRow rowCtrl, typeMotionRow typeMotionRow)
        {
            // Buttons visibility
            rowCtrl.ShowAdvanceButton = !typeMotionRow.Advance.bHideButton;
            rowCtrl.ShowReturnButton = !typeMotionRow.Return.bHideButton;
            rowCtrl.ShowAdvanceLabel = !typeMotionRow.Advance.bHideCoil;

            //and so on
            rowCtrl.AdvanceName = typeMotionRow.Advance.CoilName;
            rowCtrl.AdvancedName = typeMotionRow.Advance.DepthName;

            rowCtrl.ReturnName = typeMotionRow.Return.CoilName;
            rowCtrl.ReturnedName = typeMotionRow.Return.DepthName;

            rowCtrl.PositionText = typeMotionRow.strPosn;

            //RowName
            rowCtrl.RowName = typeMotionRow.MotionName;



            if (typeMotionRow.Advance.Depth)
            {
                rowCtrl.AdvanceNameBackColor = Color.LightGreen;
            }
            else
            {
                rowCtrl.AdvanceNameBackColor = Color.LightGray;
            }

            if (typeMotionRow.Advance.RequestCoil)
            {
                rowCtrl.AdvancedNameBackColor = Color.LightGreen;
            }
            else
            {
                rowCtrl.AdvancedNameBackColor = Color.LightGray;
            }

            if (typeMotionRow.Return.Depth)
            {
                rowCtrl.ReturnedNameBackColor = Color.LightGreen;
            }
            else
            {
                rowCtrl.ReturnedNameBackColor = Color.LightGray;
            }

            if (typeMotionRow.Return.RequestCoil)
            {
                rowCtrl.ReturnNameBackColor = Color.LightGreen;
            }
            else
            {
                rowCtrl.ReturnNameBackColor = Color.LightGray;
            }
        }

        private void UpdateAllUsrcontRowsFromPlc()
        {

            //read the structure of PLC data containing all manual rows
            //gHMIMotionRows.gMotionRows

            var symbolLoader = (IDynamicSymbolLoader)SymbolLoaderFactory.Create
                 (
                     _adsClient,
                     new SymbolLoaderSettings(SymbolsLoadMode.DynamicTree)
                 );

            var symbols = (DynamicSymbolsCollection)symbolLoader.SymbolsDynamic;

            //assign the symbols of gHMIMotionRows to a dynamic variable
            dynamic gHMIMotionRows = symbols["gHMIMotionRows"];

            //pick out the gHMI and gButtons
            dynamic gMotionRows = gHMIMotionRows.gMotionRows.ReadValue();

            typeMotionRow manrow1 = new()
            {
                Advance = new typeMotionSide(),
                Return = new typeMotionSide()
            };

            manrow1.Advance.RequestCoil = gMotionRows.gMotionRow1.Advance.RequestCoil;
            manrow1.Advance.Depth = gMotionRows.gMotionRow1.Advance.Depth;
            manrow1.Advance.Prompt = gMotionRows.gMotionRow1.Advance.Prompt;
            manrow1.Advance.InterlockOK = gMotionRows.gMotionRow1.Advance.InterlockOK;
            manrow1.Advance.NumberOrder = gMotionRows.gMotionRow1.Advance.NumberOrder;

            manrow1.Advance.TimeTaken = gMotionRows.gMotionRow1.Advance.TimeTaken;
            manrow1.Advance.valCoil = gMotionRows.gMotionRow1.Advance.valCoil;
            manrow1.Advance.valDepth = gMotionRows.gMotionRow1.Advance.valDepth;

            manrow1.Advance.bHideCoil = gMotionRows.gMotionRow1.Advance.bHideCoil;
            manrow1.Advance.bHideDepth = gMotionRows.gMotionRow1.Advance.bHideDepth;
            manrow1.Advance.bHideInterlock = gMotionRows.gMotionRow1.Advance.bHideInterlock;
            manrow1.Advance.bHidePrompt = gMotionRows.gMotionRow1.Advance.bHidePrompt;
            manrow1.Advance.bHideTime = gMotionRows.gMotionRow1.Advance.bHideTime;
            manrow1.Advance.bHideButton = gMotionRows.gMotionRow1.Advance.bHideButton;

            manrow1.Advance.FdbkColour = gMotionRows.gMotionRow1.Advance.FdbkColour;
            manrow1.Advance.CoilColour = gMotionRows.gMotionRow1.Advance.CoilColour;

            manrow1.Return.RequestCoil = gMotionRows.gMotionRow1.Returned.RequestCoil;
            manrow1.Return.Depth = gMotionRows.gMotionRow1.Returned.Depth;
            manrow1.Return.Prompt = gMotionRows.gMotionRow1.Returned.Prompt;
            manrow1.Return.InterlockOK = gMotionRows.gMotionRow1.Returned.InterlockOK;
            manrow1.Return.NumberOrder = gMotionRows.gMotionRow1.Returned.NumberOrder;

            manrow1.Return.TimeTaken = gMotionRows.gMotionRow1.Returned.TimeTaken;
            manrow1.Return.valCoil = gMotionRows.gMotionRow1.Returned.valCoil;
            manrow1.Return.valDepth = gMotionRows.gMotionRow1.Returned.valDepth;
            manrow1.Return.bHideCoil = gMotionRows.gMotionRow1.Returned.bHideCoil;
            manrow1.Return.bHideDepth = gMotionRows.gMotionRow1.Returned.bHideDepth;
            manrow1.Return.bHideInterlock = gMotionRows.gMotionRow1.Returned.bHideInterlock;
            manrow1.Return.bHidePrompt = gMotionRows.gMotionRow1.Returned.bHidePrompt;
            manrow1.Return.bHideTime = gMotionRows.gMotionRow1.Returned.bHideTime;
            manrow1.Return.bHideButton = gMotionRows.gMotionRow1.Returned.bHideButton;
            manrow1.Return.FdbkColour = gMotionRows.gMotionRow1.Returned.FdbkColour;
            manrow1.Return.CoilColour = gMotionRows.gMotionRow1.Returned.CoilColour;

            manrow1.strPosn = gMotionRows.gMotionRow1.strPosn;
            manrow1.IndexLocation = gMotionRows.gMotionRow1.IndexLocation;
            manrow1.bHidePosn = gMotionRows.gMotionRow1.bHidePosn;
            manrow1.bHideName = gMotionRows.gMotionRow1.bHideName;
            manrow1.bIsAbsSymSwitch = gMotionRows.gMotionRow1.bIsAbsSymSwitch;

            UpdateUsrcontRowFromMotionRow(usrcontRow1, manrow1);


            typeMotionRow manrow2 = new()
            {
                Advance = new typeMotionSide(),
                Return = new typeMotionSide()
            };

            manrow2.Advance.RequestCoil = gMotionRows.gMotionRow2.Advance.RequestCoil;
            manrow2.Advance.Depth = gMotionRows.gMotionRow2.Advance.Depth;
            manrow2.Advance.Prompt = gMotionRows.gMotionRow2.Advance.Prompt;
            manrow2.Advance.InterlockOK = gMotionRows.gMotionRow2.Advance.InterlockOK;
            manrow2.Advance.NumberOrder = gMotionRows.gMotionRow2.Advance.NumberOrder;

            manrow2.Advance.TimeTaken = gMotionRows.gMotionRow2.Advance.TimeTaken;
            manrow2.Advance.valCoil = gMotionRows.gMotionRow2.Advance.valCoil;
            manrow2.Advance.valDepth = gMotionRows.gMotionRow2.Advance.valDepth;

            manrow2.Advance.bHideCoil = gMotionRows.gMotionRow2.Advance.bHideCoil;
            manrow2.Advance.bHideDepth = gMotionRows.gMotionRow2.Advance.bHideDepth;
            manrow2.Advance.bHideInterlock = gMotionRows.gMotionRow2.Advance.bHideInterlock;
            manrow2.Advance.bHidePrompt = gMotionRows.gMotionRow2.Advance.bHidePrompt;
            manrow2.Advance.bHideTime = gMotionRows.gMotionRow2.Advance.bHideTime;
            manrow2.Advance.bHideButton = gMotionRows.gMotionRow2.Advance.bHideButton;

            manrow2.Advance.FdbkColour = gMotionRows.gMotionRow2.Advance.FdbkColour;
            manrow2.Advance.CoilColour = gMotionRows.gMotionRow2.Advance.CoilColour;

            manrow2.Return.RequestCoil = gMotionRows.gMotionRow2.Returned.RequestCoil;
            manrow2.Return.Depth = gMotionRows.gMotionRow2.Returned.Depth;
            manrow2.Return.Prompt = gMotionRows.gMotionRow2.Returned.Prompt;
            manrow2.Return.InterlockOK = gMotionRows.gMotionRow2.Returned.InterlockOK;
            manrow2.Return.NumberOrder = gMotionRows.gMotionRow2.Returned.NumberOrder;

            manrow2.Return.TimeTaken = gMotionRows.gMotionRow2.Returned.TimeTaken;
            manrow2.Return.valCoil = gMotionRows.gMotionRow2.Returned.valCoil;
            manrow2.Return.valDepth = gMotionRows.gMotionRow2.Returned.valDepth;
            manrow2.Return.bHideCoil = gMotionRows.gMotionRow2.Returned.bHideCoil;
            manrow2.Return.bHideDepth = gMotionRows.gMotionRow2.Returned.bHideDepth;
            manrow2.Return.bHideInterlock = gMotionRows.gMotionRow2.Returned.bHideInterlock;
            manrow2.Return.bHidePrompt = gMotionRows.gMotionRow2.Returned.bHidePrompt;
            manrow2.Return.bHideTime = gMotionRows.gMotionRow2.Returned.bHideTime;
            manrow2.Return.bHideButton = gMotionRows.gMotionRow2.Returned.bHideButton;
            manrow2.Return.FdbkColour = gMotionRows.gMotionRow2.Returned.FdbkColour;
            manrow2.Return.CoilColour = gMotionRows.gMotionRow2.Returned.CoilColour;

            manrow2.strPosn = gMotionRows.gMotionRow2.strPosn;
            manrow2.IndexLocation = gMotionRows.gMotionRow2.IndexLocation;
            manrow2.bHidePosn = gMotionRows.gMotionRow2.bHidePosn;
            manrow2.bHideName = gMotionRows.gMotionRow2.bHideName;
            manrow2.bIsAbsSymSwitch = gMotionRows.gMotionRow2.bIsAbsSymSwitch;

            UpdateUsrcontRowFromMotionRow(usrcontRow2, manrow2);

            typeMotionRow manrow3 = new()
            {
                Advance = new typeMotionSide(),
                Return = new typeMotionSide()
            };

            manrow3.Advance.RequestCoil = gMotionRows.gMotionRow3.Advance.RequestCoil;
            manrow3.Advance.Depth = gMotionRows.gMotionRow3.Advance.Depth;
            manrow3.Advance.Prompt = gMotionRows.gMotionRow3.Advance.Prompt;
            manrow3.Advance.InterlockOK = gMotionRows.gMotionRow3.Advance.InterlockOK;
            manrow3.Advance.NumberOrder = gMotionRows.gMotionRow3.Advance.NumberOrder;

            manrow3.Advance.TimeTaken = gMotionRows.gMotionRow3.Advance.TimeTaken;
            manrow3.Advance.valCoil = gMotionRows.gMotionRow3.Advance.valCoil;
            manrow3.Advance.valDepth = gMotionRows.gMotionRow3.Advance.valDepth;

            manrow3.Advance.bHideCoil = gMotionRows.gMotionRow3.Advance.bHideCoil;
            manrow3.Advance.bHideDepth = gMotionRows.gMotionRow3.Advance.bHideDepth;
            manrow3.Advance.bHideInterlock = gMotionRows.gMotionRow3.Advance.bHideInterlock;
            manrow3.Advance.bHidePrompt = gMotionRows.gMotionRow3.Advance.bHidePrompt;
            manrow3.Advance.bHideTime = gMotionRows.gMotionRow3.Advance.bHideTime;
            manrow3.Advance.bHideButton = gMotionRows.gMotionRow3.Advance.bHideButton;

            manrow3.Advance.FdbkColour = gMotionRows.gMotionRow3.Advance.FdbkColour;
            manrow3.Advance.CoilColour = gMotionRows.gMotionRow3.Advance.CoilColour;

            manrow3.Return.RequestCoil = gMotionRows.gMotionRow3.Returned.RequestCoil;
            manrow3.Return.Depth = gMotionRows.gMotionRow3.Returned.Depth;
            manrow3.Return.Prompt = gMotionRows.gMotionRow3.Returned.Prompt;
            manrow3.Return.InterlockOK = gMotionRows.gMotionRow3.Returned.InterlockOK;
            manrow3.Return.NumberOrder = gMotionRows.gMotionRow3.Returned.NumberOrder;

            manrow3.Return.TimeTaken = gMotionRows.gMotionRow3.Returned.TimeTaken;
            manrow3.Return.valCoil = gMotionRows.gMotionRow3.Returned.valCoil;
            manrow3.Return.valDepth = gMotionRows.gMotionRow3.Returned.valDepth;
            manrow3.Return.bHideCoil = gMotionRows.gMotionRow3.Returned.bHideCoil;
            manrow3.Return.bHideDepth = gMotionRows.gMotionRow3.Returned.bHideDepth;
            manrow3.Return.bHideInterlock = gMotionRows.gMotionRow3.Returned.bHideInterlock;
            manrow3.Return.bHidePrompt = gMotionRows.gMotionRow3.Returned.bHidePrompt;
            manrow3.Return.bHideTime = gMotionRows.gMotionRow3.Returned.bHideTime;
            manrow3.Return.bHideButton = gMotionRows.gMotionRow3.Returned.bHideButton;
            manrow3.Return.FdbkColour = gMotionRows.gMotionRow3.Returned.FdbkColour;
            manrow3.Return.CoilColour = gMotionRows.gMotionRow3.Returned.CoilColour;

            manrow3.strPosn = gMotionRows.gMotionRow3.strPosn;
            manrow3.IndexLocation = gMotionRows.gMotionRow3.IndexLocation;
            manrow3.bHidePosn = gMotionRows.gMotionRow3.bHidePosn;
            manrow3.bHideName = gMotionRows.gMotionRow3.bHideName;
            manrow3.bIsAbsSymSwitch = gMotionRows.gMotionRow3.bIsAbsSymSwitch;

            UpdateUsrcontRowFromMotionRow(usrcontRow3, manrow3);

            typeMotionRow manrow4 = new()
            {
                Advance = new typeMotionSide(),
                Return = new typeMotionSide()
            };

            manrow4.Advance.RequestCoil = gMotionRows.gMotionRow4.Advance.RequestCoil;
            manrow4.Advance.Depth = gMotionRows.gMotionRow4.Advance.Depth;
            manrow4.Advance.Prompt = gMotionRows.gMotionRow4.Advance.Prompt;
            manrow4.Advance.InterlockOK = gMotionRows.gMotionRow4.Advance.InterlockOK;
            manrow4.Advance.NumberOrder = gMotionRows.gMotionRow4.Advance.NumberOrder;

            manrow4.Advance.TimeTaken = gMotionRows.gMotionRow4.Advance.TimeTaken;
            manrow4.Advance.valCoil = gMotionRows.gMotionRow4.Advance.valCoil;
            manrow4.Advance.valDepth = gMotionRows.gMotionRow4.Advance.valDepth;

            manrow4.Advance.bHideCoil = gMotionRows.gMotionRow4.Advance.bHideCoil;
            manrow4.Advance.bHideDepth = gMotionRows.gMotionRow4.Advance.bHideDepth;
            manrow4.Advance.bHideInterlock = gMotionRows.gMotionRow4.Advance.bHideInterlock;
            manrow4.Advance.bHidePrompt = gMotionRows.gMotionRow4.Advance.bHidePrompt;
            manrow4.Advance.bHideTime = gMotionRows.gMotionRow4.Advance.bHideTime;
            manrow4.Advance.bHideButton = gMotionRows.gMotionRow4.Advance.bHideButton;

            manrow4.Advance.FdbkColour = gMotionRows.gMotionRow4.Advance.FdbkColour;
            manrow4.Advance.CoilColour = gMotionRows.gMotionRow4.Advance.CoilColour;

            manrow4.Return.RequestCoil = gMotionRows.gMotionRow4.Returned.RequestCoil;
            manrow4.Return.Depth = gMotionRows.gMotionRow4.Returned.Depth;
            manrow4.Return.Prompt = gMotionRows.gMotionRow4.Returned.Prompt;
            manrow4.Return.InterlockOK = gMotionRows.gMotionRow4.Returned.InterlockOK;
            manrow4.Return.NumberOrder = gMotionRows.gMotionRow4.Returned.NumberOrder;

            manrow4.Return.TimeTaken = gMotionRows.gMotionRow4.Returned.TimeTaken;
            manrow4.Return.valCoil = gMotionRows.gMotionRow4.Returned.valCoil;
            manrow4.Return.valDepth = gMotionRows.gMotionRow4.Returned.valDepth;
            manrow4.Return.bHideCoil = gMotionRows.gMotionRow4.Returned.bHideCoil;
            manrow4.Return.bHideDepth = gMotionRows.gMotionRow4.Returned.bHideDepth;
            manrow4.Return.bHideInterlock = gMotionRows.gMotionRow4.Returned.bHideInterlock;
            manrow4.Return.bHidePrompt = gMotionRows.gMotionRow4.Returned.bHidePrompt;
            manrow4.Return.bHideTime = gMotionRows.gMotionRow4.Returned.bHideTime;
            manrow4.Return.bHideButton = gMotionRows.gMotionRow4.Returned.bHideButton;
            manrow4.Return.FdbkColour = gMotionRows.gMotionRow4.Returned.FdbkColour;
            manrow4.Return.CoilColour = gMotionRows.gMotionRow4.Returned.CoilColour;

            manrow4.strPosn = gMotionRows.gMotionRow4.strPosn;
            manrow4.IndexLocation = gMotionRows.gMotionRow4.IndexLocation;
            manrow4.bHidePosn = gMotionRows.gMotionRow4.bHidePosn;
            manrow4.bHideName = gMotionRows.gMotionRow4.bHideName;
            manrow4.bIsAbsSymSwitch = gMotionRows.gMotionRow4.bIsAbsSymSwitch;

            UpdateUsrcontRowFromMotionRow(usrcontRow4, manrow4);

            typeMotionRow manrow5 = new()
            {
                Advance = new typeMotionSide(),
                Return = new typeMotionSide()
            };

            manrow5.Advance.RequestCoil = gMotionRows.gMotionRow5.Advance.RequestCoil;
            manrow5.Advance.Depth = gMotionRows.gMotionRow5.Advance.Depth;
            manrow5.Advance.Prompt = gMotionRows.gMotionRow5.Advance.Prompt;
            manrow5.Advance.InterlockOK = gMotionRows.gMotionRow5.Advance.InterlockOK;
            manrow5.Advance.NumberOrder = gMotionRows.gMotionRow5.Advance.NumberOrder;

            manrow5.Advance.TimeTaken = gMotionRows.gMotionRow5.Advance.TimeTaken;
            manrow5.Advance.valCoil = gMotionRows.gMotionRow5.Advance.valCoil;
            manrow5.Advance.valDepth = gMotionRows.gMotionRow5.Advance.valDepth;

            manrow5.Advance.bHideCoil = gMotionRows.gMotionRow5.Advance.bHideCoil;
            manrow5.Advance.bHideDepth = gMotionRows.gMotionRow5.Advance.bHideDepth;
            manrow5.Advance.bHideInterlock = gMotionRows.gMotionRow5.Advance.bHideInterlock;
            manrow5.Advance.bHidePrompt = gMotionRows.gMotionRow5.Advance.bHidePrompt;
            manrow5.Advance.bHideTime = gMotionRows.gMotionRow5.Advance.bHideTime;
            manrow5.Advance.bHideButton = gMotionRows.gMotionRow5.Advance.bHideButton;

            manrow5.Advance.FdbkColour = gMotionRows.gMotionRow5.Advance.FdbkColour;
            manrow5.Advance.CoilColour = gMotionRows.gMotionRow5.Advance.CoilColour;

            manrow5.Return.RequestCoil = gMotionRows.gMotionRow5.Returned.RequestCoil;
            manrow5.Return.Depth = gMotionRows.gMotionRow5.Returned.Depth;
            manrow5.Return.Prompt = gMotionRows.gMotionRow5.Returned.Prompt;
            manrow5.Return.InterlockOK = gMotionRows.gMotionRow5.Returned.InterlockOK;
            manrow5.Return.NumberOrder = gMotionRows.gMotionRow5.Returned.NumberOrder;

            manrow5.Return.TimeTaken = gMotionRows.gMotionRow5.Returned.TimeTaken;
            manrow5.Return.valCoil = gMotionRows.gMotionRow5.Returned.valCoil;
            manrow5.Return.valDepth = gMotionRows.gMotionRow5.Returned.valDepth;
            manrow5.Return.bHideCoil = gMotionRows.gMotionRow5.Returned.bHideCoil;
            manrow5.Return.bHideDepth = gMotionRows.gMotionRow5.Returned.bHideDepth;
            manrow5.Return.bHideInterlock = gMotionRows.gMotionRow5.Returned.bHideInterlock;
            manrow5.Return.bHidePrompt = gMotionRows.gMotionRow5.Returned.bHidePrompt;
            manrow5.Return.bHideTime = gMotionRows.gMotionRow5.Returned.bHideTime;
            manrow5.Return.bHideButton = gMotionRows.gMotionRow5.Returned.bHideButton;
            manrow5.Return.FdbkColour = gMotionRows.gMotionRow5.Returned.FdbkColour;
            manrow5.Return.CoilColour = gMotionRows.gMotionRow5.Returned.CoilColour;

            manrow5.strPosn = gMotionRows.gMotionRow5.strPosn;
            manrow5.IndexLocation = gMotionRows.gMotionRow5.IndexLocation;
            manrow5.bHidePosn = gMotionRows.gMotionRow5.bHidePosn;
            manrow5.bHideName = gMotionRows.gMotionRow5.bHideName;
            manrow5.bIsAbsSymSwitch = gMotionRows.gMotionRow5.bIsAbsSymSwitch;

            UpdateUsrcontRowFromMotionRow(usrcontRow5, manrow5);

            typeMotionRow manrow6 = new()
            {
                Advance = new typeMotionSide(),
                Return = new typeMotionSide()
            };

            manrow6.Advance.RequestCoil = gMotionRows.gMotionRow6.Advance.RequestCoil;
            manrow6.Advance.Depth = gMotionRows.gMotionRow6.Advance.Depth;
            manrow6.Advance.Prompt = gMotionRows.gMotionRow6.Advance.Prompt;
            manrow6.Advance.InterlockOK = gMotionRows.gMotionRow6.Advance.InterlockOK;
            manrow6.Advance.NumberOrder = gMotionRows.gMotionRow6.Advance.NumberOrder;

            manrow6.Advance.TimeTaken = gMotionRows.gMotionRow6.Advance.TimeTaken;
            manrow6.Advance.valCoil = gMotionRows.gMotionRow6.Advance.valCoil;
            manrow6.Advance.valDepth = gMotionRows.gMotionRow6.Advance.valDepth;

            manrow6.Advance.bHideCoil = gMotionRows.gMotionRow6.Advance.bHideCoil;
            manrow6.Advance.bHideDepth = gMotionRows.gMotionRow6.Advance.bHideDepth;
            manrow6.Advance.bHideInterlock = gMotionRows.gMotionRow6.Advance.bHideInterlock;
            manrow6.Advance.bHidePrompt = gMotionRows.gMotionRow6.Advance.bHidePrompt;
            manrow6.Advance.bHideTime = gMotionRows.gMotionRow6.Advance.bHideTime;
            manrow6.Advance.bHideButton = gMotionRows.gMotionRow6.Advance.bHideButton;

            manrow6.Advance.FdbkColour = gMotionRows.gMotionRow6.Advance.FdbkColour;
            manrow6.Advance.CoilColour = gMotionRows.gMotionRow6.Advance.CoilColour;

            manrow6.Return.RequestCoil = gMotionRows.gMotionRow6.Returned.RequestCoil;
            manrow6.Return.Depth = gMotionRows.gMotionRow6.Returned.Depth;
            manrow6.Return.Prompt = gMotionRows.gMotionRow6.Returned.Prompt;
            manrow6.Return.InterlockOK = gMotionRows.gMotionRow6.Returned.InterlockOK;
            manrow6.Return.NumberOrder = gMotionRows.gMotionRow6.Returned.NumberOrder;

            manrow6.Return.TimeTaken = gMotionRows.gMotionRow6.Returned.TimeTaken;
            manrow6.Return.valCoil = gMotionRows.gMotionRow6.Returned.valCoil;
            manrow6.Return.valDepth = gMotionRows.gMotionRow6.Returned.valDepth;
            manrow6.Return.bHideCoil = gMotionRows.gMotionRow6.Returned.bHideCoil;
            manrow6.Return.bHideDepth = gMotionRows.gMotionRow6.Returned.bHideDepth;
            manrow6.Return.bHideInterlock = gMotionRows.gMotionRow6.Returned.bHideInterlock;
            manrow6.Return.bHidePrompt = gMotionRows.gMotionRow6.Returned.bHidePrompt;
            manrow6.Return.bHideTime = gMotionRows.gMotionRow6.Returned.bHideTime;
            manrow6.Return.bHideButton = gMotionRows.gMotionRow6.Returned.bHideButton;
            manrow6.Return.FdbkColour = gMotionRows.gMotionRow6.Returned.FdbkColour;
            manrow6.Return.CoilColour = gMotionRows.gMotionRow6.Returned.CoilColour;

            manrow6.strPosn = gMotionRows.gMotionRow6.strPosn;
            manrow6.IndexLocation = gMotionRows.gMotionRow6.IndexLocation;
            manrow6.bHidePosn = gMotionRows.gMotionRow6.bHidePosn;
            manrow6.bHideName = gMotionRows.gMotionRow6.bHideName;
            manrow6.bIsAbsSymSwitch = gMotionRows.gMotionRow6.bIsAbsSymSwitch;

            UpdateUsrcontRowFromMotionRow(usrcontRow6, manrow6);

            typeMotionRow manrow7 = new()
            {
                Advance = new typeMotionSide(),
                Return = new typeMotionSide()
            };

            manrow7.Advance.RequestCoil = gMotionRows.gMotionRow7.Advance.RequestCoil;
            manrow7.Advance.Depth = gMotionRows.gMotionRow7.Advance.Depth;
            manrow7.Advance.Prompt = gMotionRows.gMotionRow7.Advance.Prompt;
            manrow7.Advance.InterlockOK = gMotionRows.gMotionRow7.Advance.InterlockOK;
            manrow7.Advance.NumberOrder = gMotionRows.gMotionRow7.Advance.NumberOrder;

            manrow7.Advance.TimeTaken = gMotionRows.gMotionRow7.Advance.TimeTaken;
            manrow7.Advance.valCoil = gMotionRows.gMotionRow7.Advance.valCoil;
            manrow7.Advance.valDepth = gMotionRows.gMotionRow7.Advance.valDepth;

            manrow7.Advance.bHideCoil = gMotionRows.gMotionRow7.Advance.bHideCoil;
            manrow7.Advance.bHideDepth = gMotionRows.gMotionRow7.Advance.bHideDepth;
            manrow7.Advance.bHideInterlock = gMotionRows.gMotionRow7.Advance.bHideInterlock;
            manrow7.Advance.bHidePrompt = gMotionRows.gMotionRow7.Advance.bHidePrompt;
            manrow7.Advance.bHideTime = gMotionRows.gMotionRow7.Advance.bHideTime;
            manrow7.Advance.bHideButton = gMotionRows.gMotionRow7.Advance.bHideButton;

            manrow7.Advance.FdbkColour = gMotionRows.gMotionRow7.Advance.FdbkColour;
            manrow7.Advance.CoilColour = gMotionRows.gMotionRow7.Advance.CoilColour;

            manrow7.Return.RequestCoil = gMotionRows.gMotionRow7.Returned.RequestCoil;
            manrow7.Return.Depth = gMotionRows.gMotionRow7.Returned.Depth;
            manrow7.Return.Prompt = gMotionRows.gMotionRow7.Returned.Prompt;
            manrow7.Return.InterlockOK = gMotionRows.gMotionRow7.Returned.InterlockOK;
            manrow7.Return.NumberOrder = gMotionRows.gMotionRow7.Returned.NumberOrder;

            manrow7.Return.TimeTaken = gMotionRows.gMotionRow7.Returned.TimeTaken;
            manrow7.Return.valCoil = gMotionRows.gMotionRow7.Returned.valCoil;
            manrow7.Return.valDepth = gMotionRows.gMotionRow7.Returned.valDepth;
            manrow7.Return.bHideCoil = gMotionRows.gMotionRow7.Returned.bHideCoil;
            manrow7.Return.bHideDepth = gMotionRows.gMotionRow7.Returned.bHideDepth;
            manrow7.Return.bHideInterlock = gMotionRows.gMotionRow7.Returned.bHideInterlock;
            manrow7.Return.bHidePrompt = gMotionRows.gMotionRow7.Returned.bHidePrompt;
            manrow7.Return.bHideTime = gMotionRows.gMotionRow7.Returned.bHideTime;
            manrow7.Return.bHideButton = gMotionRows.gMotionRow7.Returned.bHideButton;
            manrow7.Return.FdbkColour = gMotionRows.gMotionRow7.Returned.FdbkColour;
            manrow7.Return.CoilColour = gMotionRows.gMotionRow7.Returned.CoilColour;

            manrow7.strPosn = gMotionRows.gMotionRow7.strPosn;
            manrow7.IndexLocation = gMotionRows.gMotionRow7.IndexLocation;
            manrow7.bHidePosn = gMotionRows.gMotionRow7.bHidePosn;
            manrow7.bHideName = gMotionRows.gMotionRow7.bHideName;
            manrow7.bIsAbsSymSwitch = gMotionRows.gMotionRow7.bIsAbsSymSwitch;

            UpdateUsrcontRowFromMotionRow(usrcontRow7, manrow7);

            typeMotionRow manrow8 = new()
            {
                Advance = new typeMotionSide(),
                Return = new typeMotionSide()
            };

            manrow8.Advance.RequestCoil = gMotionRows.gMotionRow8.Advance.RequestCoil;
            manrow8.Advance.Depth = gMotionRows.gMotionRow8.Advance.Depth;
            manrow8.Advance.Prompt = gMotionRows.gMotionRow8.Advance.Prompt;
            manrow8.Advance.InterlockOK = gMotionRows.gMotionRow8.Advance.InterlockOK;
            manrow8.Advance.NumberOrder = gMotionRows.gMotionRow8.Advance.NumberOrder;

            manrow8.Advance.TimeTaken = gMotionRows.gMotionRow8.Advance.TimeTaken;
            manrow8.Advance.valCoil = gMotionRows.gMotionRow8.Advance.valCoil;
            manrow8.Advance.valDepth = gMotionRows.gMotionRow8.Advance.valDepth;

            manrow8.Advance.bHideCoil = gMotionRows.gMotionRow8.Advance.bHideCoil;
            manrow8.Advance.bHideDepth = gMotionRows.gMotionRow8.Advance.bHideDepth;
            manrow8.Advance.bHideInterlock = gMotionRows.gMotionRow8.Advance.bHideInterlock;
            manrow8.Advance.bHidePrompt = gMotionRows.gMotionRow8.Advance.bHidePrompt;
            manrow8.Advance.bHideTime = gMotionRows.gMotionRow8.Advance.bHideTime;
            manrow8.Advance.bHideButton = gMotionRows.gMotionRow8.Advance.bHideButton;

            manrow8.Advance.FdbkColour = gMotionRows.gMotionRow8.Advance.FdbkColour;
            manrow8.Advance.CoilColour = gMotionRows.gMotionRow8.Advance.CoilColour;

            manrow8.Return.RequestCoil = gMotionRows.gMotionRow8.Returned.RequestCoil;
            manrow8.Return.Depth = gMotionRows.gMotionRow8.Returned.Depth;
            manrow8.Return.Prompt = gMotionRows.gMotionRow8.Returned.Prompt;
            manrow8.Return.InterlockOK = gMotionRows.gMotionRow8.Returned.InterlockOK;
            manrow8.Return.NumberOrder = gMotionRows.gMotionRow8.Returned.NumberOrder;

            manrow8.Return.TimeTaken = gMotionRows.gMotionRow8.Returned.TimeTaken;
            manrow8.Return.valCoil = gMotionRows.gMotionRow8.Returned.valCoil;
            manrow8.Return.valDepth = gMotionRows.gMotionRow8.Returned.valDepth;
            manrow8.Return.bHideCoil = gMotionRows.gMotionRow8.Returned.bHideCoil;
            manrow8.Return.bHideDepth = gMotionRows.gMotionRow8.Returned.bHideDepth;
            manrow8.Return.bHideInterlock = gMotionRows.gMotionRow8.Returned.bHideInterlock;
            manrow8.Return.bHidePrompt = gMotionRows.gMotionRow8.Returned.bHidePrompt;
            manrow8.Return.bHideTime = gMotionRows.gMotionRow8.Returned.bHideTime;
            manrow8.Return.bHideButton = gMotionRows.gMotionRow8.Returned.bHideButton;
            manrow8.Return.FdbkColour = gMotionRows.gMotionRow8.Returned.FdbkColour;
            manrow8.Return.CoilColour = gMotionRows.gMotionRow8.Returned.CoilColour;

            manrow8.strPosn = gMotionRows.gMotionRow8.strPosn;
            manrow8.IndexLocation = gMotionRows.gMotionRow8.IndexLocation;
            manrow8.bHidePosn = gMotionRows.gMotionRow8.bHidePosn;
            manrow8.bHideName = gMotionRows.gMotionRow8.bHideName;
            manrow8.bIsAbsSymSwitch = gMotionRows.gMotionRow8.bIsAbsSymSwitch;

            UpdateUsrcontRowFromMotionRow(usrcontRow8, manrow8);

            typeMotionRow manrow9 = new()
            {
                Advance = new typeMotionSide(),
                Return = new typeMotionSide()
            };

            manrow9.Advance.RequestCoil = gMotionRows.gMotionRow9.Advance.RequestCoil;
            manrow9.Advance.Depth = gMotionRows.gMotionRow9.Advance.Depth;
            manrow9.Advance.Prompt = gMotionRows.gMotionRow9.Advance.Prompt;
            manrow9.Advance.InterlockOK = gMotionRows.gMotionRow9.Advance.InterlockOK;
            manrow9.Advance.NumberOrder = gMotionRows.gMotionRow9.Advance.NumberOrder;

            manrow9.Advance.TimeTaken = gMotionRows.gMotionRow9.Advance.TimeTaken;
            manrow9.Advance.valCoil = gMotionRows.gMotionRow9.Advance.valCoil;
            manrow9.Advance.valDepth = gMotionRows.gMotionRow9.Advance.valDepth;

            manrow9.Advance.bHideCoil = gMotionRows.gMotionRow9.Advance.bHideCoil;
            manrow9.Advance.bHideDepth = gMotionRows.gMotionRow9.Advance.bHideDepth;
            manrow9.Advance.bHideInterlock = gMotionRows.gMotionRow9.Advance.bHideInterlock;
            manrow9.Advance.bHidePrompt = gMotionRows.gMotionRow9.Advance.bHidePrompt;
            manrow9.Advance.bHideTime = gMotionRows.gMotionRow9.Advance.bHideTime;
            manrow9.Advance.bHideButton = gMotionRows.gMotionRow9.Advance.bHideButton;

            manrow9.Advance.FdbkColour = gMotionRows.gMotionRow9.Advance.FdbkColour;
            manrow9.Advance.CoilColour = gMotionRows.gMotionRow9.Advance.CoilColour;

            manrow9.Return.RequestCoil = gMotionRows.gMotionRow9.Returned.RequestCoil;
            manrow9.Return.Depth = gMotionRows.gMotionRow9.Returned.Depth;
            manrow9.Return.Prompt = gMotionRows.gMotionRow9.Returned.Prompt;
            manrow9.Return.InterlockOK = gMotionRows.gMotionRow9.Returned.InterlockOK;
            manrow9.Return.NumberOrder = gMotionRows.gMotionRow9.Returned.NumberOrder;

            manrow9.Return.TimeTaken = gMotionRows.gMotionRow9.Returned.TimeTaken;
            manrow9.Return.valCoil = gMotionRows.gMotionRow9.Returned.valCoil;
            manrow9.Return.valDepth = gMotionRows.gMotionRow9.Returned.valDepth;
            manrow9.Return.bHideCoil = gMotionRows.gMotionRow9.Returned.bHideCoil;
            manrow9.Return.bHideDepth = gMotionRows.gMotionRow9.Returned.bHideDepth;
            manrow9.Return.bHideInterlock = gMotionRows.gMotionRow9.Returned.bHideInterlock;
            manrow9.Return.bHidePrompt = gMotionRows.gMotionRow9.Returned.bHidePrompt;
            manrow9.Return.bHideTime = gMotionRows.gMotionRow9.Returned.bHideTime;
            manrow9.Return.bHideButton = gMotionRows.gMotionRow9.Returned.bHideButton;
            manrow9.Return.FdbkColour = gMotionRows.gMotionRow9.Returned.FdbkColour;
            manrow9.Return.CoilColour = gMotionRows.gMotionRow9.Returned.CoilColour;

            manrow9.strPosn = gMotionRows.gMotionRow9.strPosn;
            manrow9.IndexLocation = gMotionRows.gMotionRow9.IndexLocation;
            manrow9.bHidePosn = gMotionRows.gMotionRow9.bHidePosn;
            manrow9.bHideName = gMotionRows.gMotionRow9.bHideName;
            manrow9.bIsAbsSymSwitch = gMotionRows.gMotionRow9.bIsAbsSymSwitch;

            UpdateUsrcontRowFromMotionRow(usrcontRow9, manrow9);

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
                            //   ?? GetPropertyString(symbolObj, "DataType")
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

        private void btnReadStruct2_Click(object sender, EventArgs e)
        {
            using (AdsClient client = new())
            {
                client.Connect(connectionData.amsNetId, connectionData.amsPort);
                var symbolLoader = (IDynamicSymbolLoader)SymbolLoaderFactory.Create
                (
                    client,
                    new SymbolLoaderSettings(SymbolsLoadMode.DynamicTree)
                );

                var symbols = (DynamicSymbolsCollection)symbolLoader.SymbolsDynamic;

                //assign the symbols of gTOASTHMI to a dynamic variable
                dynamic gTOASTHMI = symbols["gTOASTHMI"];

                //pick out the gHMI and gButtons
                dynamic gHMI = gTOASTHMI.gData.hmi.ReadValue();
                dynamic gbtns = gTOASTHMI.gData.btns.ReadValue();

                //gData now contains;
                //hmi: structHMI;
                //btns: structHMIBtns;



                Console.WriteLine("\nPress any key to exit...\n");
                // Console.ReadKey(true);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //read built in structure of TwinCAT_SystemInfoVarList

            if (isConnectionFaulted == false)
            {
                try
                {
                    var symbolLoader = (IDynamicSymbolLoader)SymbolLoaderFactory.Create
                      (
                          _adsClient,
                          new SymbolLoaderSettings(SymbolsLoadMode.DynamicTree)
                      );

                    var symbols = (DynamicSymbolsCollection)symbolLoader.SymbolsDynamic;

                    //assign the symbols of gTOASTHMI to a dynamic variable
                    dynamic TwinCAT_SystemInfoVarList = symbols["TwinCAT_SystemInfoVarList"];

                    //pick out the gHMI and gButtons
                    //  dynamic gHMI = gTOASTHMI.gData.hmi.ReadValue();
                    //  dynamic gbtns = gTOASTHMI.gData.btns.ReadValue();
                    //  dynamic gMsgs = gTOASTHMI.gData.GlobalMessages.ReadValue();


                    //gData now contains;
                    //hmi: structHMI;
                    //btns: structHMIBtns;
                }

                catch
                (Exception ex)
                {
                    MessageBox.Show($"Error while reading TwinCAT_SystemInfoVarList structure: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }  
    }
}


     


