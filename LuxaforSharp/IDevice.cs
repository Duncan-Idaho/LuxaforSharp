using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;
using LuxaforSharp.Commands;

namespace LuxaforSharp
{
    public interface IDevice : IDisposable
    {
        Task<bool> SendCommand(ICommand command, int timeout = 0);
        
        Task<bool> SetColor(LedTarget target, Color color, byte? fadeInTime = null, int timeout = 0);
        Task<bool> Flash(LedTarget target, Color color, byte speed, byte repeatCount = 0, int timeout = 0);
        Task<bool> Wave(WaveType waveType, Color color, byte speed, byte repeatCount, int timeout = 0);
        Task<bool> CarryOutPattern(PatternType patternType, byte repeatCount, int timeout = 0);
    }
}
