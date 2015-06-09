using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;
using LuxaforSharp.Commands;

namespace LuxaforSharp
{
    public class AllDevices : BaseDevice, IEnumerable<IDevice>
    {
        public const int VendorId = 0x04D8;
        public const int ProductId = 0xF372;

        private IDeviceList deviceList;
        private object lockObject = new object();

        public AllDevices(IDeviceList deviceList)
        {
            this.deviceList = deviceList;

            this.deviceList.LostDevice += DeviceListLostDevice;
        }

        private void DeviceListLostDevice(object sender, DeviceEventArguments e)
        {
            e.Device.Dispose();
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
