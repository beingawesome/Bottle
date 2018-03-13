using System;
using System.Collections.Generic;
using System.Text;

namespace Bottle.Versioning
{
    public struct Commit
    {
        public readonly static Commit Any = new Commit(-1, -1);

        public Commit(long major, long minor)
        {
            Major = major;
            Minor = minor;
        }

        public long Major { get; }
        public long Minor { get; }
    }
}
