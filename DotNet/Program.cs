using System;
using DotNet.Base.Factory;

namespace DotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseComputerFactory factory = new ComputerFactoryImpl();
            Console.WriteLine("Building computer..\n");
            var computer = factory.Create();
            Console.WriteLine("New computer created\n");
            
            computer.StartComputer();
            computer.ShutDown();
        }
    }
}