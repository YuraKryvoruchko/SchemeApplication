using SchemeApplication.ViewModels;
using SchemeApplication.ViewModels.CanvasFigures;
using SchemeApplication.ViewModels.CanvasFigures.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(DataContext is MainWindowViewModel viewModel && viewModel.CreateBlockCommand.CanExecute(null))
            {
                viewModel.CreateBlockCommand.Execute(e.GetPosition(sender as Canvas));
            }     
        }

        private void Ellipse_Loaded(object sender, EventArgs e)
        {
            Ellipse ellipse = (Ellipse)sender;
            ConnectionViewModel connection = ellipse.DataContext as ConnectionViewModel;
            Point point = ellipse.TranslatePoint(new Point(0, 0), ItemsCanvas.Canvas);
            connection.Position = point;
        }

        private void DraggableContentControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is MainWindowViewModel viewModel && sender is FrameworkElement element)
            {
                viewModel.SelectedFigure = (FigureBaseViewModel)element.DataContext;
            }
        }
    }
}