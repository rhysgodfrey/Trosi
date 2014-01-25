using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Trosi.Exceptions
{
    public class TrosiConfigurationException : Exception
    {
        public TrosiConfigurationException()
            : base("A configuration section named 'trosi' of type 'Trosi.Configuration.TrosiConfigurationSection, Trosi' must be present with your Microsoft Translator API keys. Go to https://datamarket.azure.com/developer/applications to create a client id and secret.")
        {
        }

        public TrosiConfigurationException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
