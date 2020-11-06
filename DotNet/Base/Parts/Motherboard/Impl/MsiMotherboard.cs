using DotNet.Parts.Motherboard;

namespace DotNet.Base.Parts.Motherboard.Impl
{
    public class MsiMotherboard : BaseMotherboard
    {
        public override string Name => "MSI EW810";
        
        public override int Wattage => 45;

        public override SocketType Socket => SocketType.LGA1151;

        public override int MemorySlotsCount => 2;
    }
}