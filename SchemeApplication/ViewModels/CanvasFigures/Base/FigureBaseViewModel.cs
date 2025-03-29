using SchemeApplication.ViewModels.Base;
using System.Windows;

namespace SchemeApplication.ViewModels.CanvasFigures.Base
{
    internal class FigureBaseViewModel : ViewModel
    {
        #region IsDraggable

        private bool _isDraggable = true;

        public bool IsDraggable
        {
            get { return _isDraggable; }
            set { Set(ref _isDraggable, value); }
        }

        #endregion

        #region Position

        private Point _position;

        public Point Position
        {
            get => _position;
            set => Set(ref _position, value);
        }

        #endregion
    }
}
