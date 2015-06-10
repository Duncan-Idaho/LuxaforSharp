using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxaforSharp
{
    /// <summary>
    /// Different type of pattern the device can carry out
    /// </summary>
    public enum PatternType
    {
        /// <summary>
        /// Pattern the device execute when plugged in to a port
        /// </summary>
        Luxafor = 0x01,

        /// <summary>
        /// Alternating blue-red blinking
        /// </summary>
        Police = 0x05,

        Random1 = 0x02,
        Random2 = 0x03,
        Random3 = 0x04,
        Random4 = 0x06,
        Random5 = 0x07,

        /// <summary>
        /// All colors shifting
        /// </summary>
        RainbowWave = 0x08
    }
}
