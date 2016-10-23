using FundManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManager.Shared
{
    public interface IStockCreationInformation
    {
        decimal Price
        {
            get;
        }

        long Quantity
        {
            get;
        }

        StockType StockType
        {
            get;
        }

        int StockId
        {
            get;
            set;
        }

        IStockCreationInformation GetStockCreationInformation(StockType stockType, decimal price, long quantity);
    }
}
