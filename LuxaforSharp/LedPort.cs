using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxaforSharp
{
    public class LedPort : IPort
    {
        private readonly IDevice device;
        private readonly LedTarget target;

        internal LedPort(IDevice device, LedTarget target)
        {
            this.device = device;
            this.target = target;
        }

        public Task<bool> SetColor(Color color, byte? fadeInTime = null, int timeout = 0)
        {
            return this.device.SetColor(this.target, color, fadeInTime, timeout);
        }

        public Task<bool> Flash(Color color, byte speed, byte repeatCount = 0, int timeout = 0)
        {
            return this.device.Flash(this.target, color, speed, repeatCount, timeout);
        }
    }
}
