using System;
using DotNet.Base.Parts.Motherboard;

namespace DotNet.Base.Consultant
{
    public interface IProductConsultant<in T>
    {
        void PrintProductInfo(T product);
    }

    public class MotherboardConsultant : IProductConsultant<BaseMotherboard>
    {
        public void PrintProductInfo(BaseMotherboard product)
        {
            Console.WriteLine("Product info: " + product.Name + ", socket: " + product.Socket + ", Memory slots:" +
                              product.MemorySlotsCount);
        }
    }
}