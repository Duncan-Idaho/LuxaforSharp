using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxaforSharp.Commands.Abstractions;

namespace LuxaforSharp.Commands
{
    /// <summary>
    /// Command requesting the device to gradually fade to a specfic color
    /// </summary>
    public class FadeToCommand : TargettedCommand
    {
        /// <summary>
        /// Abstract duration for the fading effect. The higher, the longer it will take to switch to the color.
        /// </summary>
        public byte FadingDuration { get; private set; }

        /// <summary>
        /// Create the command
        /// </summary>
        /// <param name="target">Specify which leds should be switched</param>
        /// <param name="color">Specify the color to which leds should be switched</param>
        /// <param name="fadeInTime">Abstract duration for the fading effect. The higher, the longer it will take to switch to the color. Null to switch instantaneously</param>
        public FadeToCommand(LedTarget target, Color color, byte fadingDuration)
            : base(target, color)
        {
            this.FadingDuration = fadingDuration;
        }

        /// <summary>
        /// Code of the command
        /// </summary>
        protected override byte CommandCode
        {
            get { return 0x02; }
        }

        /// <summary>
        /// First optional argument, containing the Fading duration
        /// </summary>
        protected override byte OptionalByte1
        {
            get { return this.FadingDuration; }
        }
    }
}
