using System;
using System.Collections.Generic;
using System.Linq;
using DotNet.Base;
using DotNet.Base.Consultant;
using DotNet.Base.Factory;
using DotNet.Base.Parts.CPU.Impl;
using DotNet.Base.Parts.Memory;
using DotNet.Base.Parts.Motherboard;
using DotNet.Base.Parts.Motherboard.Impl;
using DotNet.Parts;

namespace DotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            IFactory<IPersonalComputer> computerFactory = new ComputerFactoryImpl();
            Console.WriteLine("Building computer..\n");
            var computer = computerFactory.Create();
            Console.WriteLine("New computer created\n");

            Console.WriteLine("Computer parts:");

            EvaluateComputerPowerConsumption(computer);

            computer.StartComputer();
            computer.ShutDown();

            
            // Ковариантность интерфейса Factory
            IFactory<IEnumerable<IComputerPart>> partsCollectionFactory = computerFactory;
            partsCollectionFactory.Create();
            
            // Контрвариантность интерфейса IProductConsultant 
            IProductConsultant<MsiMotherboard> cpuConsultant = new MotherboardConsultant();
            cpuConsultant.PrintProductInfo(new MsiMotherboard());
        }

        private static void EvaluateComputerPowerConsumption(IPersonalComputer computer)
        {
            Console.WriteLine("Evaluating power consumption");
            var powerConsumption = 0;
            foreach (var part in computer.OrderByDescending(p => p.Wattage))
            {
                powerConsumption += part.Wattage;
                Console.WriteLine(part.Wattage + " - " + part.Name);
            }

            Console.WriteLine("\nComputer parts wattage sum: " + powerConsumption);
            Console.WriteLine("Computer power supply unit wattage: " + computer.PowerSupplyUnit?.PowerWatts);
            Console.WriteLine();
        }
    }
}