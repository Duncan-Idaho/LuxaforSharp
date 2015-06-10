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
    /// Represents a real Luxafor device.
    /// </summary>
    public class Device : BaseDevice
    {
        private readonly IHidDevice device;

        public string DevicePath 
        {
            get { return this.device.DevicePath; } 
        }

        public Device(IHidDevice device)
        {
            this.device = device;
        }
        
        /// <summary>
        /// Dispose the device.
        /// </summary>
        public override void Dispose()
        {
            this.device.Dispose();
        }

        /// <summary>
        /// Low level method allowing you to send raw commands to the device.
        /// Implements ICommand to send custom commands to this method
        /// </summary>
        /// <param name="command">Command to send to the device</param>
        /// <param name="timeout">Time, in milliseconds, after which the application should stop waiting for the acknowledgment of this message</param>
        /// <returns>Task representing the operation. Result is true if the message has been acknowledged, false otherwise</returns>
        public override Task<bool> SendCommand(ICommand command, int timeout = 0)
        {
            return this.device.WriteAsync(command.Bytes, timeout);
        }
    }
}
