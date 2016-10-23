using FundManager.Shared;
using FundManager.Shared.Services;
using FundManager.ViewModels;
using FundManager.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FundManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IStockFactory stockFactory = new StockFactory();
            IConfigurationService configService = new ConfigurationService();
            FundManagerViewModel viewModel = new FundManagerViewModel(new StockService(stockFactory, configService), new StockCreationInformation());
            MainWindow stocksView = new MainWindow();
            stocksView.DataContext = viewModel;
            stocksView.Show();
        }
    }
}
