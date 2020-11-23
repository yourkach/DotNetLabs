namespace DotNet.Base.Factory
{
    public interface IFactory<out T>
    {
        public T Create();
    }
}