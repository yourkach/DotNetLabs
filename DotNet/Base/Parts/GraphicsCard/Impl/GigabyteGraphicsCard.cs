namespace DotNet.Parts.GraphicsCard.Impl
{
    public class GigabyteGraphicsCard : BaseGraphicsCard
    {
        public override string Name => "GIGABYTE GTX 1660";
        public override int Wattage => 280;
        public override int MemoryCapacityGb => 6;
        public override int BandwidthBits => 192;
    }
}