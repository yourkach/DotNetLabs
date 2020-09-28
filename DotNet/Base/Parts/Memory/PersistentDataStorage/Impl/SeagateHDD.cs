namespace DotNet.Base.Parts.Memory.PersistentDataStorage.Impl
{
    public class SeagateHDD : BaseStorageDrive
    {
        public override string Name => "Seagate IronWolf";
        public override int CapacityGb => 2048;
        public override StorageDriveType DriveType => StorageDriveType.HDD;
    }
}