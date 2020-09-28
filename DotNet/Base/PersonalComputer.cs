using System.Collections.Generic;
using DotNet.Base.Parts.Memory;
using DotNet.Base.Parts.Memory.PersistentDataStorage;
using DotNet.Base.Parts.Motherboard;
using DotNet.Base.Parts.PowerUnit;
using DotNet.Parts.GraphicsCard;
using DotNet.Parts.Motherboard;

namespace DotNet.Base
{
    public class PersonalComputer : IPersonalComputer
    {
        public BaseMotherboard Motherboard { get; }

        public List<BaseRamModule> InstalledRamModules { get; }
        
        public BaseGraphicsCard GraphicsCard { get; }
        
        public List<BaseStorageDrive> InstalledStorageDrives { get; }
        
        public BasePowerSupplyUnit PowerSupplyUnit { get; }

        public PersonalComputer(BaseMotherboard motherboard, List<BaseRamModule> memoryUnits)
        {
            Motherboard = motherboard;
            InstalledRamModules = memoryUnits.GetRange(0, memoryUnits.Count);
        }

        public void StartComputer()
        {
            throw new System.NotImplementedException();
        }

        public void ShutDown()
        {
            throw new System.NotImplementedException();
        }
    }
}