using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxaforSharp.Commands.Abstractions;

namespace LuxaforSharp.Commands
{
    public class FlashCommand : TargettedCommand
    {
        public byte Speed { get; private set; }
        public byte RepeatCount { get; private set; }

        public FlashCommand(LedTarget target, Color color, byte speed, byte repeatCount)
            : base(target, color)
        {
            this.Speed = speed;
            this.RepeatCount = repeatCount;
        }

        protected override byte CommandCode
        {
            get { return 0x03; }
        }

        protected override byte OptionalByte1
        {
            get { return this.Speed; }
        }

        protected override byte OptionalByte3
        {
            get { return this.RepeatCount; }
        }
    }
}
