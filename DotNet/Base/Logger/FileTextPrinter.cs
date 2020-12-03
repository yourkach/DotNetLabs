using System.IO;
using System.Text;

namespace DotNet.Base.Logger
{
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