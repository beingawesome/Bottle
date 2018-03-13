using Bottle.Internal;
using Bottle.Versioning;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bottle.InMemory
{
    internal class CommitResult : MessageResult
    {
        public CommitResult(Commit commit) => Commit = commit;

        public Commit Commit { get; }
        
        public override CommandResult AsCommandResult()
        {
            return new CommandResult();
        }
    }
}
