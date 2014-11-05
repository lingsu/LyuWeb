using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lyu.Core
{
    [Serializable]
    public class LyuException:Exception
    {
        protected LyuException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public LyuException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public LyuException(string messageFormat, params object[] args)
            : base(string.Format(messageFormat,args))
        {
        }
        public LyuException(string message) : base(message)
        {
        }

        public LyuException()
        {
        }
    }
}
