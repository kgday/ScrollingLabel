using ReactiveUI;

using ScrollingLabel.Dataservice;
using ScrollingLabel.ViewModels;
using ScrollingLabel.Views;

using Splat;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ScrollingLabel.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IOC _iOC;

        public App()
        {
            _iOC = new IOC();
            _iOC.RegisterDependencies();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = _iOC.GetService<MainWindow>();
            MainWindow = mainWindow;
            MainWindow.Show();
        }
    }
}
