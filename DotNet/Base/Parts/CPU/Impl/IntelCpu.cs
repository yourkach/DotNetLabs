using DotNet.Parts.CPU;
using DotNet.Parts.Motherboard;

namespace DotNet.Base.Parts.CPU.Impl
{
    public class IntelCpu : BaseCpu
    {
        public override string Name => "Intel Core i5-9600KF";

        public override int Wattage => 110;
        public override int ClockRateMhz => 3700;
        public override SocketType Socket => SocketType.LGA1151;
        public override bool HasIntegratedGraphics => true;
    }
}