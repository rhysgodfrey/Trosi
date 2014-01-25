using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Trosi.Exceptions
{
    public class TrosiAuthenticationException : Exception
    {
        public TrosiAuthenticationException(string response)
            : base(string.Format(@"Unable to authenticate with the Translator API: {0}", response))
        {
        }

        public TrosiAuthenticationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
