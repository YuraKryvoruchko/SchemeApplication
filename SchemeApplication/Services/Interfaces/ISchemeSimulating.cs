using SchemeApplication.ViewModels.CanvasFigures;

namespace SchemeApplication.Services.Interfaces
{
    internal interface ISchemeSimulating
    {
        void StartSimulate(List<InputBlockFigureViewModel> inputBlocks, List<BlockFigureViewModel> outputBlocks);
    }
}
