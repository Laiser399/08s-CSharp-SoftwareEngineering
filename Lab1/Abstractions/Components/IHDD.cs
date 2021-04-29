using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Abstractions.Components
{
    enum RotationFrequency
    {
        _5400,
        _7200,
        _10000
    }

    enum ClipboardVolume
    {
        _32mb,
        _64mb,
        _128mb
    }

    interface IHDD
    {
        int CapacityGB { get; }
        RotationFrequency RotationFrequency { get; }
        ClipboardVolume ClipboardVolume { get; }
    }
}
