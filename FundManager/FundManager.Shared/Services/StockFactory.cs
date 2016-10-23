using FundManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManager.Shared.Services
{
    public class StockFactory : IStockFactory
    {
        public Stock CreateStock(IStockCreationInformation stockCreationInfo, IConfigurationService configService)
        {
            switch (stockCreationInfo.StockType)
            {
                case StockType.Bond:
                    return new Bond(stockCreationInfo, configService);
                case StockType.Equity:
                    return new Equity(stockCreationInfo, configService);
                default:
                    throw new ArgumentOutOfRangeException("Stock Type is not valid");
            }
        }
    }
}
