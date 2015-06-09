using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidLibrary;
using LuxaforSharp.Commands;

namespace LuxaforSharp
{
    public interface IDeviceList : IEnumerable<IDevice>
    {
        IDeviceList Scan();

        event EventHandler<DeviceEventArguments> DiscoveredDevice;
        event EventHandler<DeviceEventArguments> LostDevice;
    }
}
