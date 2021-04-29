using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Abstractions.Components
{
    enum RAMType
    {
        DDR3,
        DDR4
    }

    interface IRAM
    {
        int CapacityMB { get; }
        RAMType Type { get; }
        int ClockFrequencyMGz { get; }
    }
}
