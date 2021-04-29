using Lab1.Abstractions;
using Lab1.Abstractions.Builders;
using Lab1.Abstractions.Components;
using Lab1.Builders;
using Lab1.Components;
using Lab1.Directors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class DefaultPCFactory : IPCFactory
    {
        private CPUBuilder _CPUBuilder = new CPUBuilder();
        private GPUBuilder _GPUBuilder = new GPUBuilder();
        private HDDBuilder _HDDBuilder = new HDDBuilder();
        private MotherboardBuilder _motherboardBuilder = new MotherboardBuilder();
        private PowerSupplyBuilder _powerSupplyBuilder = new PowerSupplyBuilder();
        private RAMBuilder _RAMBuilder = new RAMBuilder();

        private DefaultPCFactory() { }

        public IComputer Make(PerformanceTemplate template)
        {
            var cpuDirector = new CPUDirector(_CPUBuilder);
            var gpuDirector = new GPUDirector(_GPUBuilder);
            var hddDirector = new HDDDirector(_HDDBuilder);
            var motherboardDirector = new MotherboardDirector(_motherboardBuilder);
            var powerSupplyDirector = new PowerSupplyDirector(_powerSupplyBuilder);
            var ramDirector = new RAMDirector(_RAMBuilder);

            cpuDirector.Make(template);
            gpuDirector.Make(template);
            hddDirector.Make(template);
            motherboardDirector.Make(template);
            powerSupplyDirector.Make(template);
            ramDirector.Make(template);

            Computer result;
            switch (template)
            {
                case PerformanceTemplate.Low:
                    result = new Computer(_motherboardBuilder.Result, _CPUBuilder.Result,
                        null, _powerSupplyBuilder.Result);
                    break;
                default:
                    result = new Computer(_motherboardBuilder.Result, _CPUBuilder.Result,
                        _GPUBuilder.Result, _powerSupplyBuilder.Result);
                    break;
            }

            AddRAM(result, template);
            AddHDD(result, template);

            return result;
        }

        private void AddRAM(Computer computer, PerformanceTemplate template)
        {
            switch (template)
            {
                default:
                case PerformanceTemplate.Low:
                case PerformanceTemplate.Office:
                    for (int i = 0; i < 2; i++)
                        computer.AddRAM(_RAMBuilder.Result);
                    break;
                case PerformanceTemplate.Gaming:
                    for (int i = 0; i < 4; i++)
                        computer.AddRAM(_RAMBuilder.Result);
                    break;
            }
        }

        private void AddHDD(Computer computer, PerformanceTemplate template)
        {
            switch (template)
            {
                default:
                case PerformanceTemplate.Low:
                case PerformanceTemplate.Office:
                    computer.AddStorageDevice(_HDDBuilder.Result);
                    break;
                case PerformanceTemplate.Gaming:
                    computer.AddStorageDevice(_HDDBuilder.Result);
                    computer.AddStorageDevice(_HDDBuilder.Result);
                    break;
            }
        }

        // Static
        private static DefaultPCFactory _instance;
        public static DefaultPCFactory Instance => _instance ?? 
            (_instance = new DefaultPCFactory());


    }
}
