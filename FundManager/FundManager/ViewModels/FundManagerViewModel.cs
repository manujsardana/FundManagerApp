using FundManager.Infrastructure;
using FundManager.Shared;
using FundManager.Shared.Models;
using FundManager.Shared.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace FundManager.ViewModels
{
    public class FundManagerViewModel : Notifier
    {
        private readonly IStockService _stockService;
        private readonly IStockCreationInformation _stockCreationInfo;
        private StockType _selectedStockType;
        private long _quantity;
        private decimal _price;
        private ObservableCollection<Stock> _stocks;
        private long _equityTotalNumber;
        private decimal _equityTotalStockWeight;
        private decimal _equityTotalMarketValue;
        private long _bondTotalNumber;
        private decimal _bondTotalStockWeight;
        private decimal _bondTotalMarketValue;
        private long _allTotalNumber;
        private decimal _allTotalStockWeight;
        private decimal _allTotalMarketValue;
        public FundManagerViewModel(IStockService stockService, IStockCreationInformation stockCreationInformation)
        {
            _stockService = stockService;
            _stockCreationInfo = stockCreationInformation;
            AddStockCommand = new DelegateCommand(AddStock, CanAddStock);
            LoadStocks();
        }

        public DelegateCommand AddStockCommand { get; set; }

        public StockType SelectedStockType
        {
            get { return _selectedStockType; }
            set
            {
                if (_selectedStockType != value)
                {
                    _selectedStockType = value;
                    //This we are doing because we want to disable the Add Stock button on change of Type and then reset the values also.
                    Price = 0;
                    Quantity = 0;
                    NotifyPropertyChanged();
                }
            }
        }
        public long Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                AddStockCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged();
            }
        }
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                AddStockCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged();
            }
        }
        public long EquityTotalNumber
        {
            get { return _equityTotalNumber; }
            set
            {
                _equityTotalNumber = value;
                NotifyPropertyChanged();
            }
        }
        public decimal EquityTotalStockWeight
        {
            get { return _equityTotalStockWeight; }
            set
            {
                _equityTotalStockWeight = value;
                NotifyPropertyChanged();
            }
        }
        public decimal EquityTotalMarketValue
        {
            get { return _equityTotalMarketValue; }
            set
            {
                _equityTotalMarketValue = value;
                NotifyPropertyChanged();
            }
        }
        public long BondTotalNumber
        {
            get { return _bondTotalNumber; }
            set
            {
                _bondTotalNumber = value;
                NotifyPropertyChanged();
            }
        }
        public decimal BondTotalStockWeight
        {
            get { return _bondTotalStockWeight; }
            set
            {
                _bondTotalStockWeight = value;
                NotifyPropertyChanged();
            }
        }
        public decimal BondTotalMarketValue
        {
            get { return _bondTotalMarketValue; }
            set
            {
                _bondTotalMarketValue = value;
                NotifyPropertyChanged();
            }
        }
        public long AllTotalNumber
        {
            get { return _allTotalNumber; }
            set
            {
                _allTotalNumber = value;
                NotifyPropertyChanged();
            }
        }
        public decimal AllTotalStockWeight
        {
            get { return _allTotalStockWeight; }
            set
            {
                _allTotalStockWeight = value;
                NotifyPropertyChanged();
            }
        }
        public decimal AllTotalMarketValue
        {
            get { return _allTotalMarketValue; }
            set
            {
                _allTotalMarketValue = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<Stock> Stocks
        {
            get { return _stocks; }
            set
            {
                _stocks = value;
                NotifyPropertyChanged();
            }
        }
        private void AddStock(object obj)
        {
            Stocks.Add(_stockService.AddStock(_stockCreationInfo.GetStockCreationInformation(SelectedStockType, Price, Quantity)));
            UpdateStockWeights();
        }

        private void LoadStocks()
        {
            Stocks = new ObservableCollection<Stock>(_stockService.GetStocks());
            UpdateStockWeights();
        }

        private void UpdateStockWeights()
        {
            var totalMarketValue = Stocks.Sum(p => p.MarketValue);
            foreach (var stock in Stocks)
            {
                stock.UpdateStockWeight(totalMarketValue);
            }

            EquityTotalMarketValue = Stocks.Where(p => p.StockType == StockType.Equity).Sum(p => p.MarketValue);
            BondTotalMarketValue = Stocks.Where(p => p.StockType == StockType.Bond).Sum(p => p.MarketValue);
            AllTotalMarketValue = totalMarketValue;

            EquityTotalStockWeight = Stocks.Where(p => p.StockType == StockType.Equity).Sum(p => p.StockWeight);
            BondTotalStockWeight = Stocks.Where(p => p.StockType == StockType.Bond).Sum(p => p.StockWeight);
            AllTotalStockWeight = Stocks.Sum(p => p.StockWeight);

            EquityTotalNumber = Stocks.Where(p => p.StockType == StockType.Equity).Sum(p => p.Quantity);
            BondTotalNumber = Stocks.Where(p => p.StockType == StockType.Bond).Sum(p => p.Quantity);
            AllTotalNumber = Stocks.Sum(p => p.Quantity);
        }

        public bool CanAddStock(object obj)
        {
            return Price > 0 && Quantity != 0;
        }
    }
}
