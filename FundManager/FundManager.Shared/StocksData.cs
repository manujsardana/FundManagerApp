using FundManager.Shared.Models;
using FundManager.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManager.Shared
{
    public static class StocksData
    {
        public static List<Stock> GetInitlialStocks()
        {
            return new List<Stock>()
            {
                new Bond(new StockCreationInformation{StockType =  StockType.Bond, Price = 1, Quantity =  1, StockId = 1}, new ConfigurationService()),
                new Bond(new StockCreationInformation{StockType =  StockType.Bond,Price =  2,Quantity =  2, StockId = 2}, new ConfigurationService()),
                new Bond(new StockCreationInformation{StockType = StockType.Bond,Price =  3,Quantity =  3, StockId = 3}, new ConfigurationService()),
                new Equity(new StockCreationInformation{StockType =  StockType.Equity,Price =  1,Quantity = 1, StockId = 1}, new ConfigurationService()),
                new Equity(new StockCreationInformation{StockType =  StockType.Equity,Price =  2, Quantity =  2, StockId = 2}, new ConfigurationService()),
                new Equity(new StockCreationInformation{StockType =  StockType.Equity, Price = 3, Quantity = 3, StockId = 3}, new ConfigurationService()),
            };
        }
    }
}
