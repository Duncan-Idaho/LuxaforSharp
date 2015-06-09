using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxaforSharp
{
    public class DeviceEventArguments : EventArgs
    {
        private readonly IDevice device;

        public IDevice Device
        {
            get { return this.device; }
        }

        public DeviceEventArguments(IDevice device)
        {
            this.device = device;
        }
    }
}
