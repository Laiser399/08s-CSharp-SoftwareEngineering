using Lab1.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Components
{
    record RAM(int CapacityMB, RAMType Type, int ClockFrequencyMGz) : IRAM
    {
    }
}
