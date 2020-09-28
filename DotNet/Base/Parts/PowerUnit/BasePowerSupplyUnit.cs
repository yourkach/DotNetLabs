using DotNet.Parts;

namespace DotNet.Base.Parts.PowerUnit
{
    // Базовый класс для блоков питания
    public abstract class BasePowerSupplyUnit : IComputerPart
    {
        public abstract string Name { get; }
        
        // Мощность блока питания
        public abstract int PowerWatts { get; }
        
    }
}