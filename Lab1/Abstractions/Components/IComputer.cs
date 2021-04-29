using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Abstractions.Components
{
    interface IComputer
    {
        IMotherboard Motherboard { get; }
        ICPU CPU { get; }
        IGPU GPU { get; }
        IReadOnlyList<IRAM> RAMs { get; }
        IPowerSupply PowerSupply { get; }
        IReadOnlyList<IHDD> StorageDevices { get; }
    }
}
