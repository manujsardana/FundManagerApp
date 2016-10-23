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
                new Bond(new StockCreationInformation{StockType =  StockType.Bond, Price = 10, Quantity =  10}, new ConfigurationService()),
                new Bond(new StockCreationInformation{StockType =  StockType.Bond,Price =  20,Quantity =  20}, new ConfigurationService()),
                new Bond(new StockCreationInformation{StockType = StockType.Bond,Price =  30,Quantity =  30}, new ConfigurationService()),
                new Equity(new StockCreationInformation{StockType =  StockType.Equity,Price =  10,Quantity = 10}, new ConfigurationService()),
                new Equity(new StockCreationInformation{StockType =  StockType.Equity,Price =  20, Quantity =  20}, new ConfigurationService()),
                new Equity(new StockCreationInformation{StockType =  StockType.Equity, Price = 30, Quantity = 30}, new ConfigurationService()),
            };
        }
    }
}
