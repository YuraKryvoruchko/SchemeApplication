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
using SchemeApplication.Services.Interfaces;
using SchemeApplication.ViewModels.ListBlocks;
using SchemeApplication.Services;

namespace SchemeApplication.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        #region Fields

        private ISchemeSimulatingService _schemeSimulatingService;
        private IHelpWindowService _helpWindowService;

        private ConnectorViewModel? _inputConnector;
        private ConnectorViewModel? _outputConnector;

        #endregion

        #region Properties

        public CompositeCollection CanvasObjects { get; }

        public List<InputBlockFigureViewModel> InputBlocks { get; }
        public List<BlockFigureViewModel> OutputBlocks { get; }

        public ObservableCollection<BlockCategoryViewModel> BlockCategories { get; }

        #region Selected List Block

        private ListBlockViewModel? _selectedListBlock;

        public ListBlockViewModel? SelectedListBlock
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
            set 
            {
                if(_selectedFigure != null) _selectedFigure.IsSelected = false;
                Set(ref _selectedFigure, value);
                if (_selectedFigure != null) _selectedFigure.IsSelected = true;
            }
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

        #region Is Active Modification

        private bool _isActiveModification = true;

        public bool IsActiveModification 
        { 
            get => _isActiveModification;
            set => Set(ref _isActiveModification, value); 
        }

        #endregion

        #region Zoom

        private float _zoom = 1;

        public float Zoom 
        { 
            get => _zoom; 
            set => Set(ref _zoom, value);
        }

        #endregion

        #endregion

        #region Commands

        #region Create Block Command

        public ICommand CreateBlockCommand { get; }

        private void OnCreateBlockCommandExecuted(object parameter)
        {
            Point point = (Point)parameter;
            Block blockConfig = ProjectData.BlockConfigs[_selectedListBlock.IndexOfBlockConfig];
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
            SelectedListBlock.IsSelected = false;
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

        #region Set Input Connector Command

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

        #region Set Output Connector Command

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

        #region Zoom In

        public ICommand ZoomInCommand { get; }

        private void OnZoomInCommandExecuted(object parameter)
        {
            Zoom += 0.1f;
        }

        private bool CanZoomInCommandExecute(object parameter)
        {
            return Zoom < 2f;
        }

        #endregion

        #region Zoom Out

        public ICommand ZoomOutCommand { get; }

        private void OnZoomOutCommandExecuted(object parameter)
        {
            Zoom -= 0.1f;
        }

        private bool CanZoomOutCommandExecute(object parameter)
        {
            return Zoom > 0.4f;
        }

        #endregion

        #region Start Simulate Command

        public ICommand StartSimulateCommand { get; }

        private void OnStartSimulateCommandExecuted(object parameter)
        {
            _schemeSimulatingService.StartSimulate(InputBlocks, OutputBlocks);
            _schemeSimulatingService.OnFinishSimulating += HandleFinishSimulating;
            IsActiveModification = false;
        }
        
        private bool CanStartSimulateCommandExecute(object parameter)
        {
            bool canSimulate = true;
            foreach(var output in OutputBlocks)
            {
                canSimulate = output.CanExecute();
                if (canSimulate == false) break;
            }

            return !_schemeSimulatingService.IsSimulating && canSimulate;
        }

        #endregion

        #region Switch Language

        public ICommand SwitchLanguageCommand { get; }

        private void OnSwitchLanguageCommandExecuted(object parameter)
        {
            if(parameter is not string cultureCode)
            {
                return;
            }

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cultureCode);

            ResourceDictionary dict = new ResourceDictionary();
            dict.Source = new Uri($"Resources/Languages/Language-{cultureCode}.xaml", UriKind.Relative);

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }

        #endregion

        #region Open Help Window

        public ICommand OpenHelpWindowCommand { get; }

        private void OnOpenHelpWindowCommandExecuted(object parameter)
        {
            _helpWindowService.OpenOrActivateHelpWindow();
        }

        #endregion

        #endregion

        #region Contructors

        public MainWindowViewModel(ISchemeSimulatingService schemeSimulatingService, IHelpWindowService helpWindowService)
        {
            _schemeSimulatingService = schemeSimulatingService;
            _helpWindowService = helpWindowService;

            BlockCategories = new ObservableCollection<BlockCategoryViewModel>();
            foreach (var category in ProjectData.BlockCategories)
            {
                BlockCategories.Add(new BlockCategoryViewModel(category));
            }

            CanvasObjects = new CompositeCollection();
            InputBlocks = new List<InputBlockFigureViewModel>();
            OutputBlocks = new List<BlockFigureViewModel>();

            CreateBlockCommand = new LambdaCommand(OnCreateBlockCommandExecuted, CanCreateBlockCommandExecuted);
            DeleteFigureCommand = new LambdaCommand(OnDeleteFigureCommandExecuted, CanDeleteBlockCommandExecuted);
            SetInputConnectorCommand = new LambdaCommand(OnSetInputConnectorCommandExecute, CanSetInputConnectorCommandExecuted);
            SetOutputConnectorCommand = new LambdaCommand(OnSetOutputConnectorCommandExecute, CanSetOutputConnectorCommandExecuted);
            StartSimulateCommand = new LambdaCommand(OnStartSimulateCommandExecuted, CanStartSimulateCommandExecute);
            ZoomInCommand = new LambdaCommand(OnZoomInCommandExecuted, CanZoomInCommandExecute);
            ZoomOutCommand = new LambdaCommand(OnZoomOutCommandExecuted, CanZoomOutCommandExecute);
            SwitchLanguageCommand = new LambdaCommand(OnSwitchLanguageCommandExecuted);
            OpenHelpWindowCommand = new LambdaCommand(OnOpenHelpWindowCommandExecuted);
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
            if (figureBaseViewModel is InputBlockFigureViewModel input)
            {
                InputBlocks.Remove(input);
            }
            else if (OutputBlocks.Contains(figureBaseViewModel))
            {
                OutputBlocks.Remove(figureBaseViewModel as BlockFigureViewModel);
            }
        }
        private void HandleFinishSimulating()
        {
            _schemeSimulatingService.OnFinishSimulating -= HandleFinishSimulating;
            IsActiveModification = true;
        }

        #endregion
    }
}
