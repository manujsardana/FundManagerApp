using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManager.Shared.Services
{
    public interface IConfigurationService
    {
        string GetValueFromConfig(string configKey);
    }
}
