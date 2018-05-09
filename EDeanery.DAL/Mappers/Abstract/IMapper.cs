namespace EDeanery.DAL.Mappers.Abstract
{
    public interface IMapper<TIn, TOut>
    {
        TOut Map(TIn entity);
    }
}