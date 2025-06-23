using SchemeApplication.ViewModels;
using SchemeApplication.ViewModels.CanvasFigures;
using SchemeApplication.ViewModels.CanvasFigures.Base;
using SchemeApplication.ViewModels.ListBlocks;
using SchemeApplication.Views.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SchemeApplication
{
    /// <summary>
    /// Внутрішня логіка взаємодії з MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Closed += (obj, args) => Application.Current.Shutdown();
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is MainWindowViewModel viewModel)
            {
                if (viewModel.CreateBlockCommand.CanExecute(null))
                {
                    viewModel.CreateBlockCommand.Execute(e.GetPosition(sender as Canvas));
                }
                else
                {
                    viewModel.SelectedFigure = null;
                }
            }
        }

        private void Ellipse_Loaded(object sender, EventArgs e)
        {
            FrameworkElement ellipse = (FrameworkElement)sender;
            ConnectorViewModel connection = ellipse.DataContext as ConnectorViewModel;
            Point point = ellipse.TranslatePoint(new Point(ellipse.Width / 2, ellipse.Height / 2), ItemsCanvas.Canvas);
            connection.Position = point;
        }

        private void DraggableContentControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is MainWindowViewModel viewModel && sender is FrameworkElement element)
            {
                viewModel.SelectedFigure = (FigureBaseViewModel)element.DataContext;
                e.Handled = true;
            }
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (DataContext is MainWindowViewModel viewModel)
            {
                if(e.NewValue is ListBlockViewModel listBlock)
                {
                    viewModel.SelectedListBlock = listBlock;
                }
                else
                {
                    viewModel.SelectedListBlock = null;
                }
            }
        }
    }
}