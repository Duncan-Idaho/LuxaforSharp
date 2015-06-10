using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxaforSharp.Commands.Abstractions;

namespace LuxaforSharp.Commands
{
    /// <summary>
    /// Command requesting the device to instantaneously switch to a specfic color
    /// </summary>
    public class JumpToCommand : TargettedCommand
    {
        /// <summary>
        /// Create the command
        /// </summary>
        /// <param name="target">Specify which leds should be switched</param>
        /// <param name="color">Specify the color to which leds should be switched</param>
        public JumpToCommand(LedTarget target, Color color)
            : base(target, color)
        {
        }

        /// <summary>
        /// Code of the command
        /// </summary>
        protected override byte CommandCode
        {
            get { return 0x01; }
        }
    }
}
