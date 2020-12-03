using System;
using System.IO.Compression;

namespace DotNet.Base.Logger
{
    public class Logger
    {
        public delegate void LogEventHandler(string eventMessage);

        private static event LogEventHandler EventHandler;
        
        private static readonly DateTime LoggerStartTime = DateTime.Now;

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
            var eventTimeSpan = DateTime.Now - LoggerStartTime;
            _textPrinter.PrintText($"{_prefix} {eventTimeSpan} {message}");
        }
    }
}