using TaskTracker.Domain.Contracts;

namespace TaskTracker.Application.Common.Mapper
{
    public class SimpleMapper : IMapper
    {
        private readonly AutoMapper.IMapper _autoMapper;

        public SimpleMapper(AutoMapper.IMapper autoMapper)
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

        public TDest Map<TSource, TDest>(TSource source, TDest destination)
        {
            return _autoMapper.Map(source, destination);
        }
    }
}
