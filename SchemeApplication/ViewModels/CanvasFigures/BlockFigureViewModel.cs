using SchemeApplication.ViewModels.CanvasFigures.Base;
using SchemeApplication.Infrastructure.BlockLogics.Base;
using System.Windows;

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

        private List<ConnectionViewModel> _inputs;

        public List<ConnectionViewModel> Inputs
        {
            get { return _inputs; }
            set { Set(ref _inputs, value); }
        }

        #endregion

        #region Outputs

        private List<ConnectionViewModel> _outputs;

        public List<ConnectionViewModel> Outputs
        {
            get { return _outputs; }
            set { Set(ref _outputs, value); }
        }

        #endregion

        #region Selected Connection 

        private ConnectionViewModel? _selectedConnection;

        public ConnectionViewModel? SelectedConnection
        {
            get { return _selectedConnection; }
            set 
            { 
                Set(ref _selectedConnection, value); 
                if(value != null)
                {
                    OnSelectedInput?.Invoke(value);
                }
            }
        }

        #endregion

        #endregion

        #region Events

        public event Action<ConnectionViewModel> OnSelectedInput;

        #endregion

        public BlockFigureViewModel(int inputCount, int outputCount, BlockLogic blockLogic = null)
        {
            Inputs = new List<ConnectionViewModel>();
            for(int i = 0; i < inputCount; i++)
            {
                Inputs.Add(new ConnectionViewModel() { SourceBlock = this, Number = i });
            }

            Outputs = new List<ConnectionViewModel>();
            for (int i = 0; i < outputCount; i++)
            {
                Outputs.Add(new ConnectionViewModel() { SourceBlock = this, Number = i });
            }
            _blockLogic = blockLogic;
            this.OnChangePosition += HandleBlockMove;
        }
        ~BlockFigureViewModel()
        {
            this.OnChangePosition -= HandleBlockMove;
        }

        public void ConnectBlock(BlockFigureViewModel block, int number)
        {
            throw new NotImplementedException();
        }
        public BlockFigureViewModel DisconnectBlock(int number)
        {
            throw new NotImplementedException();
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
