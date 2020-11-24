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

            var helper = new ComputerHelper();
            helper.EvaluateComputerPowerConsumption(computer);

            computer.StartComputer();
            computer.ShutDown();

            
            // Ковариантность интерфейса IFactory
            IFactory<IEnumerable<IComputerPart>> partsCollectionFactory = computerFactory;
            var partsCollection = partsCollectionFactory.Create();
            
            // Контрвариантность интерфейса IProductConsultant 
            IInfoPrinter<MsiMotherboard> cpuConsultant = new MotherboardInfoPrinter();
            cpuConsultant.PrintInfo(new MsiMotherboard());
        }
    }
}