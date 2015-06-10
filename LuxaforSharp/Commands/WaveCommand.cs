using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxaforSharp.Commands.Abstractions;

namespace LuxaforSharp.Commands
{
    public class WaveCommand : ColoredCommand
    {
        /// <summary>
        /// Specify how the wave is formed
        /// </summary>
        public WaveType Type { get; private set; }

        /// <summary>
        /// Abstract duration for the wave effect. The higher, the longer each wave will take.
        /// </summary>
        public byte Speed { get; private set; }

        /// <summary>
        /// Number of time the wave should be repeated, ie. the number of times the wave should pass each led
        /// </summary>
        public byte RepeatCount { get; private set; }

        /// <summary>
        /// Create the command
        /// </summary>
        /// <param name="type">Specify how the wave is formed</param>
        /// <param name="color">Specify the color to which leds should be switched</param>
        /// <param name="speed">Abstract duration for the wave effect. The higher, the longer each wave will take.</param>
        /// <param name="repeatCount">Number of time the wave should be repeated, ie. the number of times the wave should pass each led</param>
        public WaveCommand(WaveType type, Color color, byte speed, byte repeatCount)
            : base(color)
        {
            this.Type = type;
            this.Speed = speed;
            this.RepeatCount = repeatCount;
        }

        /// <summary>
        /// Code of the command
        /// </summary>
        protected override byte CommandCode
        {
            get { return 0x04; }
        }

        /// <summary>
        /// Specify how the wave is formed
        /// </summary>
        protected override byte CommandMode
        {
            get { return (byte) this.Type; }
        }

        /// <summary>
        /// Second optional argument, containing the number of time the wave should be repeated
        /// </summary>
        protected override byte OptionalByte2
        {
            get { return this.RepeatCount; }
        }

        /// <summary>
        /// Third optional argument, containing the speed for the wave
        /// </summary>
        protected override byte OptionalByte3
        {
            get { return this.Speed; }
        }
    }
}
