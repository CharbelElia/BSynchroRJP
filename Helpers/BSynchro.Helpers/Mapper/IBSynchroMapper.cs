namespace BSynchro.Helpers.Mapper
{
    public interface IBSynchroMapper
    {
        TDestination Map<TDestination>(object source);
        void Map<TDestination, TSource>(object destination, object source);
        void Map<TDestination, TSource>(TDestination destination, TSource source);
    }
}
