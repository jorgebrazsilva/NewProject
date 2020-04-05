using System;
using System.Collections.Generic;
using System.Text;

namespace Scouter.ApplicationCore.Exception
{
    [Serializable()]
    public class RegraNegocioException : System.Exception
    {
        public RegraNegocioException() : base() { }
        public RegraNegocioException(string message) : base(message) { }
        public RegraNegocioException(string message, System.Exception inner) : base(message, inner) { }
        protected RegraNegocioException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
