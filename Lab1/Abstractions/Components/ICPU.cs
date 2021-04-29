using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Abstractions.Components
{
    enum TechnicalProcess
    {
        _7nm,
        _12nm,
        _14nm,
        _22nm
    }

    interface ICPU
    {
        int CoresCount { get; }
        decimal ClockFrequencyGGz { get; }
        TechnicalProcess TechnicalProcess { get; }
    }
}
