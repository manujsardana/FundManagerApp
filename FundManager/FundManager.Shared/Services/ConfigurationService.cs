using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManager.Shared.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public string GetValueFromConfig(string configKey)
        {
            try
            {
                var configValue = ConfigurationManager.AppSettings[configKey];
                if (configValue != null)
                    return configValue.ToString();
                else
                    return null;
            }
            catch (ConfigurationException ex)
            {
                throw;
            }
        }
    }
}
