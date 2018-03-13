using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Bottle
{
    public class ErrorGroup : IEnumerable<Error>
    {
        private List<Error> _inner = new List<Error>();
        
        internal ErrorGroup(string key) => Key = key;

        public string Key { get; }
        
        internal void Add(Error error) => _inner.Add(error);

        public IEnumerator<Error> GetEnumerator() => _inner.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
