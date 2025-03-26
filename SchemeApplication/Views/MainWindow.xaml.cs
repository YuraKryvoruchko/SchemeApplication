using SchemeApplication.Services;
using SchemeApplication.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchemeApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BlockBuilderService.Singleton = new BlockBuilderService(this.Canvas);
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(DataContext is MainWindowViewModel viewModel && viewModel.CreateBlockCommand.CanExecute(null))
            {
                viewModel.CreateBlockCommand.Execute(e.GetPosition(Canvas));
            }
        }
    }
}