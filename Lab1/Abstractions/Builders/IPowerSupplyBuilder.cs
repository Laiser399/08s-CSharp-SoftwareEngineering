using Lab1.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Abstractions.Builders
{
    interface IPowerSupplyBuilder
    {
        void SetPowerW(int powerW);
        void SetCertificate80PLUS(Certificate80PLUS certificate);
        void Reset();
    }
}
