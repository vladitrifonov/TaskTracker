using System.Collections.Generic;
using TaskTracker.Domain.DataTypes;

namespace TaskTracker.Domain.Contracts
{
    public interface IHasDomainEvent
    {
        public List<DomainEvent> DomainEvents { get; set; }
    }
}
