namespace DotNet.Base.Parts.Memory.PersistentDataStorage.Impl
{
    public class KingstonSSD : BaseStorageDrive
    {
        public override string Name => "Kingston SA400S37";

        public override int Wattage => 2;
        public override int CapacityGb => 240;
        public override StorageDriveType DriveType => StorageDriveType.SSD;
    }
}