using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxaforSharp.Commands.Abstractions;

namespace LuxaforSharp.Commands
{
    public class JumpToCommand : TargettedCommand
    {
        public JumpToCommand (LedTarget target, Color color)
            : base(target, color)
        {
        }

        protected override byte CommandCode
        {
            get { return 0x01; }
        }
    }
}
