using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FundManager.Infrastructure;

namespace FundManager.Shared.Models
{
    public abstract class Stock : Notifier
    {
        protected readonly IStockCreationInformation _stockCreationInfo;
        private readonly decimal _marketValue;
        private decimal _stockWeight;

        public Stock(IStockCreationInformation  stockCreationInformation)
        {
            _stockCreationInfo = stockCreationInformation;
            _marketValue = _stockCreationInfo.Price * _stockCreationInfo.Quantity;
        }

        public int StockId
        {
            get { return _stockCreationInfo.StockId; }
        }

        public StockType StockType
        {
            get { return _stockCreationInfo.StockType; }
        }

        public decimal Price
        {
            get { return _stockCreationInfo.Price; }
        }

        public long Quantity
        {
            get { return _stockCreationInfo.Quantity; }
        }

        public decimal MarketValue
        {
            get { return _marketValue; }
        }

        public abstract decimal TransactionCost { get; }

        public decimal StockWeight
        {
            get
            {
                return _stockWeight;
            }
            set
            {
                _stockWeight = value;
                NotifyPropertyChanged();
            }
        }

        public abstract StockName StockName { get; }
        public string Name
        {
            get { return _stockCreationInfo.StockType.ToString() + _stockCreationInfo.StockId; }
        }

        public void UpdateStockWeight(decimal totalMarketValue)
        {
            StockWeight = totalMarketValue == 0 ? 0 : _marketValue / totalMarketValue;
        }
    }
}
