using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;
using LuxaforSharp.Commands;

namespace LuxaforSharp
{
    public class DeviceList : IDeviceList
    {
        public const int VendorId = 0x04D8;
        public const int ProductId = 0xF372;
        
        private IHidEnumerator hidEnumerator;
        private IList<Device> devices = new List<Device>();
        private object lockObject = new object();

        /// <summary>
        /// Raised when, during a Scan operation, a device is detected while it was not during last scan
        /// </summary>
        public event EventHandler<DeviceEventArguments> DiscoveredDevice;

        protected virtual void OnDiscoveredDevice(object sender, DeviceEventArguments arguments)
        {
            if (DiscoveredDevice != null)
            {
                DiscoveredDevice(sender, arguments);
            }
        }

        /// <summary>
        /// Raised when, during a Scan operation, a device is lost while it was present during last scan
        /// </summary>
        public event EventHandler<DeviceEventArguments> LostDevice;

        protected virtual void OnLostDevice(object sender, DeviceEventArguments arguments)
        {
            if (LostDevice != null)
            {
                LostDevice(sender, arguments);
            }
        }

        public DeviceList(IHidEnumerator hidEnumerator)
        {
            this.hidEnumerator = hidEnumerator;
        }

        public DeviceList() :
            this(new HidEnumerator())
        { }

        public void Scan()
        {
            lock (lockObject)
            {
                var currentHidDevices = this.hidEnumerator.Enumerate(VendorId, ProductId).ToList();

                var results = this.devices.Differences(currentHidDevices, (device, hidDevice) => device.DevicePath == hidDevice.DevicePath);

                var lostDevices = results.Item1.ToList();
                var stillPresentDevices = results.Item2.ToList();
                var newDevices = results.Item3.Select(underlyingDevice => new Device(underlyingDevice)).ToList();

                this.devices = stillPresentDevices.Concat(newDevices).ToList();

                foreach (var device in lostDevices)
                {
                    this.OnLostDevice(this, new DeviceEventArguments(device));
                }

                foreach (var device in newDevices)
                {
                    this.OnDiscoveredDevice(this, new DeviceEventArguments(device));
                }
            }
        }

        public IEnumerator<IDevice> GetEnumerator()
        {
            return this.devices.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public AllDevices CreateAllDevices()
        {
            return new AllDevices(this);
        }
    }
}
