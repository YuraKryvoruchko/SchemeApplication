using SchemeApplication.ViewModels.CanvasFigures.Base;
using System.Windows;

namespace SchemeApplication.ViewModels.CanvasFigures
{
    internal class BlockFigureViewModel : FigureBaseViewModel
    {
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

        #region InputCount

        private int _inputCount;

        public int InputCount
        {
            get { return _inputCount; }
            set { Set(ref _inputCount, value); }
        }

        #endregion

        #region OutputCount

        private int _outputCount;

        public int OutputCount
        {
            get { return _outputCount; }
            set { Set(ref _outputCount, value); }
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

        public BlockFigureViewModel()
        {
            Inputs = new List<ConnectionViewModel>()
            {
                new ConnectionViewModel() { SourceBlock = this, Number = 0 },
                new ConnectionViewModel() { SourceBlock = this, Number = 1 }
            };
            this.OnChangePosition += HandleBlockMove;
        }
        ~BlockFigureViewModel()
        {
            this.OnChangePosition -= HandleBlockMove;
        }

        public void ConnectBlock(BlockFigureViewModel block, int number)
        {
            Inputs[number].Block = block;
        }
        public BlockFigureViewModel DisconnectBlock(int number)
        {
            BlockFigureViewModel block = Inputs[number].Block;
            Inputs[number].Block = null;
            return block;
        }

        private void HandleBlockMove(Point oldValue, Point newValue)
        {
            Vector vector = newValue - oldValue;

            foreach(var connection in _inputs)
            {
                connection.Position = connection.Position + vector;
            }
        }
    }
}
