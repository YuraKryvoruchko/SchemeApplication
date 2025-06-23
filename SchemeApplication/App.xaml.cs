using System.Windows;
using SchemeApplication.Services;
using SchemeApplication.Services.Interfaces;
using SchemeApplication.ViewModels;

namespace SchemeApplication
{
    /// <summary>
    /// Створення головного меню та логіка для впровадження залежностей у viewmodel 
    /// головного меню на запуску програми.
    /// </summary>
    public partial class App : Application
    {
        private ISchemeSimulatingService _schemeSimulatingService;
        private IHelpWindowService _helpWindowService;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _schemeSimulatingService = new SchemeSimulatingService();
            _helpWindowService = new HelpWindowService();

            MainWindow = new MainWindow();
            MainWindow.DataContext = new MainWindowViewModel(_schemeSimulatingService, _helpWindowService);
            MainWindow.Show();
            MainWindow.Focus();
        }
    }
}
