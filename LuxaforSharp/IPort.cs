using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;
using LuxaforSharp.Commands;

namespace LuxaforSharp
{
    public interface IPort
    {
        Task<bool> SetColor(Color color, byte? fadeInTime = null, int timeout = 0);
        Task<bool> Flash(Color color, byte speed, byte repeatCount = 0, int timeout = 0);
    }
}
