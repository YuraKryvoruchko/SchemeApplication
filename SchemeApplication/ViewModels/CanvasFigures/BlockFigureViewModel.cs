using SchemeApplication.ViewModels.CanvasFigures.Base;
using SchemeApplication.Infrastructure.BlockLogics.Base;
using System.Windows;

namespace SchemeApplication.ViewModels.CanvasFigures
{
    /// <summary>
    /// Viewmodel для логічних блоків. Дає доступ до даних про блок та реалізує взаємодію з логічною операцією блока.
    /// </summary>
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

        public BlockFigureViewModel(int inputCount, int outputCount, BlockLogic blockLogic)
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
            _blockLogic.Block = this;
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
            foreach (var input in _inputs) input.FreeWithDestroyConnection();
            foreach (var output in _outputs) output.FreeWithDestroyConnection();

            RaiseOnDestroyEvent();
        }

        #endregion

        #region Public methods

        public bool Execute()
        {
            return _blockLogic.Execute();
        }
        public bool CanExecute()
        {
            return _blockLogic.CanExecute();
        }
        public BlockFigureViewModel? TryGetConnectedBlockOrNull(int outputNumber)
        {
            if (_inputs[outputNumber].Connection == null || _inputs[outputNumber].Connection.OutputConnector == null) 
                return null;
            else
                return _inputs[outputNumber].Connection.OutputConnector.SourceBlock; 
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
