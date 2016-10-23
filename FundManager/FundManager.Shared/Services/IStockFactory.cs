using FundManager.Shared;
using FundManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManager.Shared.Services
{
    public interface IStockFactory
    {
        Stock CreateStock(IStockCreationInformation stockCreationInfo, IConfigurationService configService);
    }
}
