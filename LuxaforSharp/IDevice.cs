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
    /// Represents a Luxafor device to which you can send commands
    /// </summary>
    public interface IDevice : IDisposable
    {
        /// <summary>
        /// Low level method allowing you to send raw commands to the device.
        /// Implements ICommand to send custom commands to this method
        /// </summary>
        /// <param name="command">Command to send to the device</param>
        /// <param name="timeout">Time, in milliseconds, after which the application should stop waiting for the acknowledgment of this message</param>
        /// <returns>Task representing the operation. Result is true if the message has been acknowledged, false otherwise</returns>
        Task<bool> SendCommand(ICommand command, int timeout = 0);
        
        /// <summary>
        /// Requests the device to switch some or all leds to a specific color.
        /// </summary>
        /// <param name="target">Specify which leds should be switched</param>
        /// <param name="color">Specify the color to which leds should be switched</param>
        /// <param name="fadeInTime">Abstract duration for the fading effect. The higher, the longer it will take to switch to the color. Null to switch instantaneously</param>
        /// <param name="timeout">Time, in milliseconds, after which the application should stop waiting for the acknowledgment of this message</param>
        /// <returns>Task representing the operation. Result is true if the message has been acknowledged, false otherwise</returns>
        Task<bool> SetColor(LedTarget target, Color color, byte? fadeInTime = null, int timeout = 0);

        /// <summary>
        /// Requests the device to blink with a specific color.
        /// </summary>
        /// <param name="target">Specify which leds should blink</param>
        /// <param name="color">Specify the color to which leds should blink</param>
        /// <param name="speed">Abstract duration for the fading effect. The higher, the longer each blink will take.</param>
        /// <param name="repeatCount">Number of time the blink should be repeated</param>
        /// <param name="timeout">Time, in milliseconds, after which the application should stop waiting for the acknowledgment of this message</param>
        /// <returns>Task representing the operation. Result is true if the message has been acknowledged, false otherwise</returns>
        Task<bool> Blink(LedTarget target, Color color, byte speed, byte repeatCount = 0, int timeout = 0);

        /// <summary>
        /// Requests the device to start a waving pattern.
        /// Waving pattern involves each leds blinking to the same color in an out-of-phase manner, giving a waving effect that starts from the first leds and propagates to the last one and then the first again.
        /// </summary>
        /// <param name="waveType">Specify how the wave is formed</param>
        /// <param name="color">Specify the color to which leds should be switched</param>
        /// <param name="speed">Abstract duration for the wave effect. The higher, the longer each wave will take.</param>
        /// <param name="repeatCount">Number of time the wave should be repeated, ie. the number of times the wave should pass each led</param>
        /// <param name="timeout">Time, in milliseconds, after which the application should stop waiting for the acknowledgment of this message</param>
        /// <returns>Task representing the operation. Result is true if the message has been acknowledged, false otherwise</returns>
        Task<bool> Wave(WaveType waveType, Color color, byte speed, byte repeatCount, int timeout = 0);

        /// <summary>
        /// Requests the device to carry out a specific pattern.
        /// </summary>
        /// <param name="patternType">Specify the pattern the device should carry out</param>
        /// <param name="repeatCount">Number of time the pattern should be repeated</param>
        /// <param name="timeout">Time, in milliseconds, after which the application should stop waiting for the acknowledgment of this message</param>
        /// <returns>Task representing the operation. Result is true if the message has been acknowledged, false otherwise</returns>
        Task<bool> CarryOutPattern(PatternType patternType, byte repeatCount, int timeout = 0);
        
        /// <summary>
        /// Sub-part of the device able to receive commands that target all leds.
        /// </summary>
        IPort AllLeds { get; }

        /// <summary>
        /// Sub-part of the device able to receive commands that target all front-side leds.
        /// </summary>
        IPort AllFrontsideLeds { get; }

        /// <summary>
        /// Sub-part of the device able to receive commands that target all back-side leds.
        /// </summary>
        IPort AllBacksideLeds { get; }

        /// <summary>
        /// Sub-part of the device able to receive commands that target a specific led.
        /// </summary>
        /// <param name="index">Index of the led. Should be between 1 and 6</param>
        /// <returns>The sub-device for the requested led</returns>
        IPort this[byte index] { get; }
    }
}
