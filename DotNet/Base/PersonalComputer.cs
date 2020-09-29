using System;
using System.Collections.Generic;
using System.Linq;
using DotNet.Base.Parts.Memory;
using DotNet.Base.Parts.Memory.PersistentDataStorage;
using DotNet.Base.Parts.Motherboard;
using DotNet.Base.Parts.PowerUnit;
using DotNet.Parts.CPU;
using DotNet.Parts.GraphicsCard;
using DotNet.Parts.Motherboard;

namespace DotNet.Base
{
    public class PersonalComputer : IPersonalComputer
    {
        public BaseMotherboard Motherboard { get; private set; }
        public BasePowerSupplyUnit PowerSupplyUnit { get; private set; }
        public BaseCpu Cpu { get; private set; }
        public List<BaseRamModule> InstalledRamModules { get; private set; }
        public BaseGraphicsCard GraphicsCard { get; private set; }
        public List<BaseStorageDrive> InstalledStorageDrives { get; private set; }

        public bool IsWorking { get; private set; }

        public PersonalComputer()
        {
            InstalledRamModules = new List<BaseRamModule>();
            InstalledStorageDrives = new List<BaseStorageDrive>();
        }

        public void InstallMotherboard(BaseMotherboard motherboard)
        {
            if (IsWorking) throw new ComputerIsWorkingException();
            Motherboard = motherboard;
        }

        public void InstallCpu(BaseCpu cpu)
        {
            if (IsWorking) throw new ComputerIsWorkingException();
            Cpu = cpu;
        }

        public void InstallRamModule(BaseRamModule module)
        {
            if (IsWorking) throw new ComputerIsWorkingException();
            if (InstalledRamModules.Count < Motherboard.MemorySlotsCount)
            {
                InstalledRamModules.Add(module);
            }
        }

        public void InstallPowerSupply(BasePowerSupplyUnit powerSupplyUnit)
        {
            if (IsWorking) throw new ComputerIsWorkingException();
            
        }

        public void InstallGraphicsCard(BaseGraphicsCard graphicsCard)
        {
            throw new NotImplementedException();
        }

        public void InstallStorageDrive(BaseStorageDrive storageDrive)
        {
            throw new NotImplementedException();
        }

        public void StartComputer()
        {
            if (CanStartComputer())
            {
                IsWorking = true;
                Console.WriteLine("Computer started successfully");
            }
            else
            {
                Console.WriteLine("Can not start computer");
            }
        }

        public void ShutDown()
        {
            IsWorking = false;
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

        private void PrintInstalledPartsList()
        {
            Console.WriteLine("CPU: " + Cpu?.Name ?? "not installed");
            Console.WriteLine("Motherboard: " + Motherboard?.Name ?? "not installed");
            Console.WriteLine("Power Supply: " + PowerSupplyUnit?.Name ?? "not installed");
            Console.Write("Graphics Card: " + GraphicsCard?.Name ?? "not installed");
            Console.Write("RAM Modules: " + string.Join(", ", InstalledRamModules.Select(it => it.Name)) + "\n");
            Console.Write("Storage Drives: " + string.Join(", ", InstalledStorageDrives.Select(it => it.Name)) + "\n");
        }
    }
}