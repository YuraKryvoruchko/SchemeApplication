using SchemeApplication.ViewModels.Base;
using System.Windows;

namespace SchemeApplication.ViewModels.CanvasFigures
{
    internal class ConnectionViewModel : ViewModel
    {
        #region Properties

        public required BlockFigureViewModel SourceBlock { get; set; }
        public int Number { get; set; }

        public ConnectionViewModel? ConnectedConnection { get; set; }

        #region Position

        private Point _position;

        public Point Position 
        { 
            get { return _position; } 
            set { Set(ref _position, value); }
        }

        #endregion

        #endregion
    }
}
