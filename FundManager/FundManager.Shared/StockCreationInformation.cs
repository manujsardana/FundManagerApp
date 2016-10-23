using FundManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManager.Shared
{
    public class StockCreationInformation  : IStockCreationInformation
    {
        public StockCreationInformation()
        {
            
        }

        public IStockCreationInformation GetStockCreationInformation(StockType stockType, decimal price, long quantity)
        {
            return new StockCreationInformation { Price = price, Quantity = quantity, StockType = stockType };
        }

        public decimal Price
        {
            get;
            set;
        }

        public long Quantity
        {
            get;
            set;
        }

        public StockType StockType
        {
            get;
            set;
        }

        public int StockId
        {
            get;
            set;
        }
    }
}
