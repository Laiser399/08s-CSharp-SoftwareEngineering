using Lab1.Abstractions.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Components
{
    record Computer(IMotherboard Motherboard, ICPU CPU, IGPU GPU, IPowerSupply PowerSupply) : IComputer
    {
        private List<IRAM> _rams = new List<IRAM>();
        public IReadOnlyList<IRAM> RAMs => _rams;

        private List<IHDD> _storageDevices = new List<IHDD>();
        public IReadOnlyList<IHDD> StorageDevices => _storageDevices;



        public void AddRAM(IRAM ram)
        {
            _rams.Add(ram);
        }

        public void AddStorageDevice(IHDD hdd)
        {
            _storageDevices.Add(hdd);
        }
    }
}
