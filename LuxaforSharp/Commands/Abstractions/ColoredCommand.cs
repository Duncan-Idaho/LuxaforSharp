using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxaforSharp.Commands.Abstractions
{
    /// <summary>
    /// Abstraction for all commands sending three bytes for a color.
    /// </summary>
    public abstract class ColoredCommand : ICommand
    {
        public Color Color { get; private set; }

        public ColoredCommand(Color color)
        {
            this.Color = color;
        }

        /// <summary>
        /// Second byte of the command, specifying the kind of command being sent
        /// </summary>
        protected abstract byte CommandCode { get; }

        /// <summary>
        /// Third byte of the command, specifying which variation of the command kind specified is requested
        /// </summary>
        protected abstract byte CommandMode { get; }
        
        /// <summary>
        /// Seventh byte for additional command arguments. 0 by default.
        /// </summary>
        protected virtual byte OptionalByte1 
        {
            get { return 0x00; }
        }

        /// <summary>
        /// Eigth byte for additional command arguments. 0 by default.
        /// </summary>
        protected virtual byte OptionalByte2
        {
            get { return 0x00; }
        }

        /// <summary>
        /// Ninth byte for additional command arguments. 0 by default.
        /// </summary>
        protected virtual byte OptionalByte3
        {
            get { return 0x00; }
        }

        /// <summary>
        /// Bytes of a colored command.
        /// </summary>
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
