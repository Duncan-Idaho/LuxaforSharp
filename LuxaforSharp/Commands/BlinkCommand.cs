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
    public class BlinkCommand : TargettedCommand
    {
        /// <summary>
        /// Abstract duration for the fading effect. The higher, the longer each blink will take.
        /// </summary>
        public byte Speed { get; private set; }

        /// <summary>
        /// Number of time the blink should be repeated
        /// </summary>
        public byte RepeatCount { get; private set; }

        /// <summary>
        /// Create the command
        /// </summary>
        /// <param name="target">Specify which leds should blink</param>
        /// <param name="color">Specify the color to which leds should blink</param>
        /// <param name="speed">Abstract duration for the fading effect. The higher, the longer each blink will take.</param>
        /// <param name="repeatCount">Number of time the blink should be repeated</param>
        public BlinkCommand(LedTarget target, Color color, byte speed, byte repeatCount)
            : base(target, color)
        {
            this.Speed = speed;
            this.RepeatCount = repeatCount;
        }

        /// <summary>
        /// Code of the command
        /// </summary>
        protected override byte CommandCode
        {
            get { return 0x03; }
        }

        /// <summary>
        /// First optional argument, containing the speed for the fading effect
        /// </summary>
        protected override byte OptionalByte1
        {
            get { return this.Speed; }
        }

        /// <summary>
        /// Third optional argument, containing the number of time the blink should be repeated
        /// </summary>
        protected override byte OptionalByte3
        {
            get { return this.RepeatCount; }
        }
    }
}
