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

        #endregion

        #region Constructors and destructor

        public BlockFigureViewModel(int inputCount, int outputCount, BlockLogic blockLogic = null)
        {
            _inputs = new List<ConnectorViewModel>();
            for (int i = 0; i < inputCount; i++)
            {
                _inputs.Add(new ConnectorViewModel() { SourceBlock = this, Number = i });
            }
            Inputs = _inputs;

            _outputs = new List<ConnectorViewModel>();
            for (int i = 0; i < outputCount; i++)
            {
                _outputs.Add(new ConnectorViewModel() { SourceBlock = this, Number = i });
            }
            Outputs = _outputs;

            _blockLogic = blockLogic;
            this.OnChangePosition += HandleBlockMove;
        }
        ~BlockFigureViewModel()
        {
            this.OnChangePosition -= HandleBlockMove;
        }

        #endregion
        
        #region Public overrided methods

        public override void Destroy()
        {
            foreach (var input in _inputs) input.Connection?.Destroy();
            foreach (var output in _outputs) output.Connection?.Destroy();

            RaiseOnDestroyEvent();
        }

        #endregion

        #region Public methods

        public void ConnectToBlock(BlockFigureViewModel block, int number)
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

        #endregion

        #region Private methods

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

        #endregion
    }
}
