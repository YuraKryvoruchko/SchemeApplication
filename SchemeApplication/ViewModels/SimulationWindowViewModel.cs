using SchemeApplication.Infrastructure.Commands;
using SchemeApplication.ViewModels.Base;
using SchemeApplication.ViewModels.CanvasFigures;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchemeApplication.ViewModels
{
    internal class SimulationWindowViewModel : ViewModel 
    {
        #region Properties

        #region Input blocks

        public List<InputBlockFigureViewModel> InputBlocks { get; }

        #endregion

        #region Output blocks

        public List<BlockFigureViewModel> OutputBlocks { get; }
        public ObservableCollection<SimulateResult> SimulateResults { get; }

        #endregion

        #endregion

        #region Commands

        #region SimulateCommand

        public ICommand SimulateCommand { get; }

        private void OnSimulateCommandExecuted(object parameter)
        {
            SimulateResults.Clear();
            for (int i = 0; i < OutputBlocks.Count; i++) 
            {
                SimulateResults.Add(new SimulateResult()
                {
                    Name = OutputBlocks[i].Name,
                    Value = OutputBlocks[i].Execute()
                });
            }
        }

        private bool CanSimulateCommandExecute(object parameter)
        {
            return true;
        }

        #endregion

        #endregion

        #region Contructors

        public SimulationWindowViewModel(List<InputBlockFigureViewModel> inputBlocks, List<BlockFigureViewModel> outputBlocks)
        {
            InputBlocks = inputBlocks;
            OutputBlocks = outputBlocks;
            SimulateResults = new ObservableCollection<SimulateResult>();
            foreach (var block in OutputBlocks)
            {
                SimulateResults.Add(new SimulateResult() { Name = block.Name });
            }

            SimulateCommand = new LambdaCommand(OnSimulateCommandExecuted, CanSimulateCommandExecute);
        }

        #endregion
    }
    internal class SimulateResult
    {
        public string Name { get; set; }
        public bool Value { get; set; }
    }
}
