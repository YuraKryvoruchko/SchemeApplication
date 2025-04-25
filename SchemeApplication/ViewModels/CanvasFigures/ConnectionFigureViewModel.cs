using SchemeApplication.ViewModels.CanvasFigures.Base;

namespace SchemeApplication.ViewModels.CanvasFigures
{
    internal class ConnectionFigureViewModel : FigureBaseViewModel
    {
        #region Properties 

        #region Input Connection

        private ConnectorViewModel? _outputConnector;

        public ConnectorViewModel? OutputConnector
        {
            get { return _outputConnector; }
            set { Set(ref _outputConnector, value); }
        }

        #endregion 

        #region Output Connection

        private ConnectorViewModel? _inputConnector;

        public ConnectorViewModel? InputConnector
        {
            get { return _inputConnector; }
            set { Set(ref _inputConnector, value); }
        }

        #endregion

        #endregion

        public ConnectionFigureViewModel()
        {
            this.IsDraggable = false;
        }

        #region Public Methods

        public override void Destroy()
        {
            if(_outputConnector != null) _outputConnector.Free();
            if (_inputConnector != null) _inputConnector.Free();

            OutputConnector = null;
            InputConnector = null;

            RaiseOnDestroyEvent();
        }

        #endregion
    }
}
