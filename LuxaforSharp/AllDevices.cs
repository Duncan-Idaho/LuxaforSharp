using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;
using LuxaforSharp.Commands;

namespace LuxaforSharp
{
    /// <summary>
    /// Aggregation of all available devices into a single object
    /// </summary>
    public class AllDevices : BaseDevice, IEnumerable<IDevice>
    {
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

        /// <summary>
        /// Dispose the device.
        /// </summary>
        public override void Dispose()
        {
            foreach (var device in deviceList)
            {
                device.Dispose();
            }
        }

        /// <summary>
        /// Low level method allowing you to send raw commands to the device.
        /// Implements ICommand to send custom commands to this method
        /// </summary>
        /// <param name="command">Command to send to the device</param>
        /// <param name="timeout">Time, in milliseconds, after which the application should stop waiting for the acknowledgment of this message</param>
        /// <returns>Task representing the operation. Result is true if the message has been acknowledged, false otherwise</returns>
        public override async Task<bool> SendCommand(ICommand command, int timeout = 0)
        {
            var commands = deviceList.Select(device => 
                device.SendCommand(command, timeout));
            
            var results = await Task.WhenAll(commands);
            return results.Any(result => result);
        }

        /// <summary>
        /// Return an enumerator that returns each device.
        /// </summary>
        /// <returns>An enumerator that returns each device.</returns>
        public IEnumerator<IDevice> GetEnumerator()
        {
            return this.deviceList.GetEnumerator();
        }

        /// <summary>
        /// Return an enumerator that returns each device.
        /// </summary>
        /// <returns>An enumerator that returns each device.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
