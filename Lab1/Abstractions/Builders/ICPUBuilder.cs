using Lab1.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Abstractions.Builders
{
    interface ICPUBuilder
    {
        void SetCoresCount(int count);
        void SetClockFrequencyGGz(decimal frequency);
        void SetTechnicalProcess(TechnicalProcess technicalProcess);
        void Reset();
    }
}
