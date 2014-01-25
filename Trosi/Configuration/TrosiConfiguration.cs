using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trosi.Exceptions;

namespace Trosi.Configuration
{
    internal static class TrosiConfiguration
    {
        public static string ClientId
        {
            get
            {
                return GetConfiguration().ClientId;
            }
        }

        public static string ClientSecret
        {
            get
            {
                return GetConfiguration().ClientSecret;
            }
        }

        private static TrosiConfigurationSection GetConfiguration()
        {
            var section = ConfigurationManager.GetSection("trosi");

            if (section == null)
            {
                throw new TrosiConfigurationException();
            }

            return section as TrosiConfigurationSection;
        }
    }
}
