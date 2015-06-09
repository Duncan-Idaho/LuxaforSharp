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
        public WaveType Type { get; private set; }
        public byte Speed { get; private set; }
        public byte RepeatCount { get; private set; }

        public WaveCommand(WaveType type, Color color, byte speed, byte repeatCount)
            : base(color)
        {
            this.Type = type;
            this.Speed = speed;
            this.RepeatCount = repeatCount;
        }

        protected override byte CommandCode
        {
            get { return 0x04; }
        }

        protected override byte CommandMode
        {
            get { return (byte) this.Type; }
        }

        protected override byte OptionalByte2
        {
            get { return this.RepeatCount; }
        }

        protected override byte OptionalByte3
        {
            get { return this.Speed; }
        }
    }
}
