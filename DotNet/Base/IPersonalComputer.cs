using DotNet.Base.Parts.Memory;
using DotNet.Base.Parts.Memory.PersistentDataStorage;
using DotNet.Base.Parts.Motherboard;
using DotNet.Base.Parts.PowerUnit;
using DotNet.Parts.CPU;
using DotNet.Parts.GraphicsCard;

namespace DotNet.Base
{
    interface IPersonalComputer
    {
        void InstallMotherboard(BaseMotherboard motherboard);
        void InstallCpu(BaseCpu cpu);
        void InstallRamModule(BaseRamModule module);
        void InstallPowerSupply(BasePowerSupplyUnit powerSupplyUnit);
        void InstallGraphicsCard(BaseGraphicsCard graphicsCard);
        void InstallStorageDrive(BaseStorageDrive storageDrive);
        
        public bool IsWorking { get; }

        void StartComputer();

        void ShutDown();
    }
}