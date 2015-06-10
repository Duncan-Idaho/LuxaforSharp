using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuxaforSharp
{
    /// <summary>
    /// Identifier of one, some or all LED of a Luxafor device
    /// </summary>
    public class LedTarget
    {
        private const byte allLedCode = 0xFF;
        private const byte frontSideCode = 0x41;
        private const byte backSideCode = 0x42;

        private readonly byte code;

        /// <summary>
        /// Code in byte. Used for commands
        /// </summary>
        public byte Code 
        { 
            get { return this.code; }
        }

        private LedTarget(byte code)
        {
            this.code = code;
        }

        /// <summary>
        /// Represents all LEDs of a Luxafor device
        /// </summary>
        public static LedTarget All 
        {
            get { return new LedTarget(allLedCode); } 
        }

        /// <summary>
        /// Represents all front-side LEDs of a Luxafor device
        /// </summary>
        public static LedTarget AllFrontSide
        {
            get { return new LedTarget(frontSideCode); }
        }

        /// <summary>
        /// Represents all back-side LEDs of a Luxafor device
        /// </summary>
        public static LedTarget AllBackSide
        {
            get { return new LedTarget(backSideCode); }
        }

        /// <summary>
        /// Return a representation for one specifc LED
        /// </summary>
        /// <param name="index">Index of the LED requested. Must be between 1 and 6 included</param>
        /// <returns>Represents a single LED of a Luxafor device</returns>
        public static LedTarget OfIndex(byte index)
        {
            if (index < 1 || index > 6)
                throw new ArgumentOutOfRangeException("index", "leds are numbered from 1 to 6");

            return new LedTarget(index); 
        }
    }
}
