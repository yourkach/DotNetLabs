namespace DotNet.Parts.GraphicsCard
{
    public abstract class BaseGraphicsCard : IComputerPart
    {
        
        public abstract string Name { get; }

        public abstract int MemoryCapacityGb { get; }

        // Ширина шины видеокарты
        public abstract int BandwidthBits { get; }
    }
}