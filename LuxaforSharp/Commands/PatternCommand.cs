using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxaforSharp.Commands
{
    /// <summary>
    /// Command to carry out a specific pattern
    /// </summary>
    public class PatternCommand : ICommand
    {
        /// <summary>
        /// Type of pattern that should be carried out
        /// </summary>
        public PatternType Type { get; private set; }

        /// <summary>
        /// Number of time the pattern should be repeated
        /// </summary>
        public byte RepeatCount { get; private set; }

        /// <summary>
        /// Create the command
        /// </summary>
        /// <param name="type">Specify the pattern the device should carry out</param>
        /// <param name="repeatCount">Number of time the pattern should be repeated</param>
        public PatternCommand(PatternType type, byte repeatCount)
        {
            this.Type = type;
            this.RepeatCount = repeatCount;
        }

        /// <summary>
        /// Code of the command
        /// </summary>
        private byte CommandCode
        {
            get { return 0x06; }
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
