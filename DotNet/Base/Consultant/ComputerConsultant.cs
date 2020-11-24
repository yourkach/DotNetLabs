using System;
using System.Linq;
using DotNet.Parts;

namespace DotNet.Base
{

    public interface IComputerConsultant
    {
        public void EvaluatePowerConsumption(IPersonalComputer computer);
    }
    
    public class ComputerConsultant : IComputerConsultant
    {
        public void EvaluatePowerConsumption(IPersonalComputer computer)
        {
            Console.WriteLine("Evaluating power consumption");
            var powerConsumption = 0;
            foreach (var part in computer.OrderByDescending(part => part.Wattage))
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