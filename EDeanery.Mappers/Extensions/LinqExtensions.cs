using System.Collections.Generic;

namespace EDeanery.Mappers.Extensions
{
    public static class LinqExtensions
    {
        public static IReadOnlyList<T> AsReadOnlyList<T>(this IList<T> list)
        {
            return (IReadOnlyList<T>) list;
        }

        public static IReadOnlyCollection<T> AsReadOnlyCollection<T>(this ICollection<T> collection)
        {
            return (IReadOnlyCollection<T>) collection;
        }

        public static IReadOnlyDictionary<TKey, TValue> AsReadOnlyDictionary<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary)
        {
            return (IReadOnlyDictionary<TKey, TValue>) dictionary;
        }
    }
}