using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuxaforSharp
{
    public class LedTarget
    {
        private const byte allLedCode = 0xFF;
        private const byte frontSideCode = 0x41;
        private const byte backSideCode = 0x42;

        private readonly byte code;
        public byte Code 
        { 
            get { return this.code; }
        }

        private LedTarget(byte code)
        {
            this.code = code;
        }

        public static LedTarget All 
        {
            get { return new LedTarget(allLedCode); } 
        }

        public static LedTarget AllFrontSide
        {
            get { return new LedTarget(frontSideCode); }
        }

        public static LedTarget AllBackSide
        {
            get { return new LedTarget(backSideCode); }
        }

        public static LedTarget OfIndex(byte index)
        {
            if (index < 1 || index > 6)
                throw new ArgumentOutOfRangeException("index", "leds are numbered from 1 to 6");

            return new LedTarget(index); 
        }
    }
}
