using System.Collections.Generic;
using System.Collections.Immutable;
using DotNet.Base.Parts.Memory;
using DotNet.Base.Parts.Memory.PersistentDataStorage;
using DotNet.Base.Parts.Motherboard;
using DotNet.Base.Parts.PowerUnit;
using DotNet.Parts;
using DotNet.Parts.CPU;
using DotNet.Parts.GraphicsCard;

#nullable enable

namespace DotNet.Base
{
    public interface IPersonalComputer : IEnumerable<IComputerPart>
    {
        // Свойства для основных комплектующих
        public BaseMotherboard? Motherboard { get; set; }
        public BasePowerSupplyUnit? PowerSupplyUnit { get; set; }
        public BaseCpu? Cpu { get; set; }
        public BaseGraphicsCard? GraphicsCard { get; set; }
        public ImmutableList<BaseRamModule> InstalledRamModules { get; }
        public ImmutableList<BaseStorageDrive> InstalledStorageDrives { get; }

        // Метод добавления нового модуля памяти, возвращает флаг об успешности установки
        public bool InstallRamModule(BaseRamModule module);

        // Метод установки нового диска
        public void InstallStorageDrive(BaseStorageDrive storageDrive);

        // Свойство, хранящее текущее состояние компьютера
        public bool IsWorking { get; }

        // Метод включения компьютера
        void StartComputer();

        // Метод выключения компьютера
        void ShutDown();
    }
}