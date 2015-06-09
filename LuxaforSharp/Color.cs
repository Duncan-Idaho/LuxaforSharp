using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuxaforSharp
{
    public class Color
    {
        public byte Red { get; private set; }
        public byte Green { get; private set; }
        public byte Blue { get; private set; }

        public Color(byte red, byte green, byte blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }
    }
}
