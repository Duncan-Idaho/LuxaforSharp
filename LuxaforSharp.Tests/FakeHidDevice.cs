using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LuxaforSharp.Tests
{
    public class FakeHidDevice : IHidDevice
    {
        public List<byte[]> ReceivedCommands { get; private set; }
        public bool IsDisposed { get; private set; }

        public FakeHidDevice()
        {
            this.ReceivedCommands = new List<byte[]>();
        }

        public void Dispose()
        {
            this.IsDisposed = true;
        }

        public void Write(byte[] data, WriteCallback callback)
        {
            Write(data, callback);
        }

        public void Write(byte[] data, WriteCallback callback, int timeout)
        {
            var success = Write(data);
            callback(success);
        }

        public bool Write(byte[] data, int timeout)
        {
            return Write(data);
        }

        public bool Write(byte[] data)
        {
            this.ReceivedCommands.Add(data);
            return true;
        }

        public System.Threading.Tasks.Task<bool> WriteAsync(byte[] data, int timeout = 0)
        {
            var success = Write(data);
            return Task.FromResult(success);
        }

        public void AssertMessagesReceived(params string[] messages)
        {
            Assert.AreEqual(messages.Length, this.ReceivedCommands.Count);

            for (int index = 0; index < messages.Length; index++)
            {
                var byteMessage = ConvertToByteArray(messages[index]);
                CollectionAssert.AreEqual(byteMessage, this.ReceivedCommands[index]);
            }

        }

        private byte[] ConvertToByteArray(string hexadecimalString)
        {
            return hexadecimalString
                .Split(':')
                .Select(hexadecimalNumber => Convert.ToByte(hexadecimalNumber, 16))
                .ToArray();
        }

        internal void AssertBothMessagesAreEqual()
        {
            Assert.AreEqual(2, this.ReceivedCommands.Count);
            CollectionAssert.AreEqual(this.ReceivedCommands[0], this.ReceivedCommands[1]);
        }

        #region Unimplemented methods

        public HidDeviceAttributes Attributes
        {
            get { throw new NotImplementedException(); }
        }

        public HidDeviceCapabilities Capabilities
        {
            get { throw new NotImplementedException(); }
        }

        public void CloseDevice()
        {
            throw new NotImplementedException();
        }

        public HidReport CreateReport()
        {
            throw new NotImplementedException();
        }

        public string Description
        {
            get { throw new NotImplementedException(); }
        }

        public string DevicePath
        {
            get { throw new NotImplementedException(); }
        }

        public IntPtr Handle
        {
            get { throw new NotImplementedException(); }
        }

        public event InsertedEventHandler Inserted;

        public bool IsConnected
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsOpen
        {
            get { throw new NotImplementedException(); }
        }

        public bool MonitorDeviceEvents
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void OpenDevice(DeviceMode readMode, DeviceMode writeMode, ShareMode shareMode)
        {
            throw new NotImplementedException();
        }

        public void OpenDevice()
        {
            throw new NotImplementedException();
        }

        public HidDeviceData Read(int timeout)
        {
            throw new NotImplementedException();
        }

        public void Read(ReadCallback callback, int timeout)
        {
            throw new NotImplementedException();
        }

        public void Read(ReadCallback callback)
        {
            throw new NotImplementedException();
        }

        public HidDeviceData Read()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<HidDeviceData> ReadAsync(int timeout = 0)
        {
            throw new NotImplementedException();
        }

        public bool ReadFeatureData(out byte[] data, byte reportId = 0)
        {
            throw new NotImplementedException();
        }

        public bool ReadManufacturer(out byte[] data)
        {
            throw new NotImplementedException();
        }

        public bool ReadProduct(out byte[] data)
        {
            throw new NotImplementedException();
        }

        public HidReport ReadReport()
        {
            throw new NotImplementedException();
        }

        public HidReport ReadReport(int timeout)
        {
            throw new NotImplementedException();
        }

        public void ReadReport(ReadReportCallback callback, int timeout)
        {
            throw new NotImplementedException();
        }

        public void ReadReport(ReadReportCallback callback)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<HidReport> ReadReportAsync(int timeout = 0)
        {
            throw new NotImplementedException();
        }

        public bool ReadSerialNumber(out byte[] data)
        {
            throw new NotImplementedException();
        }

        public event RemovedEventHandler Removed;

        public bool WriteFeatureData(byte[] data)
        {
            throw new NotImplementedException();
        }

        public void WriteReport(HidReport report, WriteCallback callback, int timeout)
        {
            throw new NotImplementedException();
        }

        public bool WriteReport(HidReport report, int timeout)
        {
            throw new NotImplementedException();
        }

        public bool WriteReport(HidReport report)
        {
            throw new NotImplementedException();
        }

        public void WriteReport(HidReport report, WriteCallback callback)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> WriteReportAsync(HidReport report, int timeout = 0)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
