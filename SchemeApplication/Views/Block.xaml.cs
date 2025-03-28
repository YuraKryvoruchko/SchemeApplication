using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchemeApplication.Views
{
    /// <summary>
    /// Interaction logic for Block.xaml
    /// </summary>
    public partial class Block : UserControl
    {
        #region LeftClickCommand

        public static readonly DependencyProperty LeftClickCommandProperty =
            DependencyProperty.Register("LeftClick", typeof(ICommand), typeof(Block), new PropertyMetadata(null));

        public ICommand LeftClick
        {
            get { return (ICommand)GetValue(LeftClickCommandProperty); }
            set { SetValue(LeftClickCommandProperty, value); }
        }

        #endregion

        #region LeftClickParameter

        public static readonly DependencyProperty LeftClickParameterProperty =
            DependencyProperty.Register("LeftClickParameter", typeof(ICommand), typeof(Block), new PropertyMetadata(null));

        public object LeftClickParameter
        {
            get { return (object)GetValue(LeftClickParameterProperty); }
            set { SetValue(LeftClickParameterProperty, value); }
        }

        #endregion

        public Block()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += OnMouseLeftButtonDown;
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ExecuteCommandWithParameter(LeftClickCommandProperty, LeftClickParameterProperty);
        }

        private void ExecuteCommandWithParameter(DependencyProperty commandProperty, DependencyProperty parameterProperty)
        {
            ICommand command = (ICommand)GetValue(commandProperty);
            object parameter = GetValue(parameterProperty);
            if (command != null && command.CanExecute(parameter))
            {
                command.Execute(parameter);
            }
        }
    }
}
