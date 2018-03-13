using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bottle.Internal
{
    public delegate Task<MessageResult> Middleware(MessageContext context, MessageDelegate next);
}
