using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxaforSharp
{
    public interface ICommand
    {
        byte[] Bytes { get; }
    }
}
