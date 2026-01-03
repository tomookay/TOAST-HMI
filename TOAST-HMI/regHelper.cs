using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;

namespace TOAST_HMI
{
    internal interface regHelper
    {
        //registry location for saving settings
        private const string RegBasePath = @"Software\TOAST-HMI";

        static amsdata LoadSettingsFromRegistry()
        {
            amsdata connectionData = new amsdata();
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(RegBasePath))
                {
                    if (key == null)
                    {
                        MessageBox.Show("No base key found in registry. Using default settings.", "Registry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connectionData.amsPort = 851;
                        connectionData.amsNetId = "local";
                    }

                    var local = key.GetValue("amsNetId") as string;
                    if (!string.IsNullOrEmpty(local))
                    {
                        connectionData.amsPort = 851;
                        connectionData.amsNetId = local;
                        return connectionData;

                    }
                    else
                    {
                        MessageBox.Show("AMS Net ID not found in registry. Using default.", "Registry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connectionData.amsPort = 851;
                        connectionData.amsNetId = local;
                    }


                    int localport = Convert.ToInt16(key.GetValue("adsPort"));
                    if (localport > 1)
                    {
                      connectionData.amsPort = localport;
                    }
                    else
                    {
                        MessageBox.Show("ADS Port not found or invalid in registry. Using default.", "Registry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connectionData.amsPort = 851;
                    }
                }
                return connectionData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load settings from registry: {ex.Message}");
                return connectionData;
            }
        }

        static void SaveSettingsToRegistry(string amsNetId, int amsPort)
        {
            try
            {
                using (var key = Registry.CurrentUser.CreateSubKey(RegBasePath))
                {
                    key.SetValue("amsNetId", amsNetId ?? "", RegistryValueKind.String);
                    key.SetValue("adsPort", amsPort, RegistryValueKind.DWord);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save settings to registry: {ex.Message}");
            }
        }
    }
}
