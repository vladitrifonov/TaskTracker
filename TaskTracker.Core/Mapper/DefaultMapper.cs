using TaskTracker.Contracts.Contracts;

namespace TaskTracker.Core.Mapper
{
    public class DefaultMapper : IMapper
    {
        private readonly AutoMapper.IMapper _autoMapper;

        public DefaultMapper(AutoMapper.IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }

        public T Map<T>(object source)
        {
            return _autoMapper.Map<T>(source);
        }

        public TDest Map<TSource, TDest>(TSource source)
        {
            return _autoMapper.Map<TSource, TDest>(source);
        }
    }
}
