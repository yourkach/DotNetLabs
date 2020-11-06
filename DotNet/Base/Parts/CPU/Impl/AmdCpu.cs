using System.Runtime.InteropServices;
using DotNet.Parts.CPU;
using DotNet.Parts.Motherboard;

namespace DotNet.Base.Parts.CPU.Impl
{
    public class AmdCpu : BaseCpu
    {
        public override string Name => "AMD Ryzen 5 3600";

        public override int Wattage => 115;
        public override int ClockRateMhz => 3600;
        public override SocketType Socket => SocketType.AM4;
        public override bool HasIntegratedGraphics => false;
    }
}