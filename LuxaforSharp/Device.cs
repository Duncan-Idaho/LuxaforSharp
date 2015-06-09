using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;
using LuxaforSharp.Commands;

namespace LuxaforSharp
{
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
        
        public override void Dispose()
        {
            this.device.Dispose();
        }

        public override Task<bool> SendCommand(ICommand command, int timeout = 0)
        {
            return this.device.WriteAsync(command.Bytes, timeout);
        }
    }
}
