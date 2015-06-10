using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuxaforSharp
{
    /// <summary>
    /// Represents a color that can be understood by a Luxafor device
    /// </summary>
    public class Color
    {
        /// <summary>
        /// Red portion of the color
        /// </summary>
        public byte Red { get; private set; }

        /// <summary>
        /// Green portion of the color
        /// </summary>
        public byte Green { get; private set; }

        /// <summary>
        /// Blue portion of the color
        /// </summary>
        public byte Blue { get; private set; }

        /// <summary>
        /// Create a color object
        /// </summary>
        /// <param name="red">Red portion of the color</param>
        /// <param name="green">Green portion of the color</param>
        /// <param name="blue">Blue portion of the color</param>
        public Color(byte red, byte green, byte blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }
    }
}
