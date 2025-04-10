using SchemeApplication.ViewModels.Base;
using System.Collections.ObjectModel;
using SchemeApplication.Models;
using System.Windows.Input;
using System.Windows;
using SchemeApplication.Infrastructure.Commands;
using SchemeApplication.Data;
using System.Windows.Data;
using SchemeApplication.ViewModels.CanvasFigures;
using SchemeApplication.ViewModels.CanvasFigures.Base;

namespace SchemeApplication.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        #region Fields

        private ConnectionViewModel? _firstConnection;
        private ConnectionViewModel? _secondConnection;

        #endregion

        #region Properties

        public ObservableCollection<ListBlock> ListBlocks { get; }
        public CompositeCollection CanvasObjects { get; }

        #region Selected List Block

        private ListBlock? _selectedListBlock;

        public ListBlock? SelectedListBlock
        {
            get => _selectedListBlock;
            set => Set(ref _selectedListBlock, value);
        }

        #endregion

        #region Selected Figure

        private FigureBaseViewModel? _selectedFigure;        

        public FigureBaseViewModel? SelectedFigure
        {
            get { return _selectedFigure; }
            set { Set(ref _selectedFigure, value); }
        }


        #endregion

        #region Inputs

        private int _inputs;

        public int Inputs
        {
            get { return _inputs; }
            set { Set(ref _inputs, value); }
        }

        #endregion

        #region Outputs

        private int _outputs;

        public int Outputs
        {
            get { return _outputs; }
            set { Set(ref _outputs, value); }
        }

        #endregion

        #endregion

        #region Commands

        #region CreateBlockCommand

        public ICommand CreateBlockCommand { get; }

        private void OnCreateBlockCommandExecuted(object parameter)
        {
            Point point = (Point)parameter;
            Block blockConfig = TestData.BlockConfigs[_selectedListBlock.IndexOfBlockConfig];
            BlockFigureViewModel blockFigureViewModel = new BlockFigureViewModel(blockConfig.InputsCount, blockConfig.OutputsCount)
            {
                Position = point,
                Name = blockConfig.Name,
                ImagePath = blockConfig.Image
            };
            blockFigureViewModel.OnSelectedInput += HandleConnectionSelection;
            CanvasObjects.Add(blockFigureViewModel);
            SelectedListBlock = null;
        }
        private bool CanCreateBlockCommandExecuted(object parameter) 
        {
            return _selectedListBlock != null;
        }

        #endregion

        #region Delete Figure Command

        public ICommand DeleteFigureCommand { get; }

        private void OnDeleteFigureCommandExecuted(object parameter)
        {
            CanvasObjects.Remove(_selectedFigure);
            _selectedFigure?.Destroy();
            SelectedFigure = null;
        }
        private bool CanDeleteBlockCommandExecuted(object parameter)
        {
            return _selectedFigure != null;
        }

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            ListBlocks = new ObservableCollection<ListBlock>(TestData.ListBlocks);
            CanvasObjects = new CompositeCollection();
            CreateBlockCommand = new LambdaCommand(OnCreateBlockCommandExecuted, CanCreateBlockCommandExecuted);
            DeleteFigureCommand = new LambdaCommand(OnDeleteFigureCommandExecuted, CanDeleteBlockCommandExecuted);
        }

        private void HandleConnectionSelection(ConnectionViewModel connection)
        {
            if (_firstConnection == null)
            {
                _firstConnection = connection;
            }
            else if (_secondConnection == null)
            {
                _secondConnection = connection;
                LineFigureViewModel lineFigureViewModel = new LineFigureViewModel()
                {
                    InputConnection = _firstConnection,
                    OutputConnection = _secondConnection
                };
                CanvasObjects.Add(lineFigureViewModel);

                _firstConnection.ConnectedConnection = _secondConnection;
                _secondConnection.ConnectedConnection = _firstConnection;

                _firstConnection = _secondConnection = null;
            }
        }
    }
}
