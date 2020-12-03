using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotNet.Base;
using DotNet.Base.Factory;
using DotNet.Base.Logger;
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
            
            var consoleLogger = new Logger(new ConsoleTextPrinter());
            var fileLogger = new Logger(new FileTextPrinter($"{DateTime.Now}_logs"));
            
            Logger.OnEvent("Program started");

            IFactory<IPersonalComputer> computerFactory = new ComputerFactoryImpl();
            Console.WriteLine("Building computer..\n");
            var computer = computerFactory.Create();
            Console.WriteLine("New computer created\n");
            Logger.OnEvent("Computer building finished");

            Console.WriteLine("Computer parts:");

            IComputerConsultant consultant = new ComputerConsultant();
            consultant.EvaluatePowerConsumption(computer);
            Logger.OnEvent("Evaluated power consumption");

            computer.StartComputer();
            computer.ShutDown();

            // Ковариантность интерфейса IFactory
            IFactory<IEnumerable<IComputerPart>> partsCollectionFactory = computerFactory;
            var partsCollection = partsCollectionFactory.Create();
            
            Logger.OnEvent("Program finished");
            
            fileLogger.Stop();
            consoleLogger.Stop();
        }
    }
}