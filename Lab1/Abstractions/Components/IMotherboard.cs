using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Abstractions.Components
{
    enum RAMCount
    {
        _2,
        _4,
        _6,
        _8
    }

    interface IMotherboard
    {
        bool IntegratedGPU { get; }
        RAMCount RAMCount { get; }
        bool SSDM2Slot { get; }
        bool WiFi { get; }
        bool Bluetooth { get; }
    }
}
