using System;
using TaskTracker.Contracts.Contracts;

namespace TaskTracker.Core
{
    public class DelegatingFactory<T> : IFactory<T>
    {
        private readonly Func<T> _factory;

        public DelegatingFactory(Func<T> factory)
        {
            _factory = factory;
        }

        public T Create()
        {
            return _factory();
        }
    }
}
