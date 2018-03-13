using Bottle.Versioning;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bottle
{
    public class CommandResult : ErrorContainer
    {
        public CommandResult() : this(Commit.Any) { }

        public CommandResult(Commit commit): base() => Commit = commit;
        
        public Commit Commit { get; }
    }
}
