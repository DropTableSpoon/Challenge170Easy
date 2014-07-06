using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge170Easy
{
    [Serializable]
    public class DrawException : Exception
    {
        public DrawException() : base("Two or more players have drawn.") { }
        public DrawException(string message) : base(message) { }
        public DrawException(string message, Exception inner) : base(message, inner) { }
        protected DrawException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
