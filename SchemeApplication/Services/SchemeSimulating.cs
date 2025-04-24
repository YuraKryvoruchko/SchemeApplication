using SchemeApplication.Services.Interfaces;
using SchemeApplication.ViewModels;
using SchemeApplication.ViewModels.CanvasFigures;
using SchemeApplication.Views;

namespace SchemeApplication.Services
{
    internal class SchemeSimulatingService : ISchemeSimulating
    {
        public void StartSimulate(List<InputBlockFigureViewModel> inputBlocks, List<BlockFigureViewModel> outputBlocks)
        {
            SimulationWindow window = new SimulationWindow();
            window.DataContext = new SimulationWindowViewModel(inputBlocks, outputBlocks);
            window.Focus();
        }
        public static void StartSimulateStatic(List<InputBlockFigureViewModel> inputBlocks, List<BlockFigureViewModel> outputBlocks)
        {
            SimulationWindow window = new SimulationWindow();
            window.DataContext = new SimulationWindowViewModel(inputBlocks, outputBlocks);
            window.Show();
            window.Focus();
        }
    }
}
