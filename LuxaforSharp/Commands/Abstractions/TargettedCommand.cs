using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxaforSharp.Commands.Abstractions
{
    public abstract class TargettedCommand : ColoredCommand
    {
        public LedTarget Target { get; private set; }

        public TargettedCommand(LedTarget target, Color color) 
            : base (color)
        {
            this.Target = target;
        }

        protected override byte CommandMode
        {
            get { return this.Target.Code; }
        }
    }
}
