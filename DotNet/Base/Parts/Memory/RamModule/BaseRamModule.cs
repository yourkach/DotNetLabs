using DotNet.Parts;
using DotNet.Parts.Memory;

namespace DotNet.Base.Parts.Memory
{
    public abstract class BaseRamModule : IMemoryUnit
    {
        public abstract string Name { get; }
        
        public abstract int CapacityGb { get; }
    }
}