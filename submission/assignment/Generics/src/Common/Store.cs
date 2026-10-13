using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Generics.Store.Common
{
    internal class Store<T>
    {
        private List<T> _values = [];
        public void Add(T value)
        {
            ArgumentNullException.ThrowIfNull(value);
            _values.Add(value);
        }

        public T? GetById(int id)
            => _values.FirstOrDefault(v => v.Id == id);

        public IReadOnlyList<T> GetAll()
            => _values.Count > 0 ? _values : [];

        public void Remove(int id)
        {
            var result = GetById(id);
            if (result is null) return;
            _values.Remove(result);
        }
    }
}
