using DotNet.Base.Parts.CPU.Impl;
using DotNet.Base.Parts.Memory.Impl;
using DotNet.Base.Parts.Memory.PersistentDataStorage.Impl;
using DotNet.Base.Parts.Motherboard.Impl;
using DotNet.Base.Parts.PowerUnit.Impl;
using DotNet.Parts.GraphicsCard.Impl;

namespace DotNet.Base.Factory
{
    public class ComputerFactoryImpl : BaseComputerFactory
    {
        public override IPersonalComputer Create()
        {
            var builder = new ComputerBuilder();
            return builder
                .SetMotherboard(new AsusMotherboard())
                .SetCpu(new AmdCpu())
                .SetGraphicsCard(new AsusGraphicsCard())
                .SetPowerSupply(new ZalmanPowerUnit())
                .AddRamModule(new KingstonRamModule())
                .AddStorageDrive(new SeagateHDD())
                .Build();
        }
    }
}