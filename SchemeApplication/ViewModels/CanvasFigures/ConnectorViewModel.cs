using SchemeApplication.ViewModels.Base;
using System.Windows;

namespace SchemeApplication.ViewModels.CanvasFigures
{
    internal class ConnectorViewModel : ViewModel
    {
        #region Properties

        public required BlockFigureViewModel SourceBlock { get; set; }
        public int Number { get; set; }

        public ConnectionFigureViewModel? Connection { get; set; }

        #region Position

        private Point _position;

        public Point Position 
        { 
            get { return _position; } 
            set { Set(ref _position, value); }
        }

        #endregion

        #endregion

        #region Public methods

        public void Free()
        {
            Connection = null;
        }
        public void FreeWithDestroyConnection()
        {
            Connection?.Destroy();
            Connection = null;
        }

        #endregion
    }
}
