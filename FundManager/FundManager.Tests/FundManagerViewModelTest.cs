using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using FundManager.Shared.Services;
using FundManager.Shared.Models;
using FundManager.ViewModels;
using FundManager.Shared;
using FluentAssertions;
using System.Collections.Generic;

namespace FundManager.Test
{
    [TestFixture]
    public class FundManagerViewModelTest
    {
        private Mock<IStockService> _stockServiceMock;
        private List<Stock> _stocks;
        private FundManagerViewModel _fundManager;
        private Mock<IStockCreationInformation> _stockCreationInformationMock;
        [SetUp]
        public void SetUp()
        {
            _stockServiceMock = new Mock<IStockService>();
            Mock<IConfigurationService> configServiceMock = new Mock<IConfigurationService>();
            _stockServiceMock.Setup(x => x.GetStocks()).Returns(StocksData.GetInitlialStocks());
            _stocks = new List<Stock>()
            {
                new Bond(new StockCreationInformation{StockType =  StockType.Bond, Price = 1, Quantity =  1, StockId = 1}, new ConfigurationService()),
                new Bond(new StockCreationInformation{StockType =  StockType.Bond,Price =  2,Quantity =  2, StockId = 2}, new ConfigurationService()),
                new Bond(new StockCreationInformation{StockType = StockType.Bond,Price =  3,Quantity =  3, StockId = 3}, new ConfigurationService()),
                new Equity(new StockCreationInformation{StockType =  StockType.Equity,Price =  1,Quantity = 1, StockId = 1}, new ConfigurationService()),
                new Equity(new StockCreationInformation{StockType =  StockType.Equity,Price =  2, Quantity =  2, StockId = 2}, new ConfigurationService()),
                new Equity(new StockCreationInformation{StockType =  StockType.Equity, Price = 3, Quantity = 3, StockId = 3}, new ConfigurationService()),
            };
            _stockCreationInformationMock = new Mock<IStockCreationInformation>();
            var stockCreationInfo = new StockCreationInformation { Price = 10, StockType = StockType.Bond, Quantity = 10 };
            _stockCreationInformationMock.Setup(stockCreator => stockCreator.GetStockCreationInformation(It.IsAny<StockType>(), It.IsAny<decimal>(), It.IsAny<long>())).Returns(stockCreationInfo);


            _stockServiceMock.Setup(x => x.AddStock(It.IsAny<IStockCreationInformation>())).Returns(new Bond(stockCreationInfo, configServiceMock.Object));
            _fundManager = new FundManagerViewModel(_stockServiceMock.Object, _stockCreationInformationMock.Object);
        }

        [Test]
        public void InitialStocksFromConstrutor()
        {
            _fundManager.Stocks.Count.Should().Be(_stocks.Count);
            for (int stockId = 0; stockId < _stocks.Count(); stockId++)
            {
                _fundManager.Stocks[stockId].Price.Should().Be(_stocks[stockId].Price);
                _fundManager.Stocks[stockId].Quantity.Should().Be(_stocks[stockId].Quantity);
            }
        }

        [Test]
        public void Constructor_EquityTotalMarketValue_Correct()
        {
            _fundManager.EquityTotalMarketValue.Should().Be(_fundManager.Stocks.Where(p => p.StockType == StockType.Equity).Sum(p => p.MarketValue));
        }

        [Test]
        public void Constructor_EquityTotalNumber_Correct()
        {
            _fundManager.EquityTotalNumber.Should().Be(_fundManager.Stocks.Where(p => p.StockType == StockType.Equity).Sum(p => p.Quantity));
        }

        [Test]
        public void Constructor_EquityTotalStockWeight_Correct()
        {
            _fundManager.EquityTotalStockWeight.Should().Be(_fundManager.Stocks.Where(p => p.StockType == StockType.Equity).Sum(p => p.StockWeight));
        }

        [Test]
        public void Constructor_BondTotalMarketValue_Correct()
        {
            _fundManager.BondTotalMarketValue.Should().Be(_fundManager.Stocks.Where(p => p.StockType == StockType.Bond).Sum(p => p.MarketValue));
        }

        [Test]
        public void Constructor_BondTotalNumber_Correct()
        {
            _fundManager.BondTotalNumber.Should().Be(_fundManager.Stocks.Where(p => p.StockType == StockType.Bond).Sum(p => p.Quantity));
        }

        [Test]
        public void Constructor_BondTotalStockWeight_Correct()
        {
            _fundManager.BondTotalStockWeight.Should().Be(_fundManager.Stocks.Where(p => p.StockType == StockType.Bond).Sum(p => p.StockWeight));
        }
        [Test]
        public void Constructor_AllTotalMarketValue_Correct()
        {
            _fundManager.AllTotalMarketValue.Should().Be(_fundManager.Stocks.Sum(p => p.MarketValue));
        }

        [Test]
        public void Constructor_AllTotalNumber_Correct()
        {
            _fundManager.AllTotalNumber.Should().Be(_fundManager.Stocks.Sum(p => p.Quantity));
        }

        [Test]
        public void Constructor_AllTotalStockWeight_Correct()
        {
            _fundManager.AllTotalStockWeight.Should().Be(_fundManager.Stocks.Sum(p => p.StockWeight));
        }

        [Test]
        [TestCase(StockType.Bond, 10, 10)]
        public void AddedStockTest(StockType stockType, decimal price, long quantity)
        {
            _fundManager.SelectedStockType = stockType;
            _fundManager.Price = price;
            _fundManager.Quantity = quantity;
            _fundManager.AddStockCommand.Execute(null);
            var addedStock = _fundManager.Stocks[_fundManager.Stocks.Count - 1];
            addedStock.StockType.Should().Be(stockType);
            addedStock.Price.Should().Be(price);
            addedStock.Quantity.Should().Be(quantity);
            
        }
    }
}
