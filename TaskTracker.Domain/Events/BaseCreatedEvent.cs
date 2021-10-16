using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Domain.DataTypes;

namespace TaskTracker.Domain.Events
{
    public class BaseCreatedEvent<TEntity> : DomainEvent
    {
        public BaseCreatedEvent(TEntity item)
        {
            Item = item;
        }

        public TEntity Item { get; }
    }
}
