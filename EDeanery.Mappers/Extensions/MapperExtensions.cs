using System.Collections.Generic;
using System.Linq;
using EDeanery.Mappers.Abstract;

namespace EDeanery.Mappers.Extensions
{
    public static class MapperExtensions
    {
        public static IEnumerable<TOut> Map<TIn, TOut>(this IMapper<TIn, TOut> mapper, IEnumerable<TIn> entities)
        {
            return entities.Select(e => mapper.Map(e));
        }
    }
}