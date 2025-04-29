using SchemeApplication.Models;
using SchemeApplication.ViewModels;
using SchemeApplication.ViewModels.CanvasFigures;
using SchemeApplication.ViewModels.CanvasFigures.Base;
using SchemeApplication.Views.Controls;
using System.Diagnostics;
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
            Trace.WriteLine("Canvas_MouseLeftButtonDown");
            if (DataContext is MainWindowViewModel viewModel && viewModel.CreateBlockCommand.CanExecute(null))
            {
                viewModel.CreateBlockCommand.Execute(e.GetPosition(sender as Canvas));
            }
        }

        private void Ellipse_Loaded(object sender, EventArgs e)
        {
            FrameworkElement ellipse = (FrameworkElement)sender;
            ConnectorViewModel connection = ellipse.DataContext as ConnectorViewModel;
            Point point = ellipse.TranslatePoint(new Point(0, 0), ItemsCanvas.Canvas);
            connection.Position = point;
        }

        private void DraggableContentControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is MainWindowViewModel viewModel && sender is FrameworkElement element)
            {
                Trace.WriteLine($"From {typeof(MainWindow)}: Selected figure: {element}");
                viewModel.SelectedFigure = (FigureBaseViewModel)element.DataContext;
            }
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if(DataContext is MainWindowViewModel viewModel)
            {
                if(e.NewValue is ListBlock listBlock)
                {
                    viewModel.SelectedListBlock = listBlock;
                    var a = ListTreeView.SelectedItem;
                    var b = ListTreeView.SelectedValue;
                }
                else
                {
                    viewModel.SelectedListBlock = null;
                }
            }
        }
    }
}