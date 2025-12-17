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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            btnPowerOn = new Button();
            btnPowerOff = new Button();
            timGetPLCData = new System.Windows.Forms.Timer(components);
            btnStation1 = new Button();
            btnStation2 = new Button();
            btnStation3 = new Button();
            btnStation4 = new Button();
            btnStation5 = new Button();
            btnStation6 = new Button();
            btnAutoCycleStart = new Button();
            btnAutoCycleStop = new Button();
            btn10 = new Button();
            btn11 = new Button();
            btn13 = new Button();
            btn12 = new Button();
            btn16 = new Button();
            btn15 = new Button();
            btn14 = new Button();
            btn26 = new Button();
            btn25 = new Button();
            btn24 = new Button();
            btn23 = new Button();
            btn22 = new Button();
            btn21 = new Button();
            btn20 = new Button();
            btn06 = new Button();
            btn05 = new Button();
            btn04 = new Button();
            btn03 = new Button();
            btn02 = new Button();
            btn01 = new Button();
            btn00 = new Button();
            btnMainMenu = new Button();
            btnReset = new Button();
            btnSelectAll = new Button();
            btnMode = new Button();
            btnControl = new Button();
            btnAutoMode = new Button();
            btnManualMode = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            lblStationState = new Label();
            lblCycleTypeState = new Label();
            lblFaultState = new Label();
            lblHomeState = new Label();
            lblAnyWarnings = new Label();
            lblStationName = new Label();
            ofdTc3Project = new OpenFileDialog();
            button4 = new Button();
            txbSpecialXML = new TextBox();
            btnParse = new Button();
            lbFoundFiles = new ListBox();
            SuspendLayout();
            // 
            // btnPowerOn
            // 
            btnPowerOn.Location = new Point(12, 253);
            btnPowerOn.Name = "btnPowerOn";
            btnPowerOn.Size = new Size(80, 80);
            btnPowerOn.TabIndex = 0;
            btnPowerOn.Text = "POWER ON";
            btnPowerOn.UseVisualStyleBackColor = true;
            // 
            // btnPowerOff
            // 
            btnPowerOff.Location = new Point(12, 167);
            btnPowerOff.Name = "btnPowerOff";
            btnPowerOff.Size = new Size(80, 80);
            btnPowerOff.TabIndex = 1;
            btnPowerOff.Text = "POWER OFF";
            btnPowerOff.UseVisualStyleBackColor = true;
            // 
            // timGetPLCData
            // 
            timGetPLCData.Interval = 1000;
            timGetPLCData.Tick += timGetPLCData_Tick;
            // 
            // btnStation1
            // 
            btnStation1.Location = new Point(139, 540);
            btnStation1.Name = "btnStation1";
            btnStation1.Size = new Size(120, 80);
            btnStation1.TabIndex = 3;
            btnStation1.Text = "Station 1";
            btnStation1.UseVisualStyleBackColor = true;
            // 
            // btnStation2
            // 
            btnStation2.Location = new Point(265, 540);
            btnStation2.Name = "btnStation2";
            btnStation2.Size = new Size(120, 80);
            btnStation2.TabIndex = 4;
            btnStation2.Text = "Station 2";
            btnStation2.UseVisualStyleBackColor = true;
            // 
            // btnStation3
            // 
            btnStation3.Location = new Point(391, 540);
            btnStation3.Name = "btnStation3";
            btnStation3.Size = new Size(120, 80);
            btnStation3.TabIndex = 5;
            btnStation3.Text = "Station 3";
            btnStation3.UseVisualStyleBackColor = true;
            // 
            // btnStation4
            // 
            btnStation4.Location = new Point(517, 540);
            btnStation4.Name = "btnStation4";
            btnStation4.Size = new Size(120, 80);
            btnStation4.TabIndex = 6;
            btnStation4.Text = "Station 4";
            btnStation4.UseVisualStyleBackColor = true;
            // 
            // btnStation5
            // 
            btnStation5.Location = new Point(643, 540);
            btnStation5.Name = "btnStation5";
            btnStation5.Size = new Size(120, 80);
            btnStation5.TabIndex = 7;
            btnStation5.Text = "Station 5";
            btnStation5.UseVisualStyleBackColor = true;
            // 
            // btnStation6
            // 
            btnStation6.Location = new Point(769, 540);
            btnStation6.Name = "btnStation6";
            btnStation6.Size = new Size(120, 80);
            btnStation6.TabIndex = 8;
            btnStation6.Text = "Station 6";
            btnStation6.UseVisualStyleBackColor = true;
            // 
            // btnAutoCycleStart
            // 
            btnAutoCycleStart.Location = new Point(916, 270);
            btnAutoCycleStart.Name = "btnAutoCycleStart";
            btnAutoCycleStart.Size = new Size(80, 80);
            btnAutoCycleStart.TabIndex = 10;
            btnAutoCycleStart.Text = "START AUTO CYCLE";
            btnAutoCycleStart.UseVisualStyleBackColor = true;
            // 
            // btnAutoCycleStop
            // 
            btnAutoCycleStop.Location = new Point(916, 184);
            btnAutoCycleStop.Name = "btnAutoCycleStop";
            btnAutoCycleStop.Size = new Size(80, 80);
            btnAutoCycleStop.TabIndex = 9;
            btnAutoCycleStop.Text = "STOP AUTO CYCLE";
            btnAutoCycleStop.UseVisualStyleBackColor = true;
            // 
            // btn10
            // 
            btn10.Location = new Point(188, 295);
            btn10.Name = "btn10";
            btn10.Size = new Size(80, 80);
            btn10.TabIndex = 11;
            btn10.Text = "CONTINUOUS CYCLE";
            btn10.UseVisualStyleBackColor = true;
            // 
            // btn11
            // 
            btn11.Location = new Point(274, 295);
            btn11.Name = "btn11";
            btn11.Size = new Size(80, 80);
            btn11.TabIndex = 12;
            btn11.Text = "DRY CYCLE";
            btn11.UseVisualStyleBackColor = true;
            // 
            // btn13
            // 
            btn13.Location = new Point(446, 295);
            btn13.Name = "btn13";
            btn13.Size = new Size(80, 80);
            btn13.TabIndex = 14;
            btn13.Text = "SINGLE CYCLE";
            btn13.UseVisualStyleBackColor = true;
            btn13.Click += btn13_Click;
            // 
            // btn12
            // 
            btn12.Location = new Point(360, 295);
            btn12.Name = "btn12";
            btn12.Size = new Size(80, 80);
            btn12.TabIndex = 13;
            btn12.Text = "STOP END OF CYCLE";
            btn12.UseVisualStyleBackColor = true;
            // 
            // btn16
            // 
            btn16.Location = new Point(704, 295);
            btn16.Name = "btn16";
            btn16.Size = new Size(80, 80);
            btn16.TabIndex = 17;
            btn16.UseVisualStyleBackColor = true;
            // 
            // btn15
            // 
            btn15.Location = new Point(618, 295);
            btn15.Name = "btn15";
            btn15.Size = new Size(80, 80);
            btn15.TabIndex = 16;
            btn15.Text = "SILENCE HORN";
            btn15.UseVisualStyleBackColor = true;
            // 
            // btn14
            // 
            btn14.Location = new Point(532, 295);
            btn14.Name = "btn14";
            btn14.Size = new Size(80, 80);
            btn14.TabIndex = 15;
            btn14.UseVisualStyleBackColor = true;
            // 
            // btn26
            // 
            btn26.Location = new Point(704, 381);
            btn26.Name = "btn26";
            btn26.Size = new Size(80, 80);
            btn26.TabIndex = 24;
            btn26.UseVisualStyleBackColor = true;
            btn26.Click += btn26_Click;
            // 
            // btn25
            // 
            btn25.Location = new Point(618, 381);
            btn25.Name = "btn25";
            btn25.Size = new Size(80, 80);
            btn25.TabIndex = 23;
            btn25.UseVisualStyleBackColor = true;
            // 
            // btn24
            // 
            btn24.Location = new Point(532, 381);
            btn24.Name = "btn24";
            btn24.Size = new Size(80, 80);
            btn24.TabIndex = 22;
            btn24.UseVisualStyleBackColor = true;
            // 
            // btn23
            // 
            btn23.Location = new Point(446, 381);
            btn23.Name = "btn23";
            btn23.Size = new Size(80, 80);
            btn23.TabIndex = 21;
            btn23.Text = "ENABLE PENDANT";
            btn23.UseVisualStyleBackColor = true;
            // 
            // btn22
            // 
            btn22.Location = new Point(360, 381);
            btn22.Name = "btn22";
            btn22.Size = new Size(80, 80);
            btn22.TabIndex = 20;
            btn22.Text = "LOCK ACCESS GATE";
            btn22.UseVisualStyleBackColor = true;
            // 
            // btn21
            // 
            btn21.Location = new Point(274, 381);
            btn21.Name = "btn21";
            btn21.Size = new Size(80, 80);
            btn21.TabIndex = 19;
            btn21.Text = "GATE 2 ACCESS REQUEST";
            btn21.UseVisualStyleBackColor = true;
            // 
            // btn20
            // 
            btn20.Location = new Point(188, 381);
            btn20.Name = "btn20";
            btn20.Size = new Size(80, 80);
            btn20.TabIndex = 18;
            btn20.Text = "GATE 1 ACCESS REQUEST";
            btn20.UseVisualStyleBackColor = true;
            // 
            // btn06
            // 
            btn06.Location = new Point(704, 209);
            btn06.Name = "btn06";
            btn06.Size = new Size(80, 80);
            btn06.TabIndex = 31;
            btn06.UseVisualStyleBackColor = true;
            // 
            // btn05
            // 
            btn05.Location = new Point(618, 209);
            btn05.Name = "btn05";
            btn05.Size = new Size(80, 80);
            btn05.TabIndex = 30;
            btn05.Text = "ENABLE REMOTE CONTROL";
            btn05.UseVisualStyleBackColor = true;
            // 
            // btn04
            // 
            btn04.Location = new Point(532, 209);
            btn04.Name = "btn04";
            btn04.Size = new Size(80, 80);
            btn04.TabIndex = 29;
            btn04.UseVisualStyleBackColor = true;
            // 
            // btn03
            // 
            btn03.Location = new Point(446, 209);
            btn03.Name = "btn03";
            btn03.Size = new Size(80, 80);
            btn03.TabIndex = 28;
            btn03.UseVisualStyleBackColor = true;
            // 
            // btn02
            // 
            btn02.Location = new Point(360, 209);
            btn02.Name = "btn02";
            btn02.Size = new Size(80, 80);
            btn02.TabIndex = 27;
            btn02.Text = "SEMI-AUTO MODE";
            btn02.UseVisualStyleBackColor = true;
            // 
            // btn01
            // 
            btn01.Location = new Point(274, 209);
            btn01.Name = "btn01";
            btn01.Size = new Size(80, 80);
            btn01.TabIndex = 26;
            btn01.Text = "MANUAL MODE";
            btn01.UseVisualStyleBackColor = true;
            // 
            // btn00
            // 
            btn00.Location = new Point(188, 209);
            btn00.Name = "btn00";
            btn00.Size = new Size(80, 80);
            btn00.TabIndex = 25;
            btn00.Text = "AUTO MODE";
            btn00.UseVisualStyleBackColor = true;
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
            // btnSelectAll
            // 
            btnSelectAll.Location = new Point(53, 540);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(80, 80);
            btnSelectAll.TabIndex = 34;
            btnSelectAll.Text = "Select All";
            btnSelectAll.UseVisualStyleBackColor = true;
            // 
            // btnMode
            // 
            btnMode.Location = new Point(12, 637);
            btnMode.Name = "btnMode";
            btnMode.Size = new Size(80, 80);
            btnMode.TabIndex = 35;
            btnMode.Text = "Mode";
            btnMode.UseVisualStyleBackColor = true;
            // 
            // btnControl
            // 
            btnControl.Location = new Point(98, 637);
            btnControl.Name = "btnControl";
            btnControl.Size = new Size(80, 80);
            btnControl.TabIndex = 36;
            btnControl.Text = "Control";
            btnControl.UseVisualStyleBackColor = true;
            // 
            // btnAutoMode
            // 
            btnAutoMode.Location = new Point(234, 637);
            btnAutoMode.Name = "btnAutoMode";
            btnAutoMode.Size = new Size(80, 80);
            btnAutoMode.TabIndex = 37;
            btnAutoMode.Text = "AUTO MODE";
            btnAutoMode.UseVisualStyleBackColor = true;
            // 
            // btnManualMode
            // 
            btnManualMode.Location = new Point(320, 637);
            btnManualMode.Name = "btnManualMode";
            btnManualMode.Size = new Size(80, 80);
            btnManualMode.TabIndex = 38;
            btnManualMode.Text = "MANUAL MODE";
            btnManualMode.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(406, 637);
            button1.Name = "button1";
            button1.Size = new Size(80, 80);
            button1.TabIndex = 39;
            button1.Text = "START AUTO CYCLE";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(492, 637);
            button2.Name = "button2";
            button2.Size = new Size(80, 80);
            button2.TabIndex = 40;
            button2.Text = "STOP END OF CYCLE";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(578, 637);
            button3.Name = "button3";
            button3.Size = new Size(80, 80);
            button3.TabIndex = 41;
            button3.Text = "RETURN HOME";
            button3.UseVisualStyleBackColor = true;
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
            lblStationName.Size = new Size(153, 20);
            lblStationName.TabIndex = 47;
            lblStationName.Text = "Station Name, header.stationNameSelect, StationNames";
            lblStationName.TextAlign = ContentAlignment.MiddleCenter;
            lblStationName.Click += lblStationName_Click;
            // 
            // ofdTc3Project
            // 
            ofdTc3Project.FileName = "openFileDialog1";
            ofdTc3Project.Filter = "TwinCAT3 Projects | *.sln";
            ofdTc3Project.Title = "Select a TwinCAT3 Project...";
            ofdTc3Project.FileOk += ofdTc3Project_FileOk;
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
            // txbSpecialXML
            // 
            txbSpecialXML.Location = new Point(826, 400);
            txbSpecialXML.Multiline = true;
            txbSpecialXML.Name = "txbSpecialXML";
            txbSpecialXML.Size = new Size(100, 95);
            txbSpecialXML.TabIndex = 49;
            txbSpecialXML.Text = resources.GetString("txbSpecialXML.Text");
            // 
            // btnParse
            // 
            btnParse.Location = new Point(826, 501);
            btnParse.Name = "btnParse";
            btnParse.Size = new Size(75, 23);
            btnParse.TabIndex = 50;
            btnParse.Text = "button5";
            btnParse.UseVisualStyleBackColor = true;
            btnParse.Click += btnParse_Click;
            // 
            // lbFoundFiles
            // 
            lbFoundFiles.FormattingEnabled = true;
            lbFoundFiles.ItemHeight = 15;
            lbFoundFiles.Location = new Point(209, 50);
            lbFoundFiles.Name = "lbFoundFiles";
            lbFoundFiles.Size = new Size(477, 139);
            lbFoundFiles.TabIndex = 51;
            lbFoundFiles.SelectedIndexChanged += lbFoundFiles_SelectedIndexChanged;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 729);
            Controls.Add(lbFoundFiles);
            Controls.Add(btnParse);
            Controls.Add(txbSpecialXML);
            Controls.Add(button4);
            Controls.Add(lblStationName);
            Controls.Add(lblAnyWarnings);
            Controls.Add(lblHomeState);
            Controls.Add(lblFaultState);
            Controls.Add(lblCycleTypeState);
            Controls.Add(lblStationState);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnManualMode);
            Controls.Add(btnAutoMode);
            Controls.Add(btnControl);
            Controls.Add(btnMode);
            Controls.Add(btnSelectAll);
            Controls.Add(btnReset);
            Controls.Add(btnMainMenu);
            Controls.Add(btn06);
            Controls.Add(btn05);
            Controls.Add(btn04);
            Controls.Add(btn03);
            Controls.Add(btn02);
            Controls.Add(btn01);
            Controls.Add(btn00);
            Controls.Add(btn26);
            Controls.Add(btn25);
            Controls.Add(btn24);
            Controls.Add(btn23);
            Controls.Add(btn22);
            Controls.Add(btn21);
            Controls.Add(btn20);
            Controls.Add(btn16);
            Controls.Add(btn15);
            Controls.Add(btn14);
            Controls.Add(btn13);
            Controls.Add(btn12);
            Controls.Add(btn11);
            Controls.Add(btn10);
            Controls.Add(btnAutoCycleStart);
            Controls.Add(btnAutoCycleStop);
            Controls.Add(btnStation6);
            Controls.Add(btnStation5);
            Controls.Add(btnStation4);
            Controls.Add(btnStation3);
            Controls.Add(btnStation2);
            Controls.Add(btnStation1);
            Controls.Add(btnPowerOff);
            Controls.Add(btnPowerOn);
            HelpButton = true;
            MaximumSize = new Size(1024, 768);
            MinimumSize = new Size(640, 480);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Screen";
            Load += frmMain_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPowerOn;
        private Button btnPowerOff;
        private System.Windows.Forms.Timer timGetPLCData;
        private Button btnStation1;
        private Button btnStation2;
        private Button btnStation3;
        private Button btnStation4;
        private Button btnStation5;
        private Button btnStation6;
        private Button btnAutoCycleStart;
        private Button btnAutoCycleStop;
        private Button btn10;
        private Button btn11;
        private Button btn13;
        private Button btn12;
        private Button btn16;
        private Button btn15;
        private Button btn14;
        private Button btn26;
        private Button btn25;
        private Button btn24;
        private Button btn23;
        private Button btn22;
        private Button btn21;
        private Button btn20;
        private Button btn06;
        private Button btn05;
        private Button btn04;
        private Button btn03;
        private Button btn02;
        private Button btn01;
        private Button btn00;
        private Button btnMainMenu;
        private Button btnReset;
        private Button btnSelectAll;
        private Button btnMode;
        private Button btnControl;
        private Button btnAutoMode;
        private Button btnManualMode;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label lblStationState;
        private Label lblCycleTypeState;
        private Label lblFaultState;
        private Label lblHomeState;
        private Label lblAnyWarnings;
        private Label lblStationName;
        private OpenFileDialog ofdTc3Project;
        private Button button4;
        private TextBox txbSpecialXML;
        private Button btnParse;
        private ListBox lbFoundFiles;
    }
}
