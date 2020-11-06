namespace DotNet.Parts
{
    // Базовый интерфейс для классов комплектующих ПК
    public interface IComputerPart
    {
        // Название единицы комплектующего
        public string Name { get; }

        // Использование комплектующим мощности в Вт
        public int Wattage => 0;
    }
}