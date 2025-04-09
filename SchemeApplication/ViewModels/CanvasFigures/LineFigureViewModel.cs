using SchemeApplication.ViewModels.CanvasFigures.Base;

namespace SchemeApplication.ViewModels.CanvasFigures
{
    internal class LineFigureViewModel : FigureBaseViewModel
    {
        #region Properties 

        #region InputConnection

        private ConnectionViewModel? _inputConnection;

        public ConnectionViewModel? OutputConnection
        {
            get { return _inputConnection; }
            set { Set(ref _inputConnection, value); }
        }

        #endregion

        #region OutputConnection

        private ConnectionViewModel? _outputConnection;

        public ConnectionViewModel? InputConnection
        {
            get { return _outputConnection; }
            set { Set(ref _outputConnection, value); }
        }

        #endregion

        #endregion

        public LineFigureViewModel()
        {
            this.IsDraggable = false;
        }
    }
}
