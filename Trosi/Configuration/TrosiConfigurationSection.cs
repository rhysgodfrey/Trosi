using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trosi.Configuration
{
    internal class TrosiConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("clientId")]
        public string ClientId
        {
            get
            {
                return (string)base["clientId"];
            }
        }

        [ConfigurationProperty("clientSecret")]
        public string ClientSecret
        {
            get
            {
                return (string)base["clientSecret"];
            }
        }
    }
}
