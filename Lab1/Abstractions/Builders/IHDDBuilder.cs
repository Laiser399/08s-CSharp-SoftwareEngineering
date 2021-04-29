using Lab1.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Abstractions.Builders
{
    interface IHDDBuilder
    {
        void SetCapacityGB(int capacityGB);
        void SetRotationFrequency(RotationFrequency frequency);
        void SetClipboardVolume(ClipboardVolume clipboardVolume);
    }
}
