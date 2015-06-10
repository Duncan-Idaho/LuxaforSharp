using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;
using LuxaforSharp.Commands;

namespace LuxaforSharp
{
    /// <summary>
    /// Represents a sub-part of a Luxafor device able to receive commands that target specific leds.
    /// </summary>
    public interface IPort
    {
        /// <summary>
        /// Requests the leds to switch some or all leds to a specific color.
        /// </summary>
        /// <param name="color">Specify the color to which leds should be switched</param>
        /// <param name="fadeInTime">Abstract duration for the fading effect. The higher, the longer it will take to switch to the color. Null to switch instantaneously</param>
        /// <param name="timeout">Time, in milliseconds, after which the application should stop waiting for the acknowledgment of this message</param>
        /// <returns>Task representing the operation. Result is true if the message has been acknowledged, false otherwise</returns>
        Task<bool> SetColor(Color color, byte? fadeInTime = null, int timeout = 0);

        /// <summary>
        /// Requests the leds to blink with a specific color.
        /// </summary>
        /// <param name="color">Specify the color to which leds should blink</param>
        /// <param name="speed">Abstract duration for the fading effect. The higher, the longer each blink will take.</param>
        /// <param name="repeatCount">Number of time the blink should be repeated</param>
        /// <param name="timeout">Time, in milliseconds, after which the application should stop waiting for the acknowledgment of this message</param>
        /// <returns>Task representing the operation. Result is true if the message has been acknowledged, false otherwise</returns>
        Task<bool> Flash(Color color, byte speed, byte repeatCount = 0, int timeout = 0);
    }
}
