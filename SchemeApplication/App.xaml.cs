using System.Windows;
using SchemeApplication.Services;
using SchemeApplication.Services.Interfaces;
using SchemeApplication.ViewModels;

namespace SchemeApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ISchemeSimulatingService _schemeSimulatingService;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _schemeSimulatingService = new SchemeSimulatingService();

            MainWindow = new MainWindow();
            MainWindow.DataContext = new MainWindowViewModel(_schemeSimulatingService);
            MainWindow.Show();
            MainWindow.Focus();
        }
    }
}
