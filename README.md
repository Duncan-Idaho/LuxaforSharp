# LuxaforSharp

A .Net library providing a simple API to control Luxafor devices

## About Luxafor

Luxafor is an LED indicator that connects to your computer through a USB port 
or via Bluetooth, and shows your availability or notifies you about important 
information, like incoming emails or calendar reminders.

Its Hardware Api is open, allowing developers to control the device through
their own applications.

You can go to http://luxafor.com/ to get more information about it.

## About LuxaforSharp

LuxaforSharp is a lightweight .Net library that allows to access the device
through a simple API. It provides a few interfaces with simple methods to
format commands and send them to the device. Through it, you can easily
plug Luxafor to your own application.

## Downloads

LuxaforSharp is available as a nuget.

## Documentation through exemples

### Getting the first device among those accessibles
```c#
IDeviceList list = new DeviceList();
IDevice device = list.First();
```

### Switching colors of the device
```c#
device.SetColor(LedTarget.All, new Color(0, 0, 255)); // Immediatly switches all leds to green
device.SetColor(LedTarget.AllFrontSide, new Color(0, 255, 0), 15); // Fade frontside leds to blue
device.SetColor(LedTarget.OfIndex(2), new Color(255, 0, 0), 15); // Fade 2nd LED to red (middle frontside led)
```

### Alternative way of acessing the device
```c#
IPort allLeds = device.AllLeds;
allLeds.SetColor(new Color(0, 0, 255)); // Immediatly switches all leds to green

IPort frontisdeLeds = device.AllFrontsideLeds;
frontisdeLeds.SetColor(new Color(0, 255, 0), 15); // Fade frontside leds to blue

IPort secondLed = device[2];
secondLed.SetColor(new Color(255, 0, 0), 15); // Fade 2nd LED to red (middle frontside led)
```

### Other commands
```c#
device.Flash(LedTarget.AllBackSide, new Color(255, 0, 0), 15, 2); // Make backside leds blinking twice
device.Wave(WaveType.OverlappingLong, new Color(255, 0, 255), 5, 3); // Send a magenta wave through the device
device.CarryOutPattern(PatternType.Police, 5); // Repeat 5 times the "Police" pattern
```

### Disposing the device
```c#
device.Dispose();
```

## Requirements

LuxaforSharp currently works on .Net 4.5.

It also requires another library, HidLibrary.

You can get more informations about it on https://github.com/mikeobrien/HidLibrary.
