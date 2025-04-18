using SchemeApplication.ViewModels.CanvasFigures.Base;
using SchemeApplication.Infrastructure.BlockLogics.Base;
using System.Windows;
using System.Windows.Input;
using SchemeApplication.Infrastructure.Commands;
using System.Diagnostics;

namespace SchemeApplication.ViewModels.CanvasFigures
{
    internal class BlockFigureViewModel : FigureBaseViewModel
    {
        #region Fields

        private readonly BlockLogic _blockLogic;

        #endregion

        #region Properties

        #region Name

        private string? _name;

        public string? Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        #endregion

        #region ImagePath

        private string? _imagePath;

        public string? ImagePath
        {
            get { return _imagePath; }
            set { Set(ref _imagePath, value); }
        }

        #endregion

        #region Inputs

        private List<ConnectorViewModel> _inputs;

        public List<ConnectorViewModel> Inputs
        {
            get { return _inputs; }
            set { Set(ref _inputs, value); }
        }

        #endregion

        #region Outputs

        private List<ConnectorViewModel> _outputs;

        public List<ConnectorViewModel> Outputs
        {
            get { return _outputs; }
            set { Set(ref _outputs, value); }
        }

        #endregion

        #region Selected Connector 

        private ConnectorViewModel? _selectedConnector;

        public ConnectorViewModel? SelectedConnector
        {
            get { return _selectedConnector; }
            set 
            { 
                Set(ref _selectedConnector, value); 
                if(value != null)
                {
                    OnSelectedInput?.Invoke(value);
                }
            }
        }

        #endregion

        #region Attached Connections

        private List<ConnectionFigureViewModel> _attachedConnections;

        public List <ConnectionFigureViewModel> AttachedConnections
        {
            get { return _attachedConnections; }
        }

        #endregion

        #endregion

        #region Events

        public event Action<ConnectorViewModel> OnSelectedInput;

        #endregion

        #region Commands

        #region Select Connector Command

        public ICommand SelectConnectorCommand { get; }

        private void OnSelectConnectorCommandExecuted(object parameter)
        {
            Trace.WriteLine(1);
            SelectedConnector  = (ConnectorViewModel)parameter;
        }
        private bool CanSelectConnectorCommandExecute(object parameter)
        {
            Trace.WriteLine(2);
            return true;
        }

        #endregion

        #endregion

        public BlockFigureViewModel(int inputCount, int outputCount, BlockLogic blockLogic = null)
        {
            SelectConnectorCommand = new LambdaCommand(OnSelectConnectorCommandExecuted, CanSelectConnectorCommandExecute);

            _attachedConnections = new List<ConnectionFigureViewModel>();
            Inputs = new List<ConnectorViewModel>();
            for(int i = 0; i < inputCount; i++)
            {
                Inputs.Add(new ConnectorViewModel() { SourceBlock = this, Number = i });
            }

            Outputs = new List<ConnectorViewModel>();
            for (int i = 0; i < outputCount; i++)
            {
                Outputs.Add(new ConnectorViewModel() { SourceBlock = this, Number = i });
            }
            _blockLogic = blockLogic;
            this.OnChangePosition += HandleBlockMove;
        }
        ~BlockFigureViewModel()
        {
            this.OnChangePosition -= HandleBlockMove;
        }

        public void ConnectToBlock(BlockFigureViewModel block, int number)
        {
            throw new NotImplementedException();
        }
        public BlockFigureViewModel DisconnectBlock(int number)
        {
            throw new NotImplementedException();
        }
        public override void Destroy()
        {
            foreach(var attachedConnection in _attachedConnections)
            {
                attachedConnection.Destroy();
            }
            RaiseOnDestroyEvent();
        }
        public bool Execute(int number)
        {
            return true;
        }

        private void HandleBlockMove(Point oldValue, Point newValue)
        {
            Vector vector = newValue - oldValue;

            foreach(var connection in _inputs)
            {
                connection.Position += vector;
            }
            foreach (var connection in _outputs)
            {
                connection.Position += vector;
            }
        }
    }
}
