using Lab1.Abstractions.Builders;
using Lab1.Abstractions.Components;
using Lab1.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Builders
{
    class HDDBuilder : IHDDBuilder
    {
        private const int _defaultCapacityGB = 256;
        private const ClipboardVolume _defaultClipboardVolume = ClipboardVolume._32mb;
        private const RotationFrequency _defaultRotationFrequency = RotationFrequency._5400;

        private int _capacityGB = _defaultCapacityGB;
        private ClipboardVolume _clipboardVolume = _defaultClipboardVolume;
        private RotationFrequency _rotationFrequency = _defaultRotationFrequency;

        public HDD Result => new HDD(_capacityGB, _rotationFrequency, _clipboardVolume);

        public void SetCapacityGB(int capacityGB)
        {
            _capacityGB = capacityGB;
        }

        public void SetClipboardVolume(ClipboardVolume clipboardVolume)
        {
            _clipboardVolume = clipboardVolume;
        }

        public void SetRotationFrequency(RotationFrequency frequency)
        {
            _rotationFrequency = frequency;
        }

        public void Reset()
        {
            _capacityGB = _defaultCapacityGB;
            _clipboardVolume = _defaultClipboardVolume;
            _rotationFrequency = _defaultRotationFrequency;
        }
    }
}
