using SchemeApplication.ViewModels.Base;
using System.Collections.ObjectModel;
using SchemeApplication.Models;
using System.Windows.Input;
using System.Windows;
using SchemeApplication.Infrastructure.Commands;
using SchemeApplication.Data;
using System.Windows.Data;
using SchemeApplication.ViewModels.CanvasFigures;

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

        #region Selected Block

        private BlockViewModel _selectedBlock;        

        public BlockViewModel SelectedBlock
        {
            get { return _selectedBlock; }
            set { Set(ref _selectedBlock, value); }
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
            BlockFigureViewModel blockFigureViewModel = new BlockFigureViewModel()
            {
                Position = point,
                Name = TestData.BlockConfigs[_selectedListBlock.IndexOfBlockConfig].Name,
                ImagePath = TestData.BlockConfigs[_selectedListBlock.IndexOfBlockConfig].Image
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

        #endregion

        public MainWindowViewModel()
        {
            ListBlocks = new ObservableCollection<ListBlock>(TestData.ListBlocks);
            CanvasObjects = new CompositeCollection();
            CreateBlockCommand = new LambdaCommand(OnCreateBlockCommandExecuted, CanCreateBlockCommandExecuted);
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

                _firstConnection = _secondConnection = null;
            }
        }
    }
}
