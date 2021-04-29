using Lab1.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Components
{
    record Motherboard(bool IntegratedGPU, RAMCount RAMCount, 
        bool SSDM2Slot, bool WiFi, bool Bluetooth) : IMotherboard
    {
    }
}
