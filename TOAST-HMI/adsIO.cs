using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;

namespace TOAST_HMI
{
    internal interface adsIO
    {
        static int ReadInt16(string plcSymbol, AdsClient plcconnection)
        {
            if (plcconnection == null || !plcconnection.IsConnected)
                throw new InvalidOperationException("Not connected to PLC.");

            uint handle = 0;
            try
            {
                handle = plcconnection.CreateVariableHandle(plcSymbol);

                // Beckhoff stores this integer as a 16-bit value; read 2 bytes
                int readLength = sizeof(short);
                var result = plcconnection.ReadAsResult(handle, readLength);
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
                    try { plcconnection?.DeleteVariableHandle(handle); } catch { /* ignore */ }
                }
            }
        }

        static bool ReadBool(string plcSymbol, AdsClient plcconnection)
        {
            if (plcconnection == null || !plcconnection.IsConnected) throw new InvalidOperationException("Not connected to PLC.");
            uint handle = 0;
            try
            {
                handle = plcconnection.CreateVariableHandle(plcSymbol);
                var result = plcconnection.ReadAsResult(handle, sizeof(byte));
                result.ThrowOnError();
                byte[] buf = result.Data.ToArray();
                return buf.Length > 0 && buf[0] != 0;
            }
            finally
            {
                if (handle != 0) try { plcconnection?.DeleteVariableHandle(handle); } catch { }
            }
        }

        static int ReadInt32(string plcSymbol, AdsClient plcconnection)
        {
            if (plcconnection == null || !plcconnection.IsConnected) throw new InvalidOperationException("Not connected to PLC.");
            uint handle = 0;
            try
            {
                handle = plcconnection.CreateVariableHandle(plcSymbol);
                var result = plcconnection.ReadAsResult(handle, sizeof(int));
                result.ThrowOnError();
                byte[] buf = result.Data.ToArray();
                if (buf.Length < 4) throw new InvalidOperationException($"Unexpected read length for {plcSymbol}");
                return BitConverter.ToInt32(buf, 0);
            }
            finally
            {
                if (handle != 0) try { plcconnection?.DeleteVariableHandle(handle); } catch { }
            }
        }

        static uint ReadUInt32(string plcSymbol, AdsClient plcconnection)
        {
            if (plcconnection == null || !plcconnection.IsConnected) throw new InvalidOperationException("Not connected to PLC.");
            uint handle = 0;
            try
            {
                handle = plcconnection.CreateVariableHandle(plcSymbol);
                var result = plcconnection.ReadAsResult(handle, sizeof(uint));
                result.ThrowOnError();
                byte[] buf = result.Data.ToArray();
                if (buf.Length < 4) throw new InvalidOperationException($"Unexpected read length for {plcSymbol}");
                return BitConverter.ToUInt32(buf, 0);
            }
            finally
            {
                if (handle != 0) try { plcconnection?.DeleteVariableHandle(handle); } catch { }
            }
        }

        static string ReadPlcString(string plcSymbol, int maxBytes, AdsClient plcconnection)

        // Read a PLC STRING (e.g. GlobalMessages.gMsgS1.Prompts.topMessage).
        // maxBytes should match the PLC STRING maximum length (buffer size) you expect.
        {
            if (plcconnection == null || !plcconnection.IsConnected)
                throw new InvalidOperationException("Not connected to PLC.");

            uint handle = 0;
            try
            {
                handle = plcconnection.CreateVariableHandle(plcSymbol);

                int readLength = checked(maxBytes);
                var result = plcconnection.ReadAsResult(handle, readLength);
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
               // isConnectionFaulted = true;
                MessageBox.Show($"ADS read error ({plcSymbol}): {ex.Message}", "ADS Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //isConnectionFaulted = true;
                MessageBox.Show($"Read error ({plcSymbol}): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            finally
            {
                if (handle != 0)
                {
                    try { plcconnection?.DeleteVariableHandle(handle); } catch { /* ignore */ }
                }
            }
        }

        static void WriteBool(string plcSymbol, bool value, AdsClient plcconnection)
        {
            if (plcconnection == null || !plcconnection.IsConnected)
            {
                MessageBox.Show("Not connected to PLC.", "ADS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            uint handle = 0;
            try
            {
                handle = plcconnection.CreateVariableHandle(plcSymbol);
                plcconnection.WriteAny(handle, value);
            }
            catch (AdsErrorException ex)
            {
                MessageBox.Show($"ADS write error: {ex.Message}", "ADS Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //isConnectionFaulted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Write error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              //  isConnectionFaulted = true;
            }
            finally
            {
                if (handle != 0)
                {
                    try { plcconnection?.DeleteVariableHandle(handle); } catch { /* ignore */ }
                }
            }
        }

        static bool[] ReadBoolArray(string plcSymbol, int elementCount, AdsClient plcconnection)
        {
            if (plcconnection == null || !plcconnection.IsConnected)
                throw new InvalidOperationException("Not connected to PLC.");
            //isConnectionFaulted = true;

            uint handle = 0;
            try
            {
                handle = plcconnection.CreateVariableHandle(plcSymbol);

                // each boolean encoded as one byte on PLC here
                int elementSize = sizeof(byte);
                int readLength = checked(elementCount * elementSize);

                var result = plcconnection.ReadAsResult(handle, readLength);
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
                    try { plcconnection?.DeleteVariableHandle(handle); } catch { /* ignore */ }
                }
            }
        }



    }
}

