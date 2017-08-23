namespace dtu.blognet.Core.Command.MappingInterfaces
{
    public interface IMappingInterface<in TSource, out TDestination>
    {
        TDestination Convert(TSource sourceObject);
    }
}