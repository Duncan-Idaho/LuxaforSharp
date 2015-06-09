using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxaforSharp.Commands.Abstractions
{
    public abstract class ColoredCommand : ICommand
    {
        public Color Color { get; private set; }

        public ColoredCommand(Color color)
        {
            this.Color = color;
        }

        protected abstract byte CommandCode { get; }
        protected abstract byte CommandMode { get; }
        
        protected virtual byte OptionalByte1 
        {
            get { return 0x00; }
        }
        
        protected virtual byte OptionalByte2
        {
            get { return 0x00; }
        }

        protected virtual byte OptionalByte3
        {
            get { return 0x00; }
        }

        public byte[] Bytes
        {
            get 
            {
                return new byte[]
                {
                    0x00,
                    this.CommandCode,
                    this.CommandMode,
                    this.Color.Red,
                    this.Color.Green,
                    this.Color.Blue,
                    this.OptionalByte1,
                    this.OptionalByte2,
                    this.OptionalByte3,
                };
            }
        }
    }
}
