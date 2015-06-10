using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxaforSharp
{
    /// <summary>
    /// Specify which device is concerned by the event being raised
    /// </summary>
    public class DeviceEventArguments : EventArgs
    {
        private readonly IDevice device;

        /// <summary>
        /// Device concerned by the event being raised
        /// </summary>
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
