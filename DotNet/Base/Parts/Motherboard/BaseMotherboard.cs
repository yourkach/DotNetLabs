using DotNet.Parts;
using DotNet.Parts.Motherboard;

namespace DotNet.Base.Parts.Motherboard
{
    public abstract class BaseMotherboard : IComputerPart
    {
        public abstract string Name { get; }

        public abstract int Wattage { get; }

        public abstract SocketType Socket { get; }
        
        public abstract int MemorySlotsCount { get; }
    }
}