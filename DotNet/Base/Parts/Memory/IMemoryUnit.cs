namespace DotNet.Parts.Memory
{
    public interface IMemoryUnit : IComputerPart
    {
        // Объем памяти единицы
        public int CapacityGb { get; }
    }
}