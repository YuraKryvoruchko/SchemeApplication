using SchemeApplication.ViewModels.Base;
using System.Collections.ObjectModel;
using SchemeApplication.Models;
using System.Windows.Input;
using SchemeApplication.Infrastructure.Commands;
using SchemeApplication.Data;

namespace SchemeApplication.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        public ObservableCollection<ListBlock> ListBlocks { get; }

        private ListBlock _selectedListBlock;

        public ListBlock SelectedListBlock
        {
            get => _selectedListBlock;
            set => Set(ref _selectedListBlock, value);
        }

        public ICommand CreateBlockCommand { get; }

        private void OnCreateBlockCommandExecuted(object parameter)
        {   
            SelectedListBlock = null;
        }
        private bool CanCreateBlockCommandExecuted(object parameter) 
        {
            return _selectedListBlock != null;
        }

        public MainWindowViewModel()
        {
            ListBlocks = new ObservableCollection<ListBlock>(TestData.ListBlocks);

            CreateBlockCommand = new LambdaCommand(OnCreateBlockCommandExecuted, CanCreateBlockCommandExecuted);
        }
    }
}
