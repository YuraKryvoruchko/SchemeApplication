using SchemeApplication.ViewModels.Base;
using System.Collections.ObjectModel;
using SchemeApplication.Models;
using System.Windows.Input;
using System.Windows;
using SchemeApplication.Infrastructure.Commands;
using SchemeApplication.Data;
using SchemeApplication.Services.Interfaces;
using SchemeApplication.Services;
using System.Windows.Data;

namespace SchemeApplication.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private IBlockBuilderService _blockBuilderService;

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
            BlockBuilderService.Singleton.CreateBlock((Point)parameter);
            SelectedListBlock = null;
        }
        private bool CanCreateBlockCommandExecuted(object parameter) 
        {
            return _selectedListBlock != null;
        }

        #endregion

        #region SelectBlock

        public ICommand SelectBlock { get; }

        private void OnSelectBlockCommandExecuted(object parameter)
        {
            SelectedBlock = (BlockViewModel)parameter;
        }
        private bool CanSelectBlockCommandExecuted(object parameter)
        {
            return true;
        }

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            ListBlocks = new ObservableCollection<ListBlock>(TestData.ListBlocks);

            CreateBlockCommand = new LambdaCommand(OnCreateBlockCommandExecuted, CanCreateBlockCommandExecuted);
        }
    }
}
