namespace TOAST_HMI
{
    partial class usrcontRow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnRowReturnReq = new Button();
            lblRowReturned = new Label();
            lblRowReturn = new Label();
            lblRowPosn = new Label();
            lblRowName = new Label();
            lblRowAdvanced = new Label();
            lblRowAdvance = new Label();
            btnRowAdvanceReq = new Button();
            lblAdvancePrompt = new Label();
            lblReturnPrompt = new Label();
            SuspendLayout();
            // 
            // btnRowReturnReq
            // 
            btnRowReturnReq.Location = new Point(895, -1);
            btnRowReturnReq.Name = "btnRowReturnReq";
            btnRowReturnReq.Size = new Size(80, 53);
            btnRowReturnReq.TabIndex = 54;
            btnRowReturnReq.Text = "1";
            btnRowReturnReq.UseVisualStyleBackColor = true;
            // 
            // lblRowReturned
            // 
            lblRowReturned.BorderStyle = BorderStyle.FixedSingle;
            lblRowReturned.Location = new Point(613, 29);
            lblRowReturned.Name = "lblRowReturned";
            lblRowReturned.Size = new Size(276, 23);
            lblRowReturned.TabIndex = 53;
            lblRowReturned.Text = "Returned";
            lblRowReturned.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblRowReturn
            // 
            lblRowReturn.BorderStyle = BorderStyle.FixedSingle;
            lblRowReturn.Location = new Point(613, 0);
            lblRowReturn.Name = "lblRowReturn";
            lblRowReturn.Size = new Size(276, 23);
            lblRowReturn.TabIndex = 52;
            lblRowReturn.Text = "Return";
            lblRowReturn.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblRowPosn
            // 
            lblRowPosn.BorderStyle = BorderStyle.FixedSingle;
            lblRowPosn.Location = new Point(392, 29);
            lblRowPosn.Name = "lblRowPosn";
            lblRowPosn.Size = new Size(215, 23);
            lblRowPosn.TabIndex = 51;
            lblRowPosn.Text = "0.0 mm";
            lblRowPosn.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRowName
            // 
            lblRowName.BorderStyle = BorderStyle.FixedSingle;
            lblRowName.Location = new Point(392, 0);
            lblRowName.Name = "lblRowName";
            lblRowName.Size = new Size(215, 23);
            lblRowName.TabIndex = 50;
            lblRowName.Text = "Cylinder A1";
            lblRowName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRowAdvanced
            // 
            lblRowAdvanced.BorderStyle = BorderStyle.FixedSingle;
            lblRowAdvanced.Location = new Point(111, 29);
            lblRowAdvanced.Name = "lblRowAdvanced";
            lblRowAdvanced.Size = new Size(275, 23);
            lblRowAdvanced.TabIndex = 49;
            lblRowAdvanced.Text = "Advance";
            lblRowAdvanced.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRowAdvance
            // 
            lblRowAdvance.BackColor = SystemColors.Control;
            lblRowAdvance.BorderStyle = BorderStyle.FixedSingle;
            lblRowAdvance.Location = new Point(111, 0);
            lblRowAdvance.Name = "lblRowAdvance";
            lblRowAdvance.Size = new Size(275, 23);
            lblRowAdvance.TabIndex = 48;
            lblRowAdvance.Text = "Advance";
            lblRowAdvance.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnRowAdvanceReq
            // 
            btnRowAdvanceReq.Location = new Point(25, 0);
            btnRowAdvanceReq.Name = "btnRowAdvanceReq";
            btnRowAdvanceReq.Size = new Size(80, 52);
            btnRowAdvanceReq.TabIndex = 47;
            btnRowAdvanceReq.Text = "1";
            btnRowAdvanceReq.UseVisualStyleBackColor = true;
            // 
            // lblAdvancePrompt
            // 
            lblAdvancePrompt.BorderStyle = BorderStyle.FixedSingle;
            lblAdvancePrompt.Location = new Point(3, 0);
            lblAdvancePrompt.Name = "lblAdvancePrompt";
            lblAdvancePrompt.Size = new Size(19, 52);
            lblAdvancePrompt.TabIndex = 55;
            lblAdvancePrompt.Text = "ap";
            // 
            // lblReturnPrompt
            // 
            lblReturnPrompt.BorderStyle = BorderStyle.FixedSingle;
            lblReturnPrompt.Location = new Point(978, 0);
            lblReturnPrompt.Name = "lblReturnPrompt";
            lblReturnPrompt.Size = new Size(19, 52);
            lblReturnPrompt.TabIndex = 56;
            lblReturnPrompt.Text = "rp";
            // 
            // usrcontRow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblReturnPrompt);
            Controls.Add(lblAdvancePrompt);
            Controls.Add(btnRowReturnReq);
            Controls.Add(lblRowReturned);
            Controls.Add(lblRowReturn);
            Controls.Add(lblRowPosn);
            Controls.Add(lblRowName);
            Controls.Add(lblRowAdvanced);
            Controls.Add(lblRowAdvance);
            Controls.Add(btnRowAdvanceReq);
            Name = "usrcontRow";
            Size = new Size(1000, 52);
            ResumeLayout(false);
        }

        #endregion

        private Button btnRowReturnReq;
        private Label lblRowReturned;
        private Label lblRowReturn;
        private Label lblRowPosn;
        private Label lblRowName;
        private Label lblRowAdvanced;
        private Label lblRowAdvance;
        private Button btnRowAdvanceReq;
        private Label lblAdvancePrompt;
        private Label lblReturnPrompt;
    }
}