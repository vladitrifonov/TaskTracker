using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Domain.Contracts
{
    public interface ISuccessHandlers
    {
        Task Handle();
    }
}
