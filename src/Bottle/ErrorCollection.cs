using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bottle
{
    public class ErrorCollection : IEnumerable<ErrorGroup>
    {
        private Dictionary<string, ErrorGroup> _inner = new Dictionary<string, ErrorGroup>();

        internal ErrorCollection() { }

        public bool HasErrors => _inner.Any();

        public void Add(string key, Error error)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (error == null) throw new ArgumentNullException(nameof(error));

            if (!_inner.TryGetValue(key, out var errors))
            {
                errors = _inner[key] = new ErrorGroup(key);
            }

            errors.Add(error);
        }

        public IEnumerator<ErrorGroup> GetEnumerator() => _inner.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
