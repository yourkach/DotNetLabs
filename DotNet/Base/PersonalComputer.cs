using System.Collections.Generic;
using DotNet.Base.Parts.Memory;
using DotNet.Parts.Motherboard;

namespace DotNet.Base
{
    public class PersonalComputer : IPersonalComputer
    {
        public BaseMotherboard Motherboard { get; }

        public List<BaseMemoryUnit> MemoryUnits { get; }

        public PersonalComputer(BaseMotherboard motherboard, List<BaseMemoryUnit> memoryUnits)
        {
            Motherboard = motherboard;
            MemoryUnits = memoryUnits.GetRange(0, memoryUnits.Count);
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