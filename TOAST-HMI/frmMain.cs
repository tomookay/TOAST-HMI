using System;
using System.Net.Sockets;
using System.Windows.Forms;
using TwinCAT.Ads;
using TwinCAT.TypeSystem;
using static System.Runtime.InteropServices.JavaScript.JSType;

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



        private void btnPowerOn_Click(object sender, EventArgs e)
        {
            // TODO: replace with the actual symbol name in the PLC (for example "GVL.bPowerOn" or "MAIN.bPowerOn")
            WriteBool("gHMIButtons.btnMode.btnPowerOnPressed", true);
        }

        private void btnServicesOn_Click(object sender, EventArgs e)
        {
            // TODO: replace with actual symbol
            WriteBool("gHMIButtons.btnMode.bServicesOn", true);
        }

        private void btnPowerOff_Click(object sender, EventArgs e)
        {
            // TODO: replace with actual symbol
            WriteBool("gHMIButtons.btnMode.btnPowerOffPressed", false);
        }

        private void frmMain_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }



        private void button22_Click(object sender, EventArgs e)
        {


        }

        private void btnReadArray_Click(object sender, EventArgs e)
        {
            // Step 1: ensure ADS client is connected
            if (_adsClient == null || !_adsClient.IsConnected)
            {
                MessageBox.Show("Not connected to PLC.", "ADS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            uint handle = 0;
            try
            {
                handle = _adsClient.CreateVariableHandle("gHMIData.gStationSelected");

                // TODO: set elementCount and elementSize to match the PLC symbol type/length.
                // The original code read 100 Int16 values => elementCount = 100, elementSize = sizeof(short).
                int elementCount = 6;
                int elementSize = sizeof(short); // change to 1 for byte, 4 for int32, etc.
                int readLength = checked(elementCount * elementSize);

                // Read bytes from PLC by variable handle
                var result = _adsClient.ReadAsResult(handle, readLength);
                result.ThrowOnError();

                // result.Data is ReadOnlyMemory<byte>
                byte[] buffer = result.Data.ToArray(); // copy into byte[] to use BinaryReader/MemoryStream

                lbArray.Items.Clear();
                using (var ms = new System.IO.MemoryStream(buffer))
                using (var binRead = new System.IO.BinaryReader(ms))
                {
                    for (int i = 0; i < elementCount; i++)
                    {
                        // read as bool because elementSize == sizeof(short)
                        bool val = binRead.ReadBoolean();
                        lbArray.Items.Add(val.ToString());
                    }
                }
            }
            catch (AdsErrorException ex)
            {
                MessageBox.Show($"ADS read error: {ex.Message}", "ADS Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                if (handle != 0)
                {
                    try { _adsClient?.DeleteVariableHandle(handle); } catch { /* ignore */ }
                }
            }
        }

        private void lbArray_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
