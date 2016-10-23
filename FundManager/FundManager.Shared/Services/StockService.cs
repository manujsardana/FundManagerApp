using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundManager.Shared.Models;

namespace FundManager.Shared.Services
{
    public class StockService : IStockService
    {
        private readonly IStockFactory _stockFactory;
        private readonly IConfigurationService _configService;
        private List<Stock> _stocks = StocksData.GetInitlialStocks();

        public StockService(IStockFactory stockFactory, IConfigurationService configService)
        {
            _stockFactory = stockFactory;
            _configService = configService;
        }

        public Stock AddStock(IStockCreationInformation stockCreationInformation)
        {
            var stockId = _stocks.Any(p => p.StockType == stockCreationInformation.StockType) ? _stocks.Where(p => p.StockType == stockCreationInformation.StockType).Max(p => p.StockId) + 1 : 1;
            stockCreationInformation.StockId = stockId;
            Stock stock = _stockFactory.CreateStock(stockCreationInformation, _configService);
            _stocks.Add(stock);
            return stock;
        }

        public IEnumerable<Stock> GetStocks()
        {
            return _stocks;
        }
    }
}
