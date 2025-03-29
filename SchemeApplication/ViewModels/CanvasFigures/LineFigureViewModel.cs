using SchemeApplication.ViewModels.CanvasFigures.Base;
using System.Windows;

namespace SchemeApplication.ViewModels.CanvasFigures
{
    internal class LineFigureViewModel : FigureBaseViewModel
    {
        #region Properties 

        #region InputPoint

        private Point _inputPoint;

        public Point InputPoint
        {
            get { return _inputPoint; }
            set { Set(ref _inputPoint, value); }
        }

        #endregion

        #region OutputPoint

        private Point _outputPoint;

        public Point OutputPoint
        {
            get { return _outputPoint; }
            set { Set(ref _outputPoint, value); }
        }

        #endregion

        #endregion

        public LineFigureViewModel()
        {
            this.IsDraggable = false;
        }
    }
}
