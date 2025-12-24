namespace TOAST_HMI
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timGetPLCData = new System.Windows.Forms.Timer(components);
            btnMainMenu = new Button();
            btnReset = new Button();
            btnMode = new Button();
            btnControl = new Button();
            btnAutoMode = new Button();
            btnManualMode = new Button();
            btnStartAutoCycle = new Button();
            btnSEOC = new Button();
            btnReturnHome = new Button();
            lblStationState = new Label();
            lblCycleTypeState = new Label();
            lblFaultState = new Label();
            lblHomeState = new Label();
            lblAnyWarnings = new Label();
            lblStationName = new Label();
            ofdTc3Project = new OpenFileDialog();
            button4 = new Button();
            lblAnyFaultsExist = new Label();
            lblmsgViewAlarmMachine = new Label();
            lblmsgViewAlarmS1 = new Label();
            lblmsgViewAlarmS2 = new Label();
            lblmsgViewAlarmS3 = new Label();
            lblmsgViewAlarmS4 = new Label();
            lblmsgViewAlarmS5 = new Label();
            lblmsgViewAlarmS6 = new Label();
            lblmsgViewPromptMachine = new Label();
            lblmsgViewPromptsS1 = new Label();
            lblmsgViewPromptsS2 = new Label();
            lblmsgViewPromptsS3 = new Label();
            lblmsgViewPromptsS4 = new Label();
            lblmsgViewPromptsS5 = new Label();
            lblmsgViewPromptsS6 = new Label();
            lblmsgViewWarningMachine = new Label();
            lblmsgViewWarningS1 = new Label();
            lblmsgViewWarningS2 = new Label();
            lblmsgViewWarningS3 = new Label();
            lblmsgViewWarningS4 = new Label();
            lblmsgViewWarningS5 = new Label();
            lblmsgViewWarningS6 = new Label();
            btnStation6 = new Button();
            btnStation5 = new Button();
            btnStation4 = new Button();
            btnStation3 = new Button();
            btnStation2 = new Button();
            btnStation1 = new Button();
            btnSelectAll = new Button();
            btnAutoCycleStart = new Button();
            btnAutoCycleStop = new Button();
            lbFoundFiles = new ListBox();
            btn06 = new Button();
            btn05 = new Button();
            btn04 = new Button();
            btn03 = new Button();
            btn02 = new Button();
            btn01 = new Button();
            btn26 = new Button();
            btn25 = new Button();
            btn24 = new Button();
            btn23 = new Button();
            btn22 = new Button();
            btn21 = new Button();
            btn20 = new Button();
            btn16 = new Button();
            btn15 = new Button();
            btn14 = new Button();
            btn13 = new Button();
            btn12 = new Button();
            btn11 = new Button();
            btn10 = new Button();
            btn00 = new Button();
            btnPowerOn = new Button();
            btnPowerOff = new Button();
            tabControl1 = new TabControl();
            tpMode = new TabPage();
            tpManualRows = new TabPage();
            usrcontRow9 = new usrcontRow();
            usrcontRow8 = new usrcontRow();
            usrcontRow7 = new usrcontRow();
            usrcontRow6 = new usrcontRow();
            usrcontRow5 = new usrcontRow();
            usrcontRow4 = new usrcontRow();
            usrcontRow3 = new usrcontRow();
            usrcontRow2 = new usrcontRow();
            usrcontRow1 = new usrcontRow();
            tabPage1 = new TabPage();
            btnReadStruct2 = new Button();
            button1 = new Button();
            treeViewSymbols = new TreeView();
            btnReadStructure = new Button();
            lsbReadSymbols = new ListBox();
            tabControl1.SuspendLayout();
            tpMode.SuspendLayout();
            tpManualRows.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // timGetPLCData
            // 
            timGetPLCData.Interval = 1000;
            timGetPLCData.Tick += timGetPLCData_Tick;
            // 
            // btnMainMenu
            // 
            btnMainMenu.Location = new Point(928, 0);
            btnMainMenu.Name = "btnMainMenu";
            btnMainMenu.Size = new Size(80, 80);
            btnMainMenu.TabIndex = 32;
            btnMainMenu.Text = "Main Menu";
            btnMainMenu.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(0, 0);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(80, 80);
            btnReset.TabIndex = 33;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnMode
            // 
            btnMode.Location = new Point(0, 651);
            btnMode.Name = "btnMode";
            btnMode.Size = new Size(80, 80);
            btnMode.TabIndex = 35;
            btnMode.Text = "Mode";
            btnMode.UseVisualStyleBackColor = true;
            btnMode.Click += btnMode_Click;
            // 
            // btnControl
            // 
            btnControl.Location = new Point(80, 651);
            btnControl.Name = "btnControl";
            btnControl.Size = new Size(80, 80);
            btnControl.TabIndex = 36;
            btnControl.Text = "Control";
            btnControl.UseVisualStyleBackColor = true;
            btnControl.Click += btnControl_Click;
            // 
            // btnAutoMode
            // 
            btnAutoMode.Location = new Point(197, 651);
            btnAutoMode.Name = "btnAutoMode";
            btnAutoMode.Size = new Size(80, 80);
            btnAutoMode.TabIndex = 37;
            btnAutoMode.Text = "AUTO MODE";
            btnAutoMode.UseVisualStyleBackColor = true;
            btnAutoMode.Click += btnAutoMode_Click;
            // 
            // btnManualMode
            // 
            btnManualMode.Location = new Point(283, 651);
            btnManualMode.Name = "btnManualMode";
            btnManualMode.Size = new Size(80, 80);
            btnManualMode.TabIndex = 38;
            btnManualMode.Text = "MANUAL MODE";
            btnManualMode.UseVisualStyleBackColor = true;
            // 
            // btnStartAutoCycle
            // 
            btnStartAutoCycle.Location = new Point(369, 651);
            btnStartAutoCycle.Name = "btnStartAutoCycle";
            btnStartAutoCycle.Size = new Size(80, 80);
            btnStartAutoCycle.TabIndex = 39;
            btnStartAutoCycle.Text = "START AUTO CYCLE";
            btnStartAutoCycle.UseVisualStyleBackColor = true;
            // 
            // btnSEOC
            // 
            btnSEOC.Location = new Point(455, 651);
            btnSEOC.Name = "btnSEOC";
            btnSEOC.Size = new Size(80, 80);
            btnSEOC.TabIndex = 40;
            btnSEOC.Text = "STOP END OF CYCLE";
            btnSEOC.UseVisualStyleBackColor = true;
            // 
            // btnReturnHome
            // 
            btnReturnHome.Location = new Point(541, 651);
            btnReturnHome.Name = "btnReturnHome";
            btnReturnHome.Size = new Size(80, 80);
            btnReturnHome.TabIndex = 41;
            btnReturnHome.Text = "RETURN HOME";
            btnReturnHome.UseVisualStyleBackColor = true;
            // 
            // lblStationState
            // 
            lblStationState.BackColor = Color.White;
            lblStationState.BorderStyle = BorderStyle.FixedSingle;
            lblStationState.Location = new Point(80, 0);
            lblStationState.Name = "lblStationState";
            lblStationState.Size = new Size(148, 20);
            lblStationState.TabIndex = 42;
            lblStationState.Text = "STATION STATE, ModeStatesHeader, , header.stationstate";
            lblStationState.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCycleTypeState
            // 
            lblCycleTypeState.BackColor = Color.White;
            lblCycleTypeState.BorderStyle = BorderStyle.FixedSingle;
            lblCycleTypeState.Location = new Point(234, 0);
            lblCycleTypeState.Name = "lblCycleTypeState";
            lblCycleTypeState.Size = new Size(120, 20);
            lblCycleTypeState.TabIndex = 43;
            lblCycleTypeState.Text = "CycleTypeState,  header.cycleTypeFeedback , CycleType";
            lblCycleTypeState.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFaultState
            // 
            lblFaultState.BackColor = Color.White;
            lblFaultState.BorderStyle = BorderStyle.FixedSingle;
            lblFaultState.Location = new Point(360, 0);
            lblFaultState.Name = "lblFaultState";
            lblFaultState.Size = new Size(96, 20);
            lblFaultState.TabIndex = 44;
            lblFaultState.Text = "Fault State, header.FaultStateHeader,  FaultState";
            lblFaultState.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHomeState
            // 
            lblHomeState.BackColor = Color.White;
            lblHomeState.BorderStyle = BorderStyle.FixedSingle;
            lblHomeState.Location = new Point(462, 0);
            lblHomeState.Name = "lblHomeState";
            lblHomeState.Size = new Size(122, 20);
            lblHomeState.TabIndex = 45;
            lblHomeState.Text = "Home State, header.homestate, HomeState";
            lblHomeState.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAnyWarnings
            // 
            lblAnyWarnings.BackColor = Color.White;
            lblAnyWarnings.BorderStyle = BorderStyle.FixedSingle;
            lblAnyWarnings.Location = new Point(590, 0);
            lblAnyWarnings.Name = "lblAnyWarnings";
            lblAnyWarnings.Size = new Size(173, 20);
            lblAnyWarnings.TabIndex = 46;
            lblAnyWarnings.Text = "Any Warnings Exist, header.AnyStationWarningHeader,, AnyStationWarningList";
            lblAnyWarnings.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStationName
            // 
            lblStationName.BackColor = Color.White;
            lblStationName.BorderStyle = BorderStyle.FixedSingle;
            lblStationName.Location = new Point(769, 0);
            lblStationName.Name = "lblStationName";
            lblStationName.Size = new Size(157, 20);
            lblStationName.TabIndex = 47;
            lblStationName.Text = "Station Name, header.stationNameSelect, StationNames";
            lblStationName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ofdTc3Project
            // 
            ofdTc3Project.FileName = "openFileDialog1";
            ofdTc3Project.Filter = "TwinCAT3 Projects | *.sln";
            ofdTc3Project.Title = "Select a TwinCAT3 Project...";
            // 
            // button4
            // 
            button4.Location = new Point(769, 680);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 48;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // lblAnyFaultsExist
            // 
            lblAnyFaultsExist.BackColor = Color.White;
            lblAnyFaultsExist.BorderStyle = BorderStyle.FixedSingle;
            lblAnyFaultsExist.Location = new Point(590, 0);
            lblAnyFaultsExist.Name = "lblAnyFaultsExist";
            lblAnyFaultsExist.Size = new Size(173, 20);
            lblAnyFaultsExist.TabIndex = 52;
            lblAnyFaultsExist.Text = "Any Faults Exist\r\n";
            lblAnyFaultsExist.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblmsgViewAlarmMachine
            // 
            lblmsgViewAlarmMachine.BackColor = Color.Red;
            lblmsgViewAlarmMachine.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewAlarmMachine.Font = new Font("Segoe UI", 12F);
            lblmsgViewAlarmMachine.ForeColor = Color.White;
            lblmsgViewAlarmMachine.Location = new Point(80, 20);
            lblmsgViewAlarmMachine.Name = "lblmsgViewAlarmMachine";
            lblmsgViewAlarmMachine.Size = new Size(846, 22);
            lblmsgViewAlarmMachine.TabIndex = 53;
            lblmsgViewAlarmMachine.Text = "msgViewAlarmMachine";
            // 
            // lblmsgViewAlarmS1
            // 
            lblmsgViewAlarmS1.BackColor = Color.Red;
            lblmsgViewAlarmS1.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewAlarmS1.Font = new Font("Segoe UI", 12F);
            lblmsgViewAlarmS1.ForeColor = Color.White;
            lblmsgViewAlarmS1.Location = new Point(80, 20);
            lblmsgViewAlarmS1.Name = "lblmsgViewAlarmS1";
            lblmsgViewAlarmS1.Size = new Size(846, 22);
            lblmsgViewAlarmS1.TabIndex = 54;
            lblmsgViewAlarmS1.Text = "msgViewAlarmS1";
            // 
            // lblmsgViewAlarmS2
            // 
            lblmsgViewAlarmS2.BackColor = Color.Red;
            lblmsgViewAlarmS2.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewAlarmS2.Font = new Font("Segoe UI", 12F);
            lblmsgViewAlarmS2.ForeColor = Color.White;
            lblmsgViewAlarmS2.Location = new Point(80, 20);
            lblmsgViewAlarmS2.Name = "lblmsgViewAlarmS2";
            lblmsgViewAlarmS2.Size = new Size(846, 22);
            lblmsgViewAlarmS2.TabIndex = 55;
            lblmsgViewAlarmS2.Text = "lblmsgViewAlarmS2";
            // 
            // lblmsgViewAlarmS3
            // 
            lblmsgViewAlarmS3.BackColor = Color.Red;
            lblmsgViewAlarmS3.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewAlarmS3.Font = new Font("Segoe UI", 12F);
            lblmsgViewAlarmS3.ForeColor = Color.White;
            lblmsgViewAlarmS3.Location = new Point(80, 20);
            lblmsgViewAlarmS3.Name = "lblmsgViewAlarmS3";
            lblmsgViewAlarmS3.Size = new Size(846, 22);
            lblmsgViewAlarmS3.TabIndex = 56;
            lblmsgViewAlarmS3.Text = "lblmsgViewAlarmS3";
            // 
            // lblmsgViewAlarmS4
            // 
            lblmsgViewAlarmS4.BackColor = Color.Red;
            lblmsgViewAlarmS4.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewAlarmS4.Font = new Font("Segoe UI", 12F);
            lblmsgViewAlarmS4.ForeColor = Color.White;
            lblmsgViewAlarmS4.Location = new Point(80, 20);
            lblmsgViewAlarmS4.Name = "lblmsgViewAlarmS4";
            lblmsgViewAlarmS4.Size = new Size(846, 22);
            lblmsgViewAlarmS4.TabIndex = 57;
            lblmsgViewAlarmS4.Text = "lblmsgViewAlarmS4";
            // 
            // lblmsgViewAlarmS5
            // 
            lblmsgViewAlarmS5.BackColor = Color.Red;
            lblmsgViewAlarmS5.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewAlarmS5.Font = new Font("Segoe UI", 12F);
            lblmsgViewAlarmS5.ForeColor = Color.White;
            lblmsgViewAlarmS5.Location = new Point(80, 20);
            lblmsgViewAlarmS5.Name = "lblmsgViewAlarmS5";
            lblmsgViewAlarmS5.Size = new Size(846, 22);
            lblmsgViewAlarmS5.TabIndex = 58;
            lblmsgViewAlarmS5.Text = "lblmsgViewAlarmS5";
            // 
            // lblmsgViewAlarmS6
            // 
            lblmsgViewAlarmS6.BackColor = Color.Red;
            lblmsgViewAlarmS6.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewAlarmS6.Font = new Font("Segoe UI", 12F);
            lblmsgViewAlarmS6.ForeColor = Color.White;
            lblmsgViewAlarmS6.Location = new Point(80, 20);
            lblmsgViewAlarmS6.Name = "lblmsgViewAlarmS6";
            lblmsgViewAlarmS6.Size = new Size(846, 22);
            lblmsgViewAlarmS6.TabIndex = 59;
            lblmsgViewAlarmS6.Text = "lblmsgViewAlarmS6";
            // 
            // lblmsgViewPromptMachine
            // 
            lblmsgViewPromptMachine.BackColor = Color.Silver;
            lblmsgViewPromptMachine.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewPromptMachine.Font = new Font("Segoe UI", 12F);
            lblmsgViewPromptMachine.ForeColor = Color.DeepSkyBlue;
            lblmsgViewPromptMachine.Location = new Point(80, 64);
            lblmsgViewPromptMachine.Name = "lblmsgViewPromptMachine";
            lblmsgViewPromptMachine.Size = new Size(846, 22);
            lblmsgViewPromptMachine.TabIndex = 60;
            lblmsgViewPromptMachine.Text = "msgViewPromptMachine";
            lblmsgViewPromptMachine.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblmsgViewPromptsS1
            // 
            lblmsgViewPromptsS1.BackColor = Color.Silver;
            lblmsgViewPromptsS1.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewPromptsS1.Font = new Font("Segoe UI", 12F);
            lblmsgViewPromptsS1.ForeColor = Color.DeepSkyBlue;
            lblmsgViewPromptsS1.Location = new Point(80, 64);
            lblmsgViewPromptsS1.Name = "lblmsgViewPromptsS1";
            lblmsgViewPromptsS1.Size = new Size(846, 22);
            lblmsgViewPromptsS1.TabIndex = 61;
            lblmsgViewPromptsS1.Text = "msgViewPromptsS1";
            lblmsgViewPromptsS1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblmsgViewPromptsS2
            // 
            lblmsgViewPromptsS2.BackColor = Color.Silver;
            lblmsgViewPromptsS2.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewPromptsS2.Font = new Font("Segoe UI", 12F);
            lblmsgViewPromptsS2.ForeColor = Color.DeepSkyBlue;
            lblmsgViewPromptsS2.Location = new Point(80, 64);
            lblmsgViewPromptsS2.Name = "lblmsgViewPromptsS2";
            lblmsgViewPromptsS2.Size = new Size(846, 22);
            lblmsgViewPromptsS2.TabIndex = 62;
            lblmsgViewPromptsS2.Text = "msgViewPromptsS2";
            lblmsgViewPromptsS2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblmsgViewPromptsS3
            // 
            lblmsgViewPromptsS3.BackColor = Color.Silver;
            lblmsgViewPromptsS3.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewPromptsS3.Font = new Font("Segoe UI", 12F);
            lblmsgViewPromptsS3.ForeColor = Color.DeepSkyBlue;
            lblmsgViewPromptsS3.Location = new Point(80, 64);
            lblmsgViewPromptsS3.Name = "lblmsgViewPromptsS3";
            lblmsgViewPromptsS3.Size = new Size(846, 22);
            lblmsgViewPromptsS3.TabIndex = 63;
            lblmsgViewPromptsS3.Text = "msgViewPromptsS3";
            lblmsgViewPromptsS3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblmsgViewPromptsS4
            // 
            lblmsgViewPromptsS4.BackColor = Color.Silver;
            lblmsgViewPromptsS4.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewPromptsS4.Font = new Font("Segoe UI", 12F);
            lblmsgViewPromptsS4.ForeColor = Color.DeepSkyBlue;
            lblmsgViewPromptsS4.Location = new Point(80, 64);
            lblmsgViewPromptsS4.Name = "lblmsgViewPromptsS4";
            lblmsgViewPromptsS4.Size = new Size(846, 22);
            lblmsgViewPromptsS4.TabIndex = 64;
            lblmsgViewPromptsS4.Text = "msgViewPromptsS4";
            lblmsgViewPromptsS4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblmsgViewPromptsS5
            // 
            lblmsgViewPromptsS5.BackColor = Color.Silver;
            lblmsgViewPromptsS5.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewPromptsS5.Font = new Font("Segoe UI", 12F);
            lblmsgViewPromptsS5.ForeColor = Color.DeepSkyBlue;
            lblmsgViewPromptsS5.Location = new Point(80, 64);
            lblmsgViewPromptsS5.Name = "lblmsgViewPromptsS5";
            lblmsgViewPromptsS5.Size = new Size(846, 22);
            lblmsgViewPromptsS5.TabIndex = 65;
            lblmsgViewPromptsS5.Text = "msgViewPromptsS5";
            lblmsgViewPromptsS5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblmsgViewPromptsS6
            // 
            lblmsgViewPromptsS6.BackColor = Color.Silver;
            lblmsgViewPromptsS6.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewPromptsS6.Font = new Font("Segoe UI", 12F);
            lblmsgViewPromptsS6.ForeColor = Color.DeepSkyBlue;
            lblmsgViewPromptsS6.Location = new Point(80, 64);
            lblmsgViewPromptsS6.Name = "lblmsgViewPromptsS6";
            lblmsgViewPromptsS6.Size = new Size(846, 22);
            lblmsgViewPromptsS6.TabIndex = 66;
            lblmsgViewPromptsS6.Text = "msgViewPromptsS6";
            lblmsgViewPromptsS6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblmsgViewWarningMachine
            // 
            lblmsgViewWarningMachine.BackColor = Color.Yellow;
            lblmsgViewWarningMachine.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewWarningMachine.Font = new Font("Segoe UI", 12F);
            lblmsgViewWarningMachine.Location = new Point(80, 42);
            lblmsgViewWarningMachine.Name = "lblmsgViewWarningMachine";
            lblmsgViewWarningMachine.Size = new Size(846, 22);
            lblmsgViewWarningMachine.TabIndex = 67;
            lblmsgViewWarningMachine.Text = "msgViewWarningMachine";
            // 
            // lblmsgViewWarningS1
            // 
            lblmsgViewWarningS1.BackColor = Color.Yellow;
            lblmsgViewWarningS1.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewWarningS1.Font = new Font("Segoe UI", 12F);
            lblmsgViewWarningS1.Location = new Point(80, 42);
            lblmsgViewWarningS1.Name = "lblmsgViewWarningS1";
            lblmsgViewWarningS1.Size = new Size(846, 22);
            lblmsgViewWarningS1.TabIndex = 68;
            lblmsgViewWarningS1.Text = "msgViewWarningS1";
            // 
            // lblmsgViewWarningS2
            // 
            lblmsgViewWarningS2.BackColor = Color.Yellow;
            lblmsgViewWarningS2.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewWarningS2.Font = new Font("Segoe UI", 12F);
            lblmsgViewWarningS2.Location = new Point(80, 42);
            lblmsgViewWarningS2.Name = "lblmsgViewWarningS2";
            lblmsgViewWarningS2.Size = new Size(846, 22);
            lblmsgViewWarningS2.TabIndex = 69;
            lblmsgViewWarningS2.Text = "msgViewWarningS2";
            // 
            // lblmsgViewWarningS3
            // 
            lblmsgViewWarningS3.BackColor = Color.Yellow;
            lblmsgViewWarningS3.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewWarningS3.Font = new Font("Segoe UI", 12F);
            lblmsgViewWarningS3.Location = new Point(80, 42);
            lblmsgViewWarningS3.Name = "lblmsgViewWarningS3";
            lblmsgViewWarningS3.Size = new Size(846, 22);
            lblmsgViewWarningS3.TabIndex = 70;
            lblmsgViewWarningS3.Text = "msgViewWarningS4";
            // 
            // lblmsgViewWarningS4
            // 
            lblmsgViewWarningS4.BackColor = Color.Yellow;
            lblmsgViewWarningS4.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewWarningS4.Font = new Font("Segoe UI", 12F);
            lblmsgViewWarningS4.Location = new Point(80, 42);
            lblmsgViewWarningS4.Name = "lblmsgViewWarningS4";
            lblmsgViewWarningS4.Size = new Size(846, 22);
            lblmsgViewWarningS4.TabIndex = 71;
            lblmsgViewWarningS4.Text = "msgViewWarningS4";
            // 
            // lblmsgViewWarningS5
            // 
            lblmsgViewWarningS5.BackColor = Color.Yellow;
            lblmsgViewWarningS5.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewWarningS5.Font = new Font("Segoe UI", 12F);
            lblmsgViewWarningS5.Location = new Point(80, 42);
            lblmsgViewWarningS5.Name = "lblmsgViewWarningS5";
            lblmsgViewWarningS5.Size = new Size(846, 22);
            lblmsgViewWarningS5.TabIndex = 72;
            lblmsgViewWarningS5.Text = "msgViewWarningS5";
            // 
            // lblmsgViewWarningS6
            // 
            lblmsgViewWarningS6.BackColor = Color.Yellow;
            lblmsgViewWarningS6.BorderStyle = BorderStyle.FixedSingle;
            lblmsgViewWarningS6.Font = new Font("Segoe UI", 12F);
            lblmsgViewWarningS6.Location = new Point(80, 42);
            lblmsgViewWarningS6.Name = "lblmsgViewWarningS6";
            lblmsgViewWarningS6.Size = new Size(846, 22);
            lblmsgViewWarningS6.TabIndex = 73;
            lblmsgViewWarningS6.Text = "msgViewWarningS6";
            // 
            // btnStation6
            // 
            btnStation6.Location = new Point(775, 428);
            btnStation6.Name = "btnStation6";
            btnStation6.Size = new Size(120, 80);
            btnStation6.TabIndex = 8;
            btnStation6.Text = "Station 6";
            btnStation6.UseVisualStyleBackColor = true;
            // 
            // btnStation5
            // 
            btnStation5.Location = new Point(649, 428);
            btnStation5.Name = "btnStation5";
            btnStation5.Size = new Size(120, 80);
            btnStation5.TabIndex = 7;
            btnStation5.Text = "Station 5";
            btnStation5.UseVisualStyleBackColor = true;
            // 
            // btnStation4
            // 
            btnStation4.Location = new Point(523, 428);
            btnStation4.Name = "btnStation4";
            btnStation4.Size = new Size(120, 80);
            btnStation4.TabIndex = 6;
            btnStation4.Text = "Station 4";
            btnStation4.UseVisualStyleBackColor = true;
            // 
            // btnStation3
            // 
            btnStation3.Location = new Point(397, 428);
            btnStation3.Name = "btnStation3";
            btnStation3.Size = new Size(120, 80);
            btnStation3.TabIndex = 5;
            btnStation3.Text = "Station 3";
            btnStation3.UseVisualStyleBackColor = true;
            // 
            // btnStation2
            // 
            btnStation2.Location = new Point(271, 428);
            btnStation2.Name = "btnStation2";
            btnStation2.Size = new Size(120, 80);
            btnStation2.TabIndex = 4;
            btnStation2.Text = "Station 2";
            btnStation2.UseVisualStyleBackColor = true;
            // 
            // btnStation1
            // 
            btnStation1.Location = new Point(145, 428);
            btnStation1.Name = "btnStation1";
            btnStation1.Size = new Size(120, 80);
            btnStation1.TabIndex = 3;
            btnStation1.Text = "Station 1";
            btnStation1.UseVisualStyleBackColor = true;
            // 
            // btnSelectAll
            // 
            btnSelectAll.Location = new Point(59, 428);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(80, 80);
            btnSelectAll.TabIndex = 34;
            btnSelectAll.Text = "Select All";
            btnSelectAll.UseVisualStyleBackColor = true;
            // 
            // btnAutoCycleStart
            // 
            btnAutoCycleStart.Location = new Point(912, 207);
            btnAutoCycleStart.Name = "btnAutoCycleStart";
            btnAutoCycleStart.Size = new Size(80, 80);
            btnAutoCycleStart.TabIndex = 10;
            btnAutoCycleStart.Text = "START AUTO CYCLE";
            btnAutoCycleStart.UseVisualStyleBackColor = true;
            // 
            // btnAutoCycleStop
            // 
            btnAutoCycleStop.Location = new Point(912, 121);
            btnAutoCycleStop.Name = "btnAutoCycleStop";
            btnAutoCycleStop.Size = new Size(80, 80);
            btnAutoCycleStop.TabIndex = 9;
            btnAutoCycleStop.Text = "STOP AUTO CYCLE";
            btnAutoCycleStop.UseVisualStyleBackColor = true;
            // 
            // lbFoundFiles
            // 
            lbFoundFiles.FormattingEnabled = true;
            lbFoundFiles.ItemHeight = 15;
            lbFoundFiles.Location = new Point(203, 32);
            lbFoundFiles.Name = "lbFoundFiles";
            lbFoundFiles.Size = new Size(477, 49);
            lbFoundFiles.TabIndex = 51;
            lbFoundFiles.SelectedIndexChanged += lbFoundFiles_SelectedIndexChanged;
            // 
            // btn06
            // 
            btn06.Location = new Point(686, 110);
            btn06.Name = "btn06";
            btn06.Size = new Size(80, 80);
            btn06.TabIndex = 31;
            btn06.UseVisualStyleBackColor = true;
            // 
            // btn05
            // 
            btn05.Location = new Point(600, 110);
            btn05.Name = "btn05";
            btn05.Size = new Size(80, 80);
            btn05.TabIndex = 30;
            btn05.Text = "ENABLE REMOTE CONTROL";
            btn05.UseVisualStyleBackColor = true;
            // 
            // btn04
            // 
            btn04.Location = new Point(514, 110);
            btn04.Name = "btn04";
            btn04.Size = new Size(80, 80);
            btn04.TabIndex = 29;
            btn04.UseVisualStyleBackColor = true;
            // 
            // btn03
            // 
            btn03.Location = new Point(428, 110);
            btn03.Name = "btn03";
            btn03.Size = new Size(80, 80);
            btn03.TabIndex = 28;
            btn03.UseVisualStyleBackColor = true;
            // 
            // btn02
            // 
            btn02.Location = new Point(342, 110);
            btn02.Name = "btn02";
            btn02.Size = new Size(80, 80);
            btn02.TabIndex = 27;
            btn02.Text = "SEMI-AUTO MODE";
            btn02.UseVisualStyleBackColor = true;
            // 
            // btn01
            // 
            btn01.Location = new Point(256, 110);
            btn01.Name = "btn01";
            btn01.Size = new Size(80, 80);
            btn01.TabIndex = 26;
            btn01.Text = "MANUAL MODE";
            btn01.UseVisualStyleBackColor = true;
            // 
            // btn26
            // 
            btn26.Location = new Point(686, 282);
            btn26.Name = "btn26";
            btn26.Size = new Size(80, 80);
            btn26.TabIndex = 24;
            btn26.UseVisualStyleBackColor = true;
            // 
            // btn25
            // 
            btn25.Location = new Point(600, 282);
            btn25.Name = "btn25";
            btn25.Size = new Size(80, 80);
            btn25.TabIndex = 23;
            btn25.UseVisualStyleBackColor = true;
            // 
            // btn24
            // 
            btn24.Location = new Point(514, 282);
            btn24.Name = "btn24";
            btn24.Size = new Size(80, 80);
            btn24.TabIndex = 22;
            btn24.UseVisualStyleBackColor = true;
            // 
            // btn23
            // 
            btn23.Location = new Point(428, 282);
            btn23.Name = "btn23";
            btn23.Size = new Size(80, 80);
            btn23.TabIndex = 21;
            btn23.Text = "ENABLE PENDANT";
            btn23.UseVisualStyleBackColor = true;
            // 
            // btn22
            // 
            btn22.Location = new Point(342, 282);
            btn22.Name = "btn22";
            btn22.Size = new Size(80, 80);
            btn22.TabIndex = 20;
            btn22.Text = "LOCK ACCESS GATE";
            btn22.UseVisualStyleBackColor = true;
            // 
            // btn21
            // 
            btn21.Location = new Point(256, 282);
            btn21.Name = "btn21";
            btn21.Size = new Size(80, 80);
            btn21.TabIndex = 19;
            btn21.Text = "GATE 2 ACCESS REQUEST";
            btn21.UseVisualStyleBackColor = true;
            // 
            // btn20
            // 
            btn20.Location = new Point(170, 282);
            btn20.Name = "btn20";
            btn20.Size = new Size(80, 80);
            btn20.TabIndex = 18;
            btn20.Text = "GATE 1 ACCESS REQUEST";
            btn20.UseVisualStyleBackColor = true;
            // 
            // btn16
            // 
            btn16.Location = new Point(686, 196);
            btn16.Name = "btn16";
            btn16.Size = new Size(80, 80);
            btn16.TabIndex = 17;
            btn16.UseVisualStyleBackColor = true;
            // 
            // btn15
            // 
            btn15.Location = new Point(600, 196);
            btn15.Name = "btn15";
            btn15.Size = new Size(80, 80);
            btn15.TabIndex = 16;
            btn15.Text = "SILENCE HORN";
            btn15.UseVisualStyleBackColor = true;
            // 
            // btn14
            // 
            btn14.Location = new Point(514, 196);
            btn14.Name = "btn14";
            btn14.Size = new Size(80, 80);
            btn14.TabIndex = 15;
            btn14.UseVisualStyleBackColor = true;
            // 
            // btn13
            // 
            btn13.Location = new Point(428, 196);
            btn13.Name = "btn13";
            btn13.Size = new Size(80, 80);
            btn13.TabIndex = 14;
            btn13.Text = "SINGLE CYCLE";
            btn13.UseVisualStyleBackColor = true;
            // 
            // btn12
            // 
            btn12.Location = new Point(342, 196);
            btn12.Name = "btn12";
            btn12.Size = new Size(80, 80);
            btn12.TabIndex = 13;
            btn12.Text = "STOP END OF CYCLE";
            btn12.UseVisualStyleBackColor = true;
            // 
            // btn11
            // 
            btn11.Location = new Point(256, 196);
            btn11.Name = "btn11";
            btn11.Size = new Size(80, 80);
            btn11.TabIndex = 12;
            btn11.Text = "DRY CYCLE";
            btn11.UseVisualStyleBackColor = true;
            // 
            // btn10
            // 
            btn10.Location = new Point(170, 196);
            btn10.Name = "btn10";
            btn10.Size = new Size(80, 80);
            btn10.TabIndex = 11;
            btn10.Text = "CONTINUOUS CYCLE";
            btn10.UseVisualStyleBackColor = true;
            // 
            // btn00
            // 
            btn00.Location = new Point(170, 110);
            btn00.Name = "btn00";
            btn00.Size = new Size(80, 80);
            btn00.TabIndex = 25;
            btn00.Text = "AUTO MODE";
            btn00.UseVisualStyleBackColor = true;
            // 
            // btnPowerOn
            // 
            btnPowerOn.Location = new Point(3, 207);
            btnPowerOn.Name = "btnPowerOn";
            btnPowerOn.Size = new Size(80, 80);
            btnPowerOn.TabIndex = 0;
            btnPowerOn.Text = "POWER ON";
            btnPowerOn.UseVisualStyleBackColor = true;
            // 
            // btnPowerOff
            // 
            btnPowerOff.Location = new Point(3, 121);
            btnPowerOff.Name = "btnPowerOff";
            btnPowerOff.Size = new Size(80, 80);
            btnPowerOff.TabIndex = 1;
            btnPowerOff.Text = "POWER OFF";
            btnPowerOff.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpMode);
            tabControl1.Controls.Add(tpManualRows);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(0, 86);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1008, 559);
            tabControl1.TabIndex = 52;
            // 
            // tpMode
            // 
            tpMode.Controls.Add(btnPowerOff);
            tpMode.Controls.Add(btnAutoCycleStop);
            tpMode.Controls.Add(btn00);
            tpMode.Controls.Add(btnAutoCycleStart);
            tpMode.Controls.Add(btn10);
            tpMode.Controls.Add(btnSelectAll);
            tpMode.Controls.Add(btnStation1);
            tpMode.Controls.Add(btnPowerOn);
            tpMode.Controls.Add(btnStation2);
            tpMode.Controls.Add(btn11);
            tpMode.Controls.Add(btnStation3);
            tpMode.Controls.Add(lbFoundFiles);
            tpMode.Controls.Add(btnStation4);
            tpMode.Controls.Add(btn12);
            tpMode.Controls.Add(btnStation5);
            tpMode.Controls.Add(btn06);
            tpMode.Controls.Add(btnStation6);
            tpMode.Controls.Add(btn13);
            tpMode.Controls.Add(btn05);
            tpMode.Controls.Add(btn14);
            tpMode.Controls.Add(btn04);
            tpMode.Controls.Add(btn15);
            tpMode.Controls.Add(btn03);
            tpMode.Controls.Add(btn16);
            tpMode.Controls.Add(btn02);
            tpMode.Controls.Add(btn20);
            tpMode.Controls.Add(btn01);
            tpMode.Controls.Add(btn21);
            tpMode.Controls.Add(btn26);
            tpMode.Controls.Add(btn22);
            tpMode.Controls.Add(btn25);
            tpMode.Controls.Add(btn23);
            tpMode.Controls.Add(btn24);
            tpMode.Location = new Point(4, 24);
            tpMode.Name = "tpMode";
            tpMode.Padding = new Padding(3);
            tpMode.Size = new Size(1000, 531);
            tpMode.TabIndex = 0;
            tpMode.Text = "Mode";
            tpMode.UseVisualStyleBackColor = true;
            // 
            // tpManualRows
            // 
            tpManualRows.Controls.Add(usrcontRow9);
            tpManualRows.Controls.Add(usrcontRow8);
            tpManualRows.Controls.Add(usrcontRow7);
            tpManualRows.Controls.Add(usrcontRow6);
            tpManualRows.Controls.Add(usrcontRow5);
            tpManualRows.Controls.Add(usrcontRow4);
            tpManualRows.Controls.Add(usrcontRow3);
            tpManualRows.Controls.Add(usrcontRow2);
            tpManualRows.Controls.Add(usrcontRow1);
            tpManualRows.Location = new Point(4, 24);
            tpManualRows.Name = "tpManualRows";
            tpManualRows.Padding = new Padding(3);
            tpManualRows.Size = new Size(1000, 531);
            tpManualRows.TabIndex = 1;
            tpManualRows.Text = "Manual";
            tpManualRows.UseVisualStyleBackColor = true;
            // 
            // usrcontRow9
            // 
            usrcontRow9.AdvancedName = "Advance";
            usrcontRow9.AdvancedNameBackColor = Color.Transparent;
            usrcontRow9.AdvanceName = "Advance";
            usrcontRow9.AdvanceNameBackColor = Color.Transparent;
            usrcontRow9.IsReturned = true;
            usrcontRow9.Location = new Point(0, 471);
            usrcontRow9.Name = "usrcontRow9";
            usrcontRow9.PositionText = "0.0 mm";
            usrcontRow9.ReturnedName = "Returned";
            usrcontRow9.ReturnedNameBackColor = Color.Transparent;
            usrcontRow9.ReturnName = "Return";
            usrcontRow9.ReturnNameBackColor = Color.Transparent;
            usrcontRow9.RowIndex = 9;
            usrcontRow9.RowName = "Cylinder A9";
            usrcontRow9.ShowAdvanceButton = false;
            usrcontRow9.ShowAdvanceLabel = false;
            usrcontRow9.ShowReturnButton = false;
            usrcontRow9.Size = new Size(1000, 52);
            usrcontRow9.TabIndex = 8;
            // 
            // usrcontRow8
            // 
            usrcontRow8.AdvancedName = "Advance";
            usrcontRow8.AdvancedNameBackColor = Color.Transparent;
            usrcontRow8.AdvanceName = "Advance";
            usrcontRow8.AdvanceNameBackColor = Color.Transparent;
            usrcontRow8.IsReturned = true;
            usrcontRow8.Location = new Point(0, 413);
            usrcontRow8.Name = "usrcontRow8";
            usrcontRow8.PositionText = "0.0 mm";
            usrcontRow8.ReturnedName = "Returned";
            usrcontRow8.ReturnedNameBackColor = Color.Transparent;
            usrcontRow8.ReturnName = "Return";
            usrcontRow8.ReturnNameBackColor = Color.Transparent;
            usrcontRow8.RowIndex = 8;
            usrcontRow8.RowName = "Cylinder A8";
            usrcontRow8.ShowAdvanceButton = false;
            usrcontRow8.ShowAdvanceLabel = false;
            usrcontRow8.ShowReturnButton = false;
            usrcontRow8.Size = new Size(1000, 52);
            usrcontRow8.TabIndex = 7;
            // 
            // usrcontRow7
            // 
            usrcontRow7.AdvancedName = "Advance";
            usrcontRow7.AdvancedNameBackColor = Color.Transparent;
            usrcontRow7.AdvanceName = "Advance";
            usrcontRow7.AdvanceNameBackColor = Color.Transparent;
            usrcontRow7.IsReturned = true;
            usrcontRow7.Location = new Point(0, 355);
            usrcontRow7.Name = "usrcontRow7";
            usrcontRow7.PositionText = "0.0 mm";
            usrcontRow7.ReturnedName = "Returned";
            usrcontRow7.ReturnedNameBackColor = Color.Transparent;
            usrcontRow7.ReturnName = "Return";
            usrcontRow7.ReturnNameBackColor = Color.Transparent;
            usrcontRow7.RowIndex = 7;
            usrcontRow7.RowName = "Cylinder A7";
            usrcontRow7.ShowAdvanceButton = false;
            usrcontRow7.ShowAdvanceLabel = false;
            usrcontRow7.ShowReturnButton = false;
            usrcontRow7.Size = new Size(1000, 52);
            usrcontRow7.TabIndex = 6;
            // 
            // usrcontRow6
            // 
            usrcontRow6.AdvancedName = "Advance";
            usrcontRow6.AdvancedNameBackColor = Color.Transparent;
            usrcontRow6.AdvanceName = "Advance";
            usrcontRow6.AdvanceNameBackColor = Color.Transparent;
            usrcontRow6.IsReturned = true;
            usrcontRow6.Location = new Point(0, 297);
            usrcontRow6.Name = "usrcontRow6";
            usrcontRow6.PositionText = "0.0 mm";
            usrcontRow6.ReturnedName = "Returned";
            usrcontRow6.ReturnedNameBackColor = Color.Transparent;
            usrcontRow6.ReturnName = "Return";
            usrcontRow6.ReturnNameBackColor = Color.Transparent;
            usrcontRow6.RowIndex = 6;
            usrcontRow6.RowName = "Cylinder A6";
            usrcontRow6.ShowAdvanceButton = false;
            usrcontRow6.ShowAdvanceLabel = false;
            usrcontRow6.ShowReturnButton = false;
            usrcontRow6.Size = new Size(1000, 52);
            usrcontRow6.TabIndex = 5;
            // 
            // usrcontRow5
            // 
            usrcontRow5.AdvancedName = "Advance";
            usrcontRow5.AdvancedNameBackColor = Color.Transparent;
            usrcontRow5.AdvanceName = "Advance";
            usrcontRow5.AdvanceNameBackColor = Color.Transparent;
            usrcontRow5.IsReturned = true;
            usrcontRow5.Location = new Point(0, 239);
            usrcontRow5.Name = "usrcontRow5";
            usrcontRow5.PositionText = "0.0 mm";
            usrcontRow5.ReturnedName = "Returned";
            usrcontRow5.ReturnedNameBackColor = Color.Transparent;
            usrcontRow5.ReturnName = "Return";
            usrcontRow5.ReturnNameBackColor = Color.Transparent;
            usrcontRow5.RowIndex = 5;
            usrcontRow5.RowName = "Cylinder A5";
            usrcontRow5.ShowAdvanceButton = false;
            usrcontRow5.ShowAdvanceLabel = false;
            usrcontRow5.ShowReturnButton = false;
            usrcontRow5.Size = new Size(1000, 52);
            usrcontRow5.TabIndex = 4;
            // 
            // usrcontRow4
            // 
            usrcontRow4.AdvancedName = "Advance";
            usrcontRow4.AdvancedNameBackColor = Color.Transparent;
            usrcontRow4.AdvanceName = "Advance";
            usrcontRow4.AdvanceNameBackColor = Color.Transparent;
            usrcontRow4.IsReturned = true;
            usrcontRow4.Location = new Point(0, 177);
            usrcontRow4.Name = "usrcontRow4";
            usrcontRow4.PositionText = "0.0 mm";
            usrcontRow4.ReturnedName = "Returned";
            usrcontRow4.ReturnedNameBackColor = Color.Transparent;
            usrcontRow4.ReturnName = "Return";
            usrcontRow4.ReturnNameBackColor = Color.Transparent;
            usrcontRow4.RowIndex = 4;
            usrcontRow4.RowName = "Cylinder A4";
            usrcontRow4.ShowAdvanceButton = false;
            usrcontRow4.ShowAdvanceLabel = false;
            usrcontRow4.ShowReturnButton = false;
            usrcontRow4.Size = new Size(1000, 52);
            usrcontRow4.TabIndex = 3;
            // 
            // usrcontRow3
            // 
            usrcontRow3.AdvancedName = "Advance";
            usrcontRow3.AdvancedNameBackColor = Color.Transparent;
            usrcontRow3.AdvanceName = "Advance";
            usrcontRow3.AdvanceNameBackColor = Color.Transparent;
            usrcontRow3.IsReturned = true;
            usrcontRow3.Location = new Point(0, 119);
            usrcontRow3.Name = "usrcontRow3";
            usrcontRow3.PositionText = "0.0 mm";
            usrcontRow3.ReturnedName = "Returned";
            usrcontRow3.ReturnedNameBackColor = Color.Transparent;
            usrcontRow3.ReturnName = "Return";
            usrcontRow3.ReturnNameBackColor = Color.Transparent;
            usrcontRow3.RowIndex = 3;
            usrcontRow3.RowName = "Cylinder A3";
            usrcontRow3.ShowAdvanceButton = false;
            usrcontRow3.ShowAdvanceLabel = false;
            usrcontRow3.ShowReturnButton = false;
            usrcontRow3.Size = new Size(1000, 52);
            usrcontRow3.TabIndex = 2;
            // 
            // usrcontRow2
            // 
            usrcontRow2.AdvancedName = "Advance";
            usrcontRow2.AdvancedNameBackColor = Color.Transparent;
            usrcontRow2.AdvanceName = "Advance";
            usrcontRow2.AdvanceNameBackColor = Color.Transparent;
            usrcontRow2.IsReturned = true;
            usrcontRow2.Location = new Point(0, 61);
            usrcontRow2.Name = "usrcontRow2";
            usrcontRow2.PositionText = "0.0 mm";
            usrcontRow2.ReturnedName = "Returned";
            usrcontRow2.ReturnedNameBackColor = Color.Transparent;
            usrcontRow2.ReturnName = "Return";
            usrcontRow2.ReturnNameBackColor = Color.Transparent;
            usrcontRow2.RowIndex = 2;
            usrcontRow2.RowName = "Cylinder A2";
            usrcontRow2.ShowAdvanceButton = false;
            usrcontRow2.ShowAdvanceLabel = false;
            usrcontRow2.ShowReturnButton = false;
            usrcontRow2.Size = new Size(1000, 52);
            usrcontRow2.TabIndex = 1;
            // 
            // usrcontRow1
            // 
            usrcontRow1.AdvancedName = "Advance";
            usrcontRow1.AdvancedNameBackColor = Color.Transparent;
            usrcontRow1.AdvanceName = "Advance";
            usrcontRow1.AdvanceNameBackColor = Color.Transparent;
            usrcontRow1.IsReturned = true;
            usrcontRow1.Location = new Point(0, 3);
            usrcontRow1.Name = "usrcontRow1";
            usrcontRow1.PositionText = "0.0 mm";
            usrcontRow1.ReturnedName = "Returned";
            usrcontRow1.ReturnedNameBackColor = Color.Transparent;
            usrcontRow1.ReturnName = "Return";
            usrcontRow1.ReturnNameBackColor = Color.Transparent;
            usrcontRow1.RowIndex = 1;
            usrcontRow1.RowName = "Cylinder A1";
            usrcontRow1.ShowAdvanceButton = false;
            usrcontRow1.ShowAdvanceLabel = false;
            usrcontRow1.ShowReturnButton = false;
            usrcontRow1.Size = new Size(1000, 52);
            usrcontRow1.TabIndex = 0;
            usrcontRow1.Load += usrcontRow1_Load;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnReadStruct2);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(treeViewSymbols);
            tabPage1.Controls.Add(btnReadStructure);
            tabPage1.Controls.Add(lsbReadSymbols);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1000, 531);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "ReadSymbols";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnReadStruct2
            // 
            btnReadStruct2.Location = new Point(586, 452);
            btnReadStruct2.Name = "btnReadStruct2";
            btnReadStruct2.Size = new Size(75, 23);
            btnReadStruct2.TabIndex = 77;
            btnReadStruct2.Text = "ReadStructure";
            btnReadStruct2.UseVisualStyleBackColor = true;
            btnReadStruct2.Click += btnReadStruct2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(451, 468);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 76;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // treeViewSymbols
            // 
            treeViewSymbols.Location = new Point(431, 30);
            treeViewSymbols.Name = "treeViewSymbols";
            treeViewSymbols.Size = new Size(491, 349);
            treeViewSymbols.TabIndex = 75;
            // 
            // btnReadStructure
            // 
            btnReadStructure.Location = new Point(46, 468);
            btnReadStructure.Name = "btnReadStructure";
            btnReadStructure.Size = new Size(75, 23);
            btnReadStructure.TabIndex = 74;
            btnReadStructure.Text = "btnReadStructure";
            btnReadStructure.UseVisualStyleBackColor = true;
            btnReadStructure.Click += btnReadStructure_Click;
            // 
            // lsbReadSymbols
            // 
            lsbReadSymbols.FormattingEnabled = true;
            lsbReadSymbols.ItemHeight = 15;
            lsbReadSymbols.Location = new Point(23, 30);
            lsbReadSymbols.Name = "lsbReadSymbols";
            lsbReadSymbols.Size = new Size(387, 409);
            lsbReadSymbols.TabIndex = 0;
            lsbReadSymbols.SelectedIndexChanged += lsbReadSymbols_SelectedIndexChanged;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 729);
            Controls.Add(tabControl1);
            Controls.Add(lblmsgViewWarningS6);
            Controls.Add(lblmsgViewWarningS5);
            Controls.Add(lblmsgViewWarningS4);
            Controls.Add(lblmsgViewWarningS3);
            Controls.Add(lblmsgViewWarningS2);
            Controls.Add(lblmsgViewWarningS1);
            Controls.Add(lblmsgViewWarningMachine);
            Controls.Add(lblmsgViewPromptsS6);
            Controls.Add(lblmsgViewPromptsS5);
            Controls.Add(lblmsgViewPromptsS4);
            Controls.Add(lblmsgViewPromptsS3);
            Controls.Add(lblmsgViewPromptsS2);
            Controls.Add(lblmsgViewPromptsS1);
            Controls.Add(lblmsgViewPromptMachine);
            Controls.Add(lblmsgViewAlarmS6);
            Controls.Add(lblmsgViewAlarmS5);
            Controls.Add(lblmsgViewAlarmS4);
            Controls.Add(lblmsgViewAlarmS3);
            Controls.Add(lblmsgViewAlarmS2);
            Controls.Add(lblmsgViewAlarmS1);
            Controls.Add(lblmsgViewAlarmMachine);
            Controls.Add(lblAnyFaultsExist);
            Controls.Add(button4);
            Controls.Add(lblStationName);
            Controls.Add(lblAnyWarnings);
            Controls.Add(lblHomeState);
            Controls.Add(lblFaultState);
            Controls.Add(lblCycleTypeState);
            Controls.Add(lblStationState);
            Controls.Add(btnReturnHome);
            Controls.Add(btnSEOC);
            Controls.Add(btnStartAutoCycle);
            Controls.Add(btnManualMode);
            Controls.Add(btnAutoMode);
            Controls.Add(btnControl);
            Controls.Add(btnMode);
            Controls.Add(btnReset);
            Controls.Add(btnMainMenu);
            HelpButton = true;
            MaximumSize = new Size(1024, 768);
            MinimumSize = new Size(640, 480);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Screen";
            Load += frmMain_Load_1;
            tabControl1.ResumeLayout(false);
            tpMode.ResumeLayout(false);
            tpManualRows.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timGetPLCData;
        private Button btnMainMenu;
        private Button btnReset;
        private Button btnMode;
        private Button btnControl;
        private Button btnAutoMode;
        private Button btnManualMode;
        private Button btnStartAutoCycle;
        private Button btnSEOC;
        private Button btnReturnHome;
        private Label lblStationState;
        private Label lblCycleTypeState;
        private Label lblFaultState;
        private Label lblHomeState;
        private Label lblAnyWarnings;
        private Label lblStationName;
        private OpenFileDialog ofdTc3Project;
        private Button button4;
        private Label lblAnyFaultsExist;
        private Label lblmsgViewAlarmMachine;
        private Label lblmsgViewAlarmS1;
        private Label lblmsgViewAlarmS2;
        private Label lblmsgViewAlarmS3;
        private Label lblmsgViewAlarmS4;
        private Label lblmsgViewAlarmS5;
        private Label lblmsgViewAlarmS6;
        private Label lblmsgViewPromptMachine;
        private Label lblmsgViewPromptsS1;
        private Label lblmsgViewPromptsS2;
        private Label lblmsgViewPromptsS3;
        private Label lblmsgViewPromptsS4;
        private Label lblmsgViewPromptsS5;
        private Label lblmsgViewPromptsS6;
        private Label lblmsgViewWarningMachine;
        private Label lblmsgViewWarningS1;
        private Label lblmsgViewWarningS2;
        private Label lblmsgViewWarningS3;
        private Label lblmsgViewWarningS4;
        private Label lblmsgViewWarningS5;
        private Label lblmsgViewWarningS6;
        private Button btnStation6;
        private Button btnStation5;
        private Button btnStation4;
        private Button btnStation3;
        private Button btnStation2;
        private Button btnStation1;
        private Button btnSelectAll;
        private Button btnAutoCycleStart;
        private Button btnAutoCycleStop;
        private ListBox lbFoundFiles;
        private Button btn06;
        private Button btn05;
        private Button btn04;
        private Button btn03;
        private Button btn02;
        private Button btn01;
        private Button btn26;
        private Button btn25;
        private Button btn24;
        private Button btn23;
        private Button btn22;
        private Button btn21;
        private Button btn20;
        private Button btn16;
        private Button btn15;
        private Button btn14;
        private Button btn13;
        private Button btn12;
        private Button btn11;
        private Button btn10;
        private Button btn00;
        private Button btnPowerOn;
        private Button btnPowerOff;
        private TabControl tabControl1;
        private TabPage tpMode;
        private TabPage tpManualRows;
        private usrcontRow frmRow1;
        private usrcontRow usrcontRow1;
        private usrcontRow usrcontRow3;
        private usrcontRow usrcontRow2;
        private usrcontRow usrcontRow9;
        private usrcontRow usrcontRow8;
        private usrcontRow usrcontRow7;
        private usrcontRow usrcontRow6;
        private usrcontRow usrcontRow5;
        private usrcontRow usrcontRow4;
        private Button btnReadStructure;
        private TabPage tabPage1;
        private ListBox lsbReadSymbols;
        private TreeView treeViewSymbols;
        private Button button1;
        private Button btnReadStruct2;
    }
}
