using System;
using System.Linq;

namespace DotNet.Base
{
    public class ComputerHelper
    {
        public void EvaluateComputerPowerConsumption(IPersonalComputer computer)
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