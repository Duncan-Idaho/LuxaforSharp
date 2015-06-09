using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxaforSharp.Commands.Abstractions;

namespace LuxaforSharp.Commands
{
    public class FadeToCommand : TargettedCommand
    {
        public byte FadingDuration { get; private set; }

        public FadeToCommand(LedTarget target, Color color, byte fadingDuration)
            : base(target, color)
        {
            this.FadingDuration = fadingDuration;
        }

        protected override byte CommandCode
        {
            get { return 0x02; }
        }

        protected override byte OptionalByte1
        {
            get { return this.FadingDuration; }
        }
    }
}
