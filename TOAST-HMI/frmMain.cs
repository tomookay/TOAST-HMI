using System;
using System.Windows.Forms;
using TwinCAT.Ads;

namespace TOAST_HMI
{
    public partial class frmMain : Form
    {
        // Use a nullable field and a consistent camelCase name to match usages below.
        private AdsClient? _adsClient;
        // TODO: set to your PLC AMS Net ID (e.g. "5.25.123.1.1") and port (default 851)
        private readonly string _amsNetId = "5.25.123.1.1.1";
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

                    // Read the bool[6] from the PLC once immediately after connect
                    ReadStationSelectedFromPlc();
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

        // Reads a PLC array of BOOL (length = gStationSelected.Length) into gStationSelected.
        // Replace the symbol below with the actual symbol name in your PLC (example: "GVL.gStationSelected").
        private void ReadStationSelectedFromPlc()
        {
            if (_adsClient == null || !_adsClient.IsConnected)
            {
                // Not connected - nothing to do
                return;
            }

            const string plcSymbol = "GVL.gStationSelected"; 
            uint handle = 0;
            try
            {
                handle = _adsClient.CreateVariableHandle(plcSymbol);

                // First attempt: let ADS marshal directly to bool[]
                object? read = null;
                try
                {
                    read = _adsClient.ReadAny(handle, typeof(bool[]));
                }
                catch
                {
                    // ignore and try fallbacks
                }

                if (read is bool[] boolArr)
                {
                    // Copy up to our buffer length
                    int copyLen = Math.Min(boolArr.Length, gStationSelected.Length);
                    Array.Clear(gStationSelected, 0, gStationSelected.Length);
                    Array.Copy(boolArr, gStationSelected, copyLen);
                    return;
                }

                // Fallback 1: ADS might return an object[] of boxed bools
                if (read is object[] objArr)
                {
                    for (int i = 0; i < gStationSelected.Length && i < objArr.Length; i++)
                        gStationSelected[i] = Convert.ToBoolean(objArr[i]);
                    return;
                }

                // Fallback 2: read raw bytes and interpret non-zero as true.
                // Many PLC BOOL arrays are marshaled as bytes where 0 == false, non-zero == true.
                byte[]? bytes = null;
                try
                {
                    bytes = (byte[]?)_adsClient.ReadAny(handle, typeof(byte[]));
                }
                catch
                {
                    // if reading bytes fails, try ReadAny to byte[]
                    try
                    {
                        var bobj = _adsClient.ReadAny(handle, typeof(byte[]));
                        if (bobj is byte[] bb) bytes = bb;
                    }
                    catch
                    {
                        // give up
                    }
                }

                if (bytes != null)
                {
                    for (int i = 0; i < gStationSelected.Length && i < bytes.Length; i++)
                        gStationSelected[i] = bytes[i] != 0;
                    // If bytes shorter than target, remaining values stay false (initialized)
                    return;
                }

                // If we reach here, we couldn't marshal the data; leave gStationSelected as-is or clear it.
                Array.Clear(gStationSelected, 0, gStationSelected.Length);
            }
            catch (AdsErrorException ex)
            {
                MessageBox.Show($"ADS read error for {plcSymbol}: {ex.Message}", "ADS Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Read error for {plcSymbol}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            WriteBool("GVL.bServicesOn", true);
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {


        }
    }
}
