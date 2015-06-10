using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxaforSharp.Commands.Abstractions
{
    /// <summary>
    /// Abstraction for all commands sending three bytes for a color and one byte for a target LED.
    /// </summary>
    public abstract class TargettedCommand : ColoredCommand
    {
        /// <summary>
        /// Led that should be updated according to the command
        /// </summary>
        public LedTarget Target { get; private set; }

        public TargettedCommand(LedTarget target, Color color) 
            : base (color)
        {
            this.Target = target;
        }

        /// <summary>
        /// Third byte of the command, specifying which LED should be updated
        /// </summary>
        protected override byte CommandMode
        {
            get { return this.Target.Code; }
        }
    }
}
