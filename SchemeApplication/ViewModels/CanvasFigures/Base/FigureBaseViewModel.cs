using SchemeApplication.ViewModels.Base;
using System.Windows;

namespace SchemeApplication.ViewModels.CanvasFigures.Base
{
    internal class FigureBaseViewModel : ViewModel
    {
        #region Properties

        #region Is Draggable

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
            set
            {
                Point oldValue = _position;
                Set(ref _position, value);
                if(oldValue != _position)
                {
                    OnChangePosition?.Invoke(oldValue, value);
                }
            }
        }

        #endregion

        #region Is Selected

        private bool _isSelected = false;

        public bool IsSelected
        {
            get { return _isSelected; }
            set { Set(ref _isSelected, value); }
        }

        #endregion

        #endregion

        #region Events

        public event Action<FigureBaseViewModel> OnDestroy;
        public event Action<Point, Point> OnChangePosition;

        #endregion

        #region Public Methods

        public virtual void Destroy() { }

        #endregion

        #region Protected Methods

        protected void RaiseOnDestroyEvent()
        {
            OnDestroy?.Invoke(this);
        }

        #endregion
    }
}
