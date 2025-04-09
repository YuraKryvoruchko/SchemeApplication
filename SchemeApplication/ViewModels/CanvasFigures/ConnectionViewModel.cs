using SchemeApplication.ViewModels.Base;
using System.Windows;

namespace SchemeApplication.ViewModels.CanvasFigures
{
    internal class ConnectionViewModel : ViewModel
    {
        #region Properties

        public BlockFigureViewModel SourceBlock { get; set; }
        public BlockFigureViewModel Block { get; set; }
        public int Number { get; set; }

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
