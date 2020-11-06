using DotNet.Parts.Memory;

namespace DotNet.Base.Parts.Memory.PersistentDataStorage
{
    // Базовый класс для дисков постоянного хранения данных
    public abstract class BaseStorageDrive : IMemoryUnit
    {
        public abstract string Name { get; }
        
        public abstract int Wattage { get; }

        public abstract int CapacityGb { get; }

        public abstract StorageDriveType DriveType { get; }
    }
}