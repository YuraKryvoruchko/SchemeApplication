using SchemeApplication.Services;
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
            if(sender is Canvas canvas)
            {
                Point point = e.GetPosition(canvas);
                Views.Block block = new Views.Block()
                {
                    Width = 120,
                    Height = 70
                };
                Canvas.SetLeft(block, point.X);
                Canvas.SetTop(block, point.Y);
                canvas.Children.Add(block);
            }
        }
    }
}