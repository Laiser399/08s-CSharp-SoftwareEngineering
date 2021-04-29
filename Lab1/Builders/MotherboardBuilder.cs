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
    class MotherboardBuilder : IMotherboardBuilder
    {
        private const RAMCount _defaultRAMCount = RAMCount._2;

        private bool _bluetooth = false;
        private bool _integratedGPU = false;
        private bool _SSDM2Slot = false;
        private bool _wifi = false;
        private RAMCount _RAMCount = _defaultRAMCount;

        public Motherboard Result => new Motherboard(_integratedGPU, _RAMCount,
            _SSDM2Slot, _wifi, _bluetooth);

        public void BuildBluetooth()
        {
            _bluetooth = true;
        }

        public void BuildIntegratedGPU()
        {
            _integratedGPU = true;
        }

        public void BuildSSDM2Slot()
        {
            _SSDM2Slot = true;
        }

        public void BuildWiFi()
        {
            _wifi = true;
        }

        public void SetRAMCount(RAMCount ramCount)
        {
            _RAMCount = ramCount;
        }

        public void Reset()
        {
            _bluetooth = false;
            _integratedGPU = false;
            _SSDM2Slot = false;
            _wifi = false;
            _RAMCount = _defaultRAMCount;
        }

        
    }
}
