namespace DotNet.Base.Logger
{
    public interface ITextPrinter
    {
        void PrintText(string text);

        void Stop();
    }
}