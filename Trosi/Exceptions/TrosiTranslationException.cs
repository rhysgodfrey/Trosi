using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Trosi.Exceptions
{
    public class TrosiTranslationException : Exception
    {
        public TrosiTranslationException(string response)
            : base(string.Format(@"Unable to communicate with the Translator API: {0}", response))
        {
        }

        public TrosiTranslationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
