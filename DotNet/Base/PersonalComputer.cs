using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using DotNet.Base.Parts.Memory;
using DotNet.Base.Parts.Memory.PersistentDataStorage;
using DotNet.Base.Parts.Motherboard;
using DotNet.Base.Parts.PowerUnit;
using DotNet.Parts.CPU;
using DotNet.Parts.GraphicsCard;
using DotNet.Parts.Motherboard;

#nullable enable

namespace DotNet.Base
{
    public class PersonalComputer : IPersonalComputer
    {
        private BaseMotherboard? _motherboard;
        private BasePowerSupplyUnit? _powerSupplyUnit;
        private BaseCpu? _cpu;
        private BaseGraphicsCard? _graphicsCard;
        private readonly List<BaseRamModule> _installedRamModules = new List<BaseRamModule>();
        private readonly List<BaseStorageDrive> _installedStorageDrives = new List<BaseStorageDrive>();

        public BaseMotherboard? Motherboard
        {
            get => _motherboard;
            set
            {
                CheckCanReplacePart();
                _motherboard = value;
            }
        }

        public BasePowerSupplyUnit? PowerSupplyUnit
        {
            get => _powerSupplyUnit;
            set
            {
                CheckCanReplacePart();
                _powerSupplyUnit = value;
            }
        }

        public BaseCpu? Cpu
        {
            get => _cpu;
            set
            {
                CheckCanReplacePart();
                _cpu = value;
            }
        }

        public BaseGraphicsCard? GraphicsCard
        {
            get => _graphicsCard;
            set
            {
                CheckCanReplacePart();
                _graphicsCard = value;
            }
        }

        public ImmutableList<BaseRamModule> InstalledRamModules => _installedRamModules.ToImmutableList();
        public ImmutableList<BaseStorageDrive> InstalledStorageDrives => _installedStorageDrives.ToImmutableList();

        public bool InstallRamModule(BaseRamModule module)
        {
            CheckCanReplacePart();
            if (_installedRamModules.Count < _motherboard.MemorySlotsCount)
            {
                _installedRamModules.Add(module);
                return true;
            }
            else return false;
        }

        public void InstallStorageDrive(BaseStorageDrive storageDrive)
        {
            CheckCanReplacePart();
            _installedStorageDrives.Add(storageDrive);
        }

        public bool IsWorking { get; private set; }


        public void StartComputer()
        {
            Console.WriteLine("Trying to start computer...");
            if (!IsWorking && CanStartComputer())
            {
                IsWorking = true;
                Console.WriteLine("Computer started successfully");
            }
            else if (IsWorking)
            {
                Console.WriteLine("Computer is working already");
            }
            else
            {
                Console.WriteLine("Can not start computer");
            }
        }

        public void ShutDown()
        {
            if (IsWorking)
            {
                Console.WriteLine("Shut down computer");
                IsWorking = false;
            }
        }

        private bool CanStartComputer()
        {
            return HasAllRequiredParts() && InstalledPartsAreCompatible();
        }

        private bool HasAllRequiredParts()
        {
            PrintInstalledPartsList();
            return HasMotherboard()
                   && HasCpu()
                   && HasPowerSupplyUnit()
                   && HasGraphics()
                   && HasRamModules()
                   && HasStorageDrives();
        }

        private bool InstalledPartsAreCompatible()
        {
            return Motherboard.Socket == Cpu.Socket;
        }

        private bool HasMotherboard() => Motherboard != null;
        private bool HasCpu() => Cpu != null;
        private bool HasPowerSupplyUnit() => PowerSupplyUnit != null;
        private bool HasRamModules() => InstalledRamModules != null && InstalledRamModules.Count > 0;
        private bool HasStorageDrives() => InstalledStorageDrives != null && InstalledStorageDrives.Count > 0;
        private bool HasGraphics() => Cpu.HasIntegratedGraphics || GraphicsCard != null;

        private void CheckCanReplacePart()
        {
            if (IsWorking) throw new ComputerIsWorkingException("Cannot replace parts when computer is working");
        }

        private void PrintInstalledPartsList()
        {
            Console.WriteLine("CPU: " + Cpu?.Name ?? "not installed");
            Console.WriteLine("Motherboard: " + Motherboard?.Name ?? "not installed");
            Console.WriteLine("Power Supply: " + PowerSupplyUnit?.Name ?? "not installed");
            Console.Write("Graphics Card: " + GraphicsCard?.Name ?? "not installed");
            Console.Write(_installedRamModules.Count + "RAM Modules: " +
                          string.Join(", ", _installedRamModules.Select(it => it.Name)) + "\n");
            Console.Write(_installedStorageDrives.Count + "Storage Drives: " +
                          string.Join(", ", _installedStorageDrives.Select(it => it.Name)) + "\n");
        }
    }
}