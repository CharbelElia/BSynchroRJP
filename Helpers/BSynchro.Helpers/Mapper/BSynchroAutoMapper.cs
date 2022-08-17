using AutoMapper;

namespace BSynchro.Helpers.Mapper
{
    public class BSynchroAutoMapper : IBSynchroMapper
    {
        private readonly IMapper _autoMapper;
        public BSynchroAutoMapper(IMapper autoMapper)
        {
            this._autoMapper = autoMapper;
        }
        public TDestination Map<TDestination>(object source)
        {
            return this._autoMapper.Map<TDestination>(source);
        }
        public void Map<TDestination, TSource>(object destination, object source)
        {
            this._autoMapper.Map((TDestination)destination, (TSource)source);
        }
        public void Map<TDestination, TSource>(TDestination destination, TSource source)
        {
            this._autoMapper.Map<TSource, TDestination>(source, destination);
        }
    }
}
