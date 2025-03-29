using SchemeApplication.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(DataContext is MainWindowViewModel viewModel && viewModel.CreateBlockCommand.CanExecute(null))
            {
                viewModel.CreateBlockCommand.Execute(e.GetPosition(sender as Canvas));
            }
        }
    }
}