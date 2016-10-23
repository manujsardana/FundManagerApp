using FundManager.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundManager.Shared.Models
{
    public class Equity : Stock
    {
        private const decimal TRANSACTION_COST_MULTIPLIER = 0.005m;
        private readonly decimal _transactionCost;
        private readonly IStockCreationInformation _stockCreationInfo;
        private readonly IConfigurationService _configService;
        public Equity(IStockCreationInformation stockCreationInfo, IConfigurationService configService) : base(stockCreationInfo)
        {
            _configService = configService;
            var transactionCostMultiplier = GetTransactionCostMultiplierFromConfig();
            _transactionCost = MarketValue * transactionCostMultiplier;
        }
        public override decimal TransactionCost
        {
            get
            {
                return _transactionCost;
            }
        }

        public override StockName StockName
        {
            get
            {
                return new StockName
                {
                    Name = Name,
                    IsNameHighlighted = MarketValue < 0 || TransactionCost > 200000
                };
            }
        }

        private decimal GetTransactionCostMultiplierFromConfig()
        {
            var multiplierString = _configService.GetValueFromConfig("transactionCostMultiplierForEquity");

            if (string.IsNullOrEmpty(multiplierString))
                return TRANSACTION_COST_MULTIPLIER;
            else
            {
                decimal multiplier;
                if (decimal.TryParse(multiplierString, out multiplier))
                {
                    return multiplier;
                }
                else
                {
                    return TRANSACTION_COST_MULTIPLIER;
                }
            }
        }
    }
}
