using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxaforSharp
{
    /// <summary>
    /// Represents any command that can be sent to a device
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Returns the bytes to which this command should be converted to before being sent to a device
        /// </summary>
        byte[] Bytes { get; }
    }
}
