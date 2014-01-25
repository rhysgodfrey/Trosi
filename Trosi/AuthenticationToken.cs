using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Trosi
{
    [DataContract]
    internal class AuthenticationToken
    {
        [DataMember]
        public string access_token { get; set; }

        [DataMember]
        public string token_type { get; set; }

        [DataMember]
        public int expires_in { get; set; }

        [DataMember]
        public string scope { get; set; }
    }
}
