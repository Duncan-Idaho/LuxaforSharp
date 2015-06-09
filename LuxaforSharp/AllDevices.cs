using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;
using LuxaforSharp.Commands;

namespace LuxaforSharp
{
    public class AllDevices : BaseDevice, IDeviceList
    {
        public const int VendorId = 0x04D8;
        public const int ProductId = 0xF372;

        private IDeviceList deviceList;
        private object lockObject = new object();

        public AllDevices(IDeviceList deviceList)
        {
            this.deviceList = deviceList;
        }

        public IDeviceList Scan()
        {
            lock (this.lockObject)
            {
                var oldDevices = this.deviceList.ToList();
                var newDevices = this.deviceList.Scan();

                foreach (var device in oldDevices.Except(newDevices))
                {
                    device.Dispose();
                }

                return this.deviceList;
            }
        }

        public override void Dispose()
        {
            foreach (var device in deviceList)
            {
                device.Dispose();
            }
        }

        public override async Task<bool> SendCommand(ICommand command, int timeout = 0)
        {
            var commands = deviceList.Select(device => 
                device.SendCommand(command, timeout));
            
            var results = await Task.WhenAll(commands);
            return results.Any(result => result);
        }

        public IEnumerator<IDevice> GetEnumerator()
        {
            return this.deviceList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
