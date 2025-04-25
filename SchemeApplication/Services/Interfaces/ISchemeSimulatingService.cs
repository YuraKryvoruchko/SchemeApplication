using SchemeApplication.ViewModels.CanvasFigures;

namespace SchemeApplication.Services.Interfaces
{
    internal interface ISchemeSimulatingService
    {
        bool IsSimulating { get; }

        event Action OnFinishSimulating;

        void StartSimulate(List<InputBlockFigureViewModel> inputBlocks, List<BlockFigureViewModel> outputBlocks);
    }
}
