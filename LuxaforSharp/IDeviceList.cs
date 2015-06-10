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
    /// A class able to scan devices, discovering new and detecting lost devices
    /// </summary>
    public interface IDeviceList : IEnumerable<IDevice>
    {
        /// <summary>
        /// Trigger a Scan. Designed to be called periodically
        /// </summary>
        void Scan();

        /// <summary>
        /// Raised when, during a Scan operation, a device is detected while it was not during last scan
        /// </summary>
        event EventHandler<DeviceEventArguments> DiscoveredDevice;

        /// <summary>
        /// Raised when, during a Scan operation, a device is lost while it was present during last scan
        /// </summary>
        event EventHandler<DeviceEventArguments> LostDevice;

        /// <summary>
        /// Create a virtual device, wrapping this list, that automatically use every connected Luxafor devices
        /// </summary>
        /// <returns>Virtual Luxafor device</returns>
        AllDevices CreateAllDevices();
    }
}
