using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Generics.Store.Common
{
    internal class Store<T> where T : IHasId
    {
        private readonly Dictionary<int, T> _values = new();

        public void Add(T value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if (!_values.TryAdd(value.Id, value))
                throw new InvalidOperationException(
                    $"An item with Id {value.Id} already exists.");
        }

        public T? GetById(int id)
            => _values.TryGetValue(id, out var value)
                ? value
                : default;

        public IReadOnlyList<T> GetAll()
            => _values.Values.ToList().AsReadOnly();

        public void Remove(int id)
            => _values.Remove(id);
    }
}
