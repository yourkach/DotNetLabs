using System;

namespace DotNet.Base.Logger
{
    public class ConsoleTextPrinter : ITextPrinter
    {
        public void PrintText(string text)
        {
            Console.WriteLine(text);
        }

        public void Stop()
        {
        }
    }
}