using Generics.Store.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Generics.Store.Extensions;
internal static class EnumerableExtensions
{
    // R1 - Pagination
    public static IEnumerable<T> Page<T>(
        this IEnumerable<T> source,
        int pageNumber,
        int pageSize)
    {
        ArgumentNullException.ThrowIfNull(source);

        if (pageNumber <= 0)
            throw new ArgumentOutOfRangeException(nameof(pageNumber));

        if (pageSize <= 0)
            throw new ArgumentOutOfRangeException(nameof(pageSize));

        return Iterate();

        IEnumerable<T> Iterate()
        {
            long skip = ((long)pageNumber - 1) * pageSize;
            long index = 0;
            int taken = 0;

            foreach (var item in source)
            {
                if (index++ < skip)
                    continue;

                yield return item;

                if (++taken == pageSize)
                    yield break;
            }
        }
    }

    // R2 - Find By Id
    public static T? FindById<T>(
        this IEnumerable<T> source,
        int id) where T : IHasId
    {
        ArgumentNullException.ThrowIfNull(source);

        foreach (var item in source)
        {
            if (item.Id == id)
                return item;
        }

        return default;
    }

    // R3 - Convert To Dictionary
    public static IReadOnlyDictionary<int, T> ToIdDictionary<T>(
        this IEnumerable<T> source) where T : IHasId
    {
        ArgumentNullException.ThrowIfNull(source);

        var dictionary = new Dictionary<int, T>();

        foreach (var item in source)
        {
            if (!dictionary.TryAdd(item.Id, item))
                throw new InvalidOperationException(
                    $"Duplicate Id: {item.Id}");
        }

        return new ReadOnlyDictionary<int, T>(dictionary);
    }
}
