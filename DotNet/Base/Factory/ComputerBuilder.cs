using DotNet.Base.Parts.Memory;
using DotNet.Base.Parts.Memory.PersistentDataStorage;
using DotNet.Base.Parts.Motherboard;
using DotNet.Base.Parts.PowerUnit;
using DotNet.Parts.CPU;
using DotNet.Parts.GraphicsCard;

namespace DotNet.Base.Factory
{
    public class ComputerBuilder
    {

        private IPersonalComputer _computer = new PersonalComputer();
        
        public ComputerBuilder SetMotherboard(BaseMotherboard motherboard)
        {
            _computer.Motherboard = motherboard;
            return this;
        }

        public ComputerBuilder SetPowerSupply(BasePowerSupplyUnit powerSupplyUnit)
        {
            _computer.PowerSupplyUnit = powerSupplyUnit;
            return this;
        }

        public ComputerBuilder SetGraphicsCard(BaseGraphicsCard graphicsCard)
        {
            _computer.GraphicsCard = graphicsCard;
            return this;
        }

        public ComputerBuilder AddStorageDrive(BaseStorageDrive drive)
        {
            _computer.InstallStorageDrive(drive);
            return this;
        }

        public ComputerBuilder AddRamModule(BaseRamModule module)
        {
            _computer.InstallRamModule(module);
            return this;
        }
        
        public ComputerBuilder SetCpu(BaseCpu cpu)
        {
            _computer.Cpu = cpu;
            return this;
        }
        

        public IPersonalComputer Build()
        {
            return _computer;
        }

    }
}