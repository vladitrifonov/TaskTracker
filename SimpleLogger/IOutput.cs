using System.Threading.Tasks;

namespace SimpleLogger
{
    public interface IOutput
    {
        Task Post(string message);
    }
}
