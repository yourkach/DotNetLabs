using DotNet.Parts;

namespace DotNet.Base.Parts.PowerUnit
{
    // Базовый класс для блоков питания
    public abstract class BasePowerSupplyUnit : IComputerPart
    {
        public abstract string Name { get; }

        public int Wattage => 0;

        // Мощность блока питания
        public abstract int PowerWatts { get; }
        
    }
}