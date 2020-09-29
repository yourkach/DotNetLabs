using System;
using DotNet.Base.Factory;

namespace DotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseComputerFactory factory = new ComputerFactoryImpl();

            var computer = factory.Create();
            
            computer.StartComputer();
        }
    }
}