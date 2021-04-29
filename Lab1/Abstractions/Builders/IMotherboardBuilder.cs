using Lab1.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Abstractions.Builders
{
    interface IMotherboardBuilder
    {
        void BuildIntegratedGPU();
        void SetRAMCount(RAMCount ramCount);
        void BuildSSDM2Slot();
        void BuildWiFi();
        void BuildBluetooth();
        void Reset();
    }
}
