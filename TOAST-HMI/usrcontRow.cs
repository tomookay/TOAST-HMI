using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TOAST_HMI
{
    public partial class usrcontRow : UserControl
    {
        public usrcontRow()
        {
            InitializeComponent();

            // wire up local button clicks to public events
            btnRowAdvanceReq.Click += (s, e) => AdvanceClicked?.Invoke(this, EventArgs.Empty);
            btnRowReturnReq.Click += (s, e) => ReturnClicked?.Invoke(this, EventArgs.Empty);
        }

        // Events consumers can subscribe to
        [Browsable(true)]
        [Category("Action")]
        [Description("Raised when the Advance button is clicked.")]
        public event EventHandler? AdvanceClicked;

        [Browsable(true)]
        [Category("Action")]
        [Description("Raised when the Return button is clicked.")]
        public event EventHandler? ReturnClicked;

        // Optional index so parent can identify which row raised the event
        [Browsable(true)]
        [Category("Data")]
        [Description("Index of this row (set by parent).")]
        public int RowIndex { get; set; }

        // Expose the name label
        [Browsable(true)]
        [Category("Data")]
        [Description("Display name for the row.")]
        public string RowName
        {
            get => GetTextSafe(lblRowName);
            set => SetTextSafe(lblRowName, value);
        }

        public string AdvanceName
        {
            get => GetTextSafe(lblRowAdvance);
            set => SetTextSafe(lblRowAdvance, value);
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Background color of the Advance label.")]
        public Color AdvanceNameBackColor
        {
            get => GetBackColorSafe(lblRowAdvance);
            set => SetBackColorSafe(lblRowAdvance, value);
        }

        public string AdvancedName
        {
            get => GetTextSafe(lblRowAdvanced);
            set => SetTextSafe(lblRowAdvanced, value);
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Background color of the Advanced label.")]
        public Color AdvancedNameBackColor
        {
            get => GetBackColorSafe(lblRowAdvanced);
            set => SetBackColorSafe(lblRowAdvanced, value);
        }

        public string ReturnName
        {
            get => GetTextSafe(lblRowReturn);
            set => SetTextSafe(lblRowReturn, value);
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Background color of the Return label.")]
        public Color ReturnNameBackColor
        {
            get => GetBackColorSafe(lblRowReturn);
            set => SetBackColorSafe(lblRowReturn, value);
        }

        public string ReturnedName
        {
            get => GetTextSafe(lblRowReturned);
            set => SetTextSafe(lblRowReturned, value);
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Background color of the Returned label.")]
        public Color ReturnedNameBackColor
        {
            get => GetBackColorSafe(lblRowReturned);
            set => SetBackColorSafe(lblRowReturned, value);
        }

        // Expose the position label text
        [Browsable(true)]
        [Category("Data")]
        [Description("Position text (e.g. '0.0 mm').")]
        public string PositionText
        {
            get => GetTextSafe(lblRowPosn);
            set => SetTextSafe(lblRowPosn, value);
        }

        // Expose returned state as boolean (and update the label)
        [Browsable(true)]
        [Category("Data")]
        [Description("Whether this row is returned.")]
        public bool IsReturned
        {
            get => GetTextSafe(lblRowReturned) == "Returned";
            set => SetTextSafe(lblRowReturned, value ? "Returned" : string.Empty);
        }

        // Expose whether the advance label is visible (you can change behaviour as needed)
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Show or hide the lblRowAdvance.")]
        public bool ShowAdvanceLabel
        {
            get => lblRowAdvance.Visible;
            set => SetVisibleSafe(lblRowAdvance, value);
        }

        //show / hide lblRowAdvanced
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Show or hide the lblRowAdvanced.")]
        public bool ShowAdvancedLabel
        {
            get => lblRowAdvanced.Visible;
            set => SetVisibleSafe(lblRowAdvanced, value);
        }

        //show hide lblRowReturn
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Show or hide the lblRowReturn.")]
        public bool ShowReturnLabel
        {
            get => lblRowReturn.Visible;
            set => SetVisibleSafe(lblRowReturn, value);
        }

        //show hide lblRowReturned
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Show or hide the lblRowReturned.")]
        public bool ShowReturnedLabel
        {
            get => lblRowReturned.Visible;
            set => SetVisibleSafe(lblRowReturned, value);
        }

        //show hide pbAdvancePromptFilled
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Show or hide the pbAdvancePromptFilled.")]
        public bool ShowAdvancePrompt
        {
            get => pbAdvancePromptFilled.Visible;
            set => SetVisibleSafe(pbAdvancePromptFilled, value);
        }

        //show hide pbReturnPromptNotFilled
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Show or hide the pbReturnPromptNotFilled.")]
        public bool ShowReturnPrompt
        {
            get => pbReturnPromptNotFilled.Visible;
            set => SetVisibleSafe(pbReturnPromptNotFilled, value);
        }



        // New: expose Advance/Return request button visibility so frmMain (or any parent) can show them
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Show or hide the Advance request button.")]
        public bool ShowAdvanceButton
        {
            get => btnRowAdvanceReq.Visible;
            set => SetVisibleSafe(btnRowAdvanceReq, value);
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Show or hide the Return request button.")]
        public bool ShowReturnButton
        {
            get => btnRowReturnReq.Visible;
            set => SetVisibleSafe(btnRowReturnReq, value);
        }

        //show lblRowPosn
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Show or hide the lblRowPosn")]
        public bool ShowlblRowPosn
        {
            get => lblRowPosn.Visible;
            set => SetVisibleSafe(lblRowPosn, value);
        }

        //show lblRowName
        [Browsable(true)]
        [Category("Appearance")]
        [Description("Show or hide the lblRowName")]
        public bool ShowlblRowName
        {
            get => lblRowName.Visible;
            set => SetVisibleSafe(lblRowName, value);
        }

        //hide pbAdvancePromptFilled
        [Browsable(true)]
        [Category("Appearance")]
        [Description("show or hide pbAdvancePromptFilled")]
        public bool ShowpbAdvancePromptFilled
        {
            get => pbAdvancePromptFilled.Visible;
            set => SetVisibleSafe(pbAdvancePromptFilled, value);
        }

        //hide pbReturnPromptFilled
        [Browsable(true)]
        [Category("Appearance")]
        [Description("show or hide pbReturnPromptFilled")]
        public bool ShowpbReturnPromptFilled
        {
            get => pbReturnPromptFilled.Visible;
            set => SetVisibleSafe(pbReturnPromptFilled, value);
        }

        //pbAdvanceFilled
        [Browsable(true)]
        [Category("Appearance")]
        [Description("show or hide pbAdvanceFilled")]
        public bool ShowpbAdvanceFilled
        {
            get => pbAdvanceFilled.Visible;
            set => SetVisibleSafe(pbAdvanceFilled, value);
        }

        //pbReturnFilled
        [Browsable(true)]
        [Category("Appearance")]
        [Description("show or hide pbReturnFilled")]
        public bool ShowpbReturnFilled
        {
            get => pbReturnFilled.Visible;
            set => SetVisibleSafe(pbReturnFilled, value);
        }



        // Convenience method a parent can call to ensure both action buttons are visible
        public void EnsureActionButtonsVisible()
        {
            SetVisibleSafe(btnRowAdvanceReq, true);
            SetVisibleSafe(btnRowReturnReq, true);
        }

        // New: allow frmMain (or any parent) to programmatically "press" the buttons
        // These perform a proper click (so visual feedback and Click handlers / events run).
        public void PerformAdvanceRequest()
        {
            if (btnRowAdvanceReq.IsDisposed) return;
            if (btnRowAdvanceReq.InvokeRequired)
            {
                btnRowAdvanceReq.Invoke(new Action(() => btnRowAdvanceReq.PerformClick()));
            }
            else
            {
                btnRowAdvanceReq.PerformClick();
            }
        }

        public void PerformReturnRequest()
        {
            if (btnRowReturnReq.IsDisposed) return;
            if (btnRowReturnReq.InvokeRequired)
            {
                btnRowReturnReq.Invoke(new Action(() => btnRowReturnReq.PerformClick()));
            }
            else
            {
                btnRowReturnReq.PerformClick();
            }
        }

        // Alternative: raise the event without simulating button UI (useful for non-UI callers)
        public void TriggerAdvanceEvent()
        {
            AdvanceClicked?.Invoke(this, EventArgs.Empty);
        }

        public void TriggerReturnEvent()
        {
            ReturnClicked?.Invoke(this, EventArgs.Empty);
        }

        // Allow enabling/disabling action buttons together (thread-safe)
        public void SetActionButtonsEnabled(bool enabled)
        {
            if (btnRowAdvanceReq.IsDisposed || btnRowReturnReq.IsDisposed) return;

            if (btnRowAdvanceReq.InvokeRequired || btnRowReturnReq.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    btnRowAdvanceReq.Enabled = enabled;
                    btnRowReturnReq.Enabled = enabled;
                }));
            }
            else
            {
                btnRowAdvanceReq.Enabled = enabled;
                btnRowReturnReq.Enabled = enabled;
            }
        }

        // Thread-safe getters/setters helpers
        private string GetTextSafe(Control ctrl)
        {
            if (ctrl.InvokeRequired)
                return (string)ctrl.Invoke(new Func<string>(() => ctrl.Text));
            return ctrl.Text;
        }

        private void SetTextSafe(Control ctrl, string text)
        {
            if (ctrl.IsDisposed) return;
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(new Action(() => ctrl.Text = text));
            }
            else
            {
                ctrl.Text = text;
            }
        }

        private void SetVisibleSafe(Control ctrl, bool visible)
        {
            if (ctrl.IsDisposed) return;
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(new Action(() => ctrl.Visible = visible));
            }
            else
            {
                ctrl.Visible = visible;
            }
        }

        private Color GetBackColorSafe(Control ctrl)
        {
            if (ctrl.IsDisposed) return SystemColors.Control;
            if (ctrl.InvokeRequired)
                return (Color)ctrl.Invoke(new Func<Color>(() => ctrl.BackColor));
            return ctrl.BackColor;
        }

        private void SetBackColorSafe(Control ctrl, Color color)
        {
            if (ctrl.IsDisposed) return;
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(new Action(() => ctrl.BackColor = color));
            }
            else
            {
                ctrl.BackColor = color;
            }
        }
    }
}
