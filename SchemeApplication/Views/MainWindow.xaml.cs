using SchemeApplication.ViewModels;
using SchemeApplication.ViewModels.CanvasFigures;
using SchemeApplication.ViewModels.CanvasFigures.Base;
using SchemeApplication.Views.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SchemeApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point _lastMousePosition;
        private bool _canvasIsMoved = false;

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
            else
            {
                _lastMousePosition = e.GetPosition(this);
                _canvasIsMoved = true;
                ItemsCanvas.Canvas.CaptureMouse();
            }
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_canvasIsMoved)
            {
                Canvas canvas = ItemsCanvas.Canvas;

                Point currentPosition = e.GetPosition(this);
                Vector delta = currentPosition - _lastMousePosition;
                _lastMousePosition = currentPosition;

                foreach (var element in canvas.Children)
                {
                    DraggableContentControl contentControl = element as DraggableContentControl;
                    if (contentControl.IsDraggable)
                    {
                        contentControl.Position += delta;
                    }
                }
            }
        }
        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _canvasIsMoved = false;
            ItemsCanvas.Canvas.ReleaseMouseCapture();
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