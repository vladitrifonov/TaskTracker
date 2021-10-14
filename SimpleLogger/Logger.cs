using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger
{
    public class Logger : ILogger
    {
        private readonly IOutput _output;
        public Logger(IOutput output)
        {
            _output = output;
        }
        public Task Trace(string message)
        {
            var level = $"{nameof(Trace)}";
            return _output.Post($"{level} {message}");
        }
        public Task Debug(string message)
        {
            var level = $"{nameof(Debug)}";
            return _output.Post($"{level} {message}");
        }
        public Task Information(string message)
        {
            var level = $"{nameof(Information)}";
            return _output.Post($"{level} {message}");
        }
        public Task Warning(string message)
        {
            var level = $"{nameof(Warning)}";
            return _output.Post($"{level} {message}");
        }
        public Task Error(string message)
        {
            var level = $"{nameof(Error)}";
            return _output.Post($"{level} {message}");
        }
    }
}
