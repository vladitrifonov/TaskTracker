using System.IO;
using System.Threading.Tasks;

namespace SimpleLogger
{
    public class FileOutput : IOutput
    {
        private readonly string _filePath;
        public FileOutput(string filePath)
        {
            _filePath = filePath;
        }
        public Task Post(string message)
        {
            return File.WriteAllTextAsync(_filePath, message);
        }
    }
}
