using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxaforSharp
{
    /// <summary>
    /// Type of Wave the Luxafor device can execute
    /// </summary>
    public enum WaveType
    {
        /// <summary>
        /// LEDs will gradually shift from off state toward the requested color and back again.
        /// One single LED will be tuned fully to the requested color at most.
        /// When that happen, the previous and next LED will be tuned to half the requested color 
        /// in order to render a smooth effect.
        /// </summary>
        Short = 0x01,

        /// <summary>
        /// LEDs will gradually shift from off state toward the requested color and back again.
        /// Thee LEDs, which is the side of a full side of the device, will be tuned fully to the requested color at most.
        /// When that happen, the previous and next LED will be tuned to half the requested color 
        /// in order to render a smooth effect.
        /// </summary>
        Long = 0x02,

        /// <summary>
        /// LEDs will gradually shift from the previous color of the device toward the requested color and back again.
        /// If different LEDs had different colors before the wave started, the whole device will, upon wave startup, switch to the color of the first LED.
        /// One single LED tuned fully to the requested color at most.
        /// When that happen, the previous and next LED will be tuned to half the requested color 
        /// in order to render a smooth effect.
        /// </summary>
        OverlappingShort = 0x03,

        /// <summary>
        /// LEDs will gradually shift from the previous color of the device toward the requested color and back again.
        /// If different LEDs had different colors before the wave started, the whole device will, upon wave startup, switch to the color of the first LED.
        /// Thee LEDs, which is the side of a full side of the device, will be tuned fully to the requested color at most.
        /// When that happen, the previous and next LED will be tuned to half the requested color 
        /// in order to render a smooth effect.
        OverlappingLong = 0x04
    }
}
