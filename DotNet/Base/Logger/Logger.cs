using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace DotNet.Base.Logger
{
    public class Logger
    {
        public delegate void LogEventHandler(string eventMessage);

        private static event LogEventHandler EventHandler;
        
        private static readonly DateTime _loggerStartTime = DateTime.Now;

        public static void OnEvent(string message)
        {
            EventHandler?.Invoke(message);
        }

        // non static:
        
        private readonly string _prefix;

        private readonly ITextPrinter _textPrinter;
        
        public Logger(ITextPrinter textPrinter, string logsPrefix = "Logger:")
        {
            _textPrinter = textPrinter;
            _prefix = logsPrefix;
            EventHandler += WriteEvent;
        }
        
        public void Stop()
        {
            _textPrinter.Stop();
        }

        private void WriteEvent(string message)
        {
            var eventTimeSpan = DateTime.Now - _loggerStartTime;
            _textPrinter.PrintText($"{_prefix} {eventTimeSpan} {message}");
        }
    }

    public interface ITextPrinter
    {
        void PrintText(string text);

        void Stop();
    }

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

    public class FileTextPrinter : ITextPrinter
    {

        private StreamWriter _fileStream;
        
        private StringBuilder _builder = new StringBuilder();

        private string _filePath;

        public FileTextPrinter(string filePath)
        {
            _filePath = filePath;
        }

        public void PrintText(string text)
        {
            _builder.AppendLine(text);
        }

        public void Stop()
        {
            File.WriteAllText(_filePath,_builder.ToString());
        }
    }
}