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

            computer.SetPartsComparison(CompareByWattageDescending);
            
            Console.WriteLine("Parts sorted by wattage:");
            foreach (var part in computer)
            {
                powerConsumption += part.Wattage;
                Console.WriteLine(part.Wattage + " - " + part.Name);
            }

            Console.WriteLine("\nComputer parts wattage sum: " + powerConsumption);
            Console.WriteLine("Computer power supply unit wattage: " + computer.PowerSupplyUnit?.PowerWatts);
            if (powerConsumption < (computer.PowerSupplyUnit?.PowerWatts ?? 0))
            {
                Console.WriteLine("Computer has enough power");
            }
            else
            {
                Console.WriteLine("Computer doesn't have enough power");
            }
        }

        private int CompareByWattageDescending(IComputerPart a, IComputerPart b)
        {
            return b.Wattage.CompareTo(a.Wattage);
        }
    }
}