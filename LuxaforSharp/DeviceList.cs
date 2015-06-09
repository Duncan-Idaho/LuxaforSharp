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

        public DeviceList(IHidEnumerator hidEnumerator)
        {
            this.hidEnumerator = hidEnumerator;
        }

        public DeviceList() :
            this(new HidEnumerator())
        { }

        public IDeviceList Scan()
        {
            lock (lockObject)
            {
                var currentHidDevices = this.hidEnumerator.Enumerate(VendorId, ProductId).ToList();

                var results = this.devices.Differences(currentHidDevices, (device, hidDevice) => device.DevicePath == hidDevice.DevicePath);

                var stillPresentDevices = results.Item2;
                var newDevices = results.Item3.Select(underlyingDevice => new Device(underlyingDevice));

                this.devices = stillPresentDevices.Concat(newDevices).ToList();

                return this;
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
