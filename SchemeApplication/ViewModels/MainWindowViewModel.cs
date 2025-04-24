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
using SchemeApplication.Infrastructure.BlockLogics.Base;
using SchemeApplication.Infrastructure.BlockLogics;
using SchemeApplication.Services;

namespace SchemeApplication.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        #region Fields

        private ConnectorViewModel? _inputConnector;
        private ConnectorViewModel? _outputConnector;

        #endregion

        #region Properties

        public ObservableCollection<ListBlock> ListBlocks { get; }

        public CompositeCollection CanvasObjects { get; }

        public List<InputBlockFigureViewModel> InputBlocks { get; }
        public List<BlockFigureViewModel> OutputBlocks { get; }

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

        #region Create Block Command

        public ICommand CreateBlockCommand { get; }

        private void OnCreateBlockCommandExecuted(object parameter)
        {
            Point point = (Point)parameter;
            Block blockConfig = TestData.BlockConfigs[_selectedListBlock.IndexOfBlockConfig];
            BlockFigureViewModel blockFigureViewModel = null;
            if (blockConfig.Type == BlockType.Input)
            {
                blockFigureViewModel = new InputBlockFigureViewModel(blockConfig.InputsCount,
                    blockConfig.OutputsCount, GenerateBlockLogic(blockConfig.Type) as InputBlockLogic);
                blockFigureViewModel.Name = "Input " + InputBlocks.Count;
            }
            else
            {
                blockFigureViewModel = new BlockFigureViewModel(blockConfig.InputsCount,
                    blockConfig.OutputsCount, GenerateBlockLogic(blockConfig.Type));
                if(blockConfig.Type == BlockType.Output)
                {
                    blockFigureViewModel.Name = "Output " + OutputBlocks.Count;
                }
                else
                {
                    blockFigureViewModel.Name = blockConfig.Name;
                }
            }
            blockFigureViewModel.Position = point;
            blockFigureViewModel.ImagePath = blockConfig.Image;
            blockFigureViewModel.OnDestroy += HandleDeletingFigure;

            if (blockConfig.Type == BlockType.Input) InputBlocks.Add(blockFigureViewModel as InputBlockFigureViewModel);
            else if (blockConfig.Type == BlockType.Output) OutputBlocks.Add(blockFigureViewModel);

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
            _selectedFigure?.Destroy();
            SelectedFigure = null;
        }
        private bool CanDeleteBlockCommandExecuted(object parameter)
        {
            return _selectedFigure != null;
        }

        #endregion

        #region Set Input Connector

        public ICommand SetInputConnectorCommand { get; }

        private void OnSetInputConnectorCommandExecute(object parameter)
        {
            if (parameter is not ConnectorViewModel connector) throw new ArgumentException();

            _inputConnector = connector;
            TryConnectBlocks();
        }

        private bool CanSetInputConnectorCommandExecuted(object parameter)
        {
            return CanSetConnector(_outputConnector, parameter);
        }

        #endregion

        #region Set Output Connector

        public ICommand SetOutputConnectorCommand { get; }

        private void OnSetOutputConnectorCommandExecute(object parameter)
        {
            if (parameter is not ConnectorViewModel connector) throw new ArgumentException();

            _outputConnector = connector;
            TryConnectBlocks();
        }

        private bool CanSetOutputConnectorCommandExecuted(object parameter)
        {
            return CanSetConnector(_inputConnector, parameter);
        }


        #endregion

        #region Open Simulating Window

        public ICommand OpenSimulatingWindowCommand { get; }

        private void OnOpenSimulatingWindowCommandExecuted(object parameter)
        {
            SchemeSimulatingService.StartSimulateStatic(InputBlocks, OutputBlocks);
        }
        
        private bool CanOpenSimulatingWindowCommandExecute(object parameter)
        {
            return true;
        }

        #endregion

        #endregion

        #region Contructors

        public MainWindowViewModel()
        {
            ListBlocks = new ObservableCollection<ListBlock>(TestData.ListBlocks);
            CanvasObjects = new CompositeCollection();
            InputBlocks = new List<InputBlockFigureViewModel>();
            OutputBlocks = new List<BlockFigureViewModel>();

            CreateBlockCommand = new LambdaCommand(OnCreateBlockCommandExecuted, CanCreateBlockCommandExecuted);
            DeleteFigureCommand = new LambdaCommand(OnDeleteFigureCommandExecuted, CanDeleteBlockCommandExecuted);
            SetInputConnectorCommand = new LambdaCommand(OnSetInputConnectorCommandExecute, CanSetInputConnectorCommandExecuted);
            SetOutputConnectorCommand = new LambdaCommand(OnSetOutputConnectorCommandExecute, CanSetOutputConnectorCommandExecuted);
            OpenSimulatingWindowCommand = new LambdaCommand(OnOpenSimulatingWindowCommandExecuted, CanOpenSimulatingWindowCommandExecute);
        }

        #endregion

        #region Private Methods

        private BlockLogic GenerateBlockLogic(BlockType type)
        {
            switch (type)
            {
                case BlockType.And: return new AndBlockLogic();
                case BlockType.Or: return new OrBlockLogic();
                case BlockType.Not: return new NotBlockLogic();
                case BlockType.Split: return new SplitterBlockLogic();
                case BlockType.Output: return new SplitterBlockLogic();
                case BlockType.Input: return new InputBlockLogic();
                default: throw new ArgumentException();
            }
        }

        private bool CanSetConnector(ConnectorViewModel? from, object toParameter)
        {
            if (toParameter == null) return false;
            if (toParameter is not ConnectorViewModel connector) throw new ArgumentException();
            if (connector.Connection is not null) return false;

            return from == null ? true : from.SourceBlock != connector.SourceBlock;
        }
        private void TryConnectBlocks()
        {
            if(_inputConnector != null && _outputConnector != null)
            {
                ConnectionFigureViewModel connection = new ConnectionFigureViewModel()
                {
                    InputConnector = _inputConnector,
                    OutputConnector = _outputConnector
                };
                connection.OnDestroy += HandleDeletingFigure;

                _inputConnector.Connection = connection;
                _outputConnector.Connection = connection;
                _inputConnector = _outputConnector = null;

                CanvasObjects.Add(connection);
            }
        }

        private void HandleDeletingFigure(FigureBaseViewModel figureBaseViewModel)
        {
            CanvasObjects.Remove(figureBaseViewModel);
        }

        #endregion
    }
}
