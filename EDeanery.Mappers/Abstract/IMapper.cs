namespace EDeanery.Mappers.Abstract
{
    public interface IMapper<TIn, TOut>
    {
        TOut Map(TIn entity);
    }
}