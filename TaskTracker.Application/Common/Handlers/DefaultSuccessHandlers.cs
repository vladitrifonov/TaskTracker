using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Domain.Contracts;

namespace TaskTracker.Application.Common.Handlers
{
    public class DefaultSuccessHandlers : ISuccessHandlers
    {
        public DefaultSuccessHandlers()
        {

        }
        public Task Handle()
        {
            throw new NotImplementedException();
        }
    }
}
