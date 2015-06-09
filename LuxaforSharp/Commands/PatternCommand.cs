using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxaforSharp.Commands
{
    public class PatternCommand : ICommand
    {
        public PatternType Type { get; private set; }
        public byte RepeatCount { get; private set; }

        public PatternCommand(PatternType type, byte repeatCount)
        {
            this.Type = type;
            this.RepeatCount = repeatCount;
        }

        private byte CommandCode
        {
            get { return 0x06; }
        }

        public byte[] Bytes
        {
            get
            {
                return new byte[]
                {
                    0x00,
                    this.CommandCode,
                    (byte) this.Type,
                    this.RepeatCount,
                    0x00,
                    0x00,
                    0x00,
                    0x00,
                    0x00,
                };
            }
        }
    }
}
