using DotNet.Parts.Motherboard;

namespace DotNet.Parts.CPU
{
    public abstract class BaseCpu : IComputerPart
    {
        public abstract string Name { get; }

        // Тип сокета процессора
        public abstract SocketType Socket { get; }
        
        // Частота процессора в МГц
        public abstract int ClockRateMhz { get; }
        
        // Есть ли интегрированная графика
        public abstract bool HasIntegratedGraphics { get; }
    }
}