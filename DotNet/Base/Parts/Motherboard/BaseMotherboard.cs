namespace DotNet.Parts.Motherboard
{
    public abstract class BaseMotherboard : IComputerPart
    {
        public abstract string Name { get; }

        public abstract SocketType Socket { get; }
        
        public abstract int MemorySlotsCount { get; }
    }
}