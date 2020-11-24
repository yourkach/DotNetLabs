using System;
using DotNet.Base.Parts.Motherboard;

namespace DotNet.Base.Consultant
{
    public interface IInfoPrinter<in T>
    {
        void PrintInfo(T product);
    }

    public class MotherboardInfoPrinter : IInfoPrinter<BaseMotherboard>
    {
        public void PrintInfo(BaseMotherboard product)
        {
            Console.WriteLine("Product info: " + product.Name + ", socket: " + product.Socket + ", Memory slots:" +
                              product.MemorySlotsCount);
        }
    }
}