using DotNet.Parts.Motherboard;

namespace DotNet.Base.Parts.Motherboard.Impl
{
    public class AsusMotherboard : BaseMotherboard
    {
        public override string Name => "ASUS bla bla";

        public override SocketType Socket => SocketType.AM4;

        public override int MemorySlotsCount => 4;
    }
}