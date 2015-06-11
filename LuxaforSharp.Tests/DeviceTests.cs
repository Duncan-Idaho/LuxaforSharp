using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuxaforSharp;
using LuxaforSharp.Commands;
using Xunit;

namespace LuxaforSharp.Tests
{
    public class DeviceTests
    {
        [Fact]
        public void Dispose_ActuallyDisposeUnderlyingDevice()
        {
            var fakeUnderlyingDevice = new FakeHidDevice();
            Assert.False(fakeUnderlyingDevice.IsDisposed);

            using (var device = new Device(fakeUnderlyingDevice))
            {
                Assert.False(fakeUnderlyingDevice.IsDisposed);
            }

            Assert.True(fakeUnderlyingDevice.IsDisposed);
        }

        [Fact]
        public void SetColor_ToEveryLed_WithoutFade_UsesSimpleMode()
        {
            var fakeUnderlyingDevice = new FakeHidDevice();

            using (var device = new Device(fakeUnderlyingDevice))
            {
                var color = new Color(0xC8, 0x14, 0x2A);
                device.SetColor(LedTarget.All, color).Wait();
            }

            fakeUnderlyingDevice.AssertMessagesReceived("00:01:FF:C8:14:2A:00:00:00");
        }

        [Fact]
        public void SetColor_ToSingleSide_WithoutFade_UsesSimpleMode()
        {
            var fakeUnderlyingDevice = new FakeHidDevice();

            using (var device = new Device(fakeUnderlyingDevice))
            {
                var color = new Color(0xC8, 0x14, 0x2A);
                device.SetColor(LedTarget.AllBackSide, color).Wait();
            }

            fakeUnderlyingDevice.AssertMessagesReceived("00:01:42:C8:14:2A:00:00:00");
        }

        [Fact]
        public void SetColor_ToSingleLed_WithoutFade_UsesSimpleMode()
        {
            var fakeUnderlyingDevice = new FakeHidDevice();

            using (var device = new Device(fakeUnderlyingDevice))
            {
                var color = new Color(0xC8, 0x14, 0x2A);
                device.SetColor(LedTarget.OfIndex(5), color).Wait();
            }

            fakeUnderlyingDevice.AssertMessagesReceived("00:01:05:C8:14:2A:00:00:00");
        }

        [Fact]
        public void SetColor_ToSingleLed_WithFade_UsesFadingMode()
        {
            var fakeUnderlyingDevice = new FakeHidDevice();

            using (var device = new Device(fakeUnderlyingDevice))
            {
                var color = new Color(0xC8, 0x14, 0x2A);
                device.SetColor(LedTarget.OfIndex(5), color, 64).Wait();
            }

            fakeUnderlyingDevice.AssertMessagesReceived("00:02:05:C8:14:2A:40:00:00");
        }

        [Fact]
        public void SetColorThroughPort_ToAllLeds_SimilarResult()
        {
            var fakeUnderlyingDevice = new FakeHidDevice();

            using (var device = new Device(fakeUnderlyingDevice))
            {
                var color = new Color(0xC8, 0x14, 0x2A);
                device.SetColor(LedTarget.All, color, 64).Wait();
                device.AllLeds.SetColor(color, 64).Wait();
            }

            fakeUnderlyingDevice.AssertBothMessagesAreEqual();
        }

        [Fact]
        public void SetColorThroughPort_ToFrontsidePanel_SimilarResult()
        {
            var fakeUnderlyingDevice = new FakeHidDevice();

            using (var device = new Device(fakeUnderlyingDevice))
            {
                var color = new Color(0xC8, 0x14, 0x2A);
                device.SetColor(LedTarget.AllFrontSide, color, 64).Wait();
                device.AllFrontsideLeds.SetColor(color, 64).Wait();
            }

            fakeUnderlyingDevice.AssertBothMessagesAreEqual();
        }

        [Fact]
        public void SetColorThroughPort_ToBacksidePanel_SimilarResult()
        {
            var fakeUnderlyingDevice = new FakeHidDevice();

            using (var device = new Device(fakeUnderlyingDevice))
            {
                var color = new Color(0xC8, 0x14, 0x2A);
                device.SetColor(LedTarget.AllBackSide, color, 64).Wait();
                device.AllBacksideLeds.SetColor(color, 64).Wait();
            }

            fakeUnderlyingDevice.AssertBothMessagesAreEqual();
        }

        [Fact]
        public void SetColorThroughPort_ToSingleLed_SimilarResult()
        {
            var fakeUnderlyingDevice = new FakeHidDevice();

            using (var device = new Device(fakeUnderlyingDevice))
            {
                var color = new Color(0xC8, 0x14, 0x2A);
                device.SetColor(LedTarget.OfIndex(4), color, 64).Wait();
                device[4].SetColor(color, 64).Wait();
            }

            fakeUnderlyingDevice.AssertBothMessagesAreEqual();
        }

        [Fact]
        public void Blink_ToFrontSide_WithoutRepeat_LastByteIsEmpty()
        {
            var fakeUnderlyingDevice = new FakeHidDevice();

            using (var device = new Device(fakeUnderlyingDevice))
            {
                var color = new Color(0xD0, 0x20, 0x20);
                device.Blink(LedTarget.AllFrontSide, color, 64).Wait();
            }

            fakeUnderlyingDevice.AssertMessagesReceived("00:03:41:D0:20:20:40:00:00");
        }

        [Fact]
        public void Blink_ToFrontSide_WithRepeat_LastByteIsNotEmpty()
        {
            var fakeUnderlyingDevice = new FakeHidDevice();

            using (var device = new Device(fakeUnderlyingDevice))
            {
                var color = new Color(0xD0, 0x20, 0x20);
                device.Blink(LedTarget.AllFrontSide, color, 64, 3).Wait();
            }

            fakeUnderlyingDevice.AssertMessagesReceived("00:03:41:D0:20:20:40:00:03");
        }

        [Fact]
        public void Wave()
        {
            var fakeUnderlyingDevice = new FakeHidDevice();

            using (var device = new Device(fakeUnderlyingDevice))
            {
                var color = new Color(0xCC, 0xCC, 0x20);
                device.Wave(WaveType.OverlappingShort, color, 5, 2).Wait();
            }

            fakeUnderlyingDevice.AssertMessagesReceived("00:04:03:CC:CC:20:00:02:05");
        }

        [Fact]
        public void CarryOutPattern()
        {
            var fakeUnderlyingDevice = new FakeHidDevice();

            using (var device = new Device(fakeUnderlyingDevice))
            {
                var color = new Color(0xCC, 0xCC, 0x20);
                device.CarryOutPattern(PatternType.RainbowWave, 3).Wait();
            }

            fakeUnderlyingDevice.AssertMessagesReceived("00:06:08:03:00:00:00:00:00");
        }
    }
}
