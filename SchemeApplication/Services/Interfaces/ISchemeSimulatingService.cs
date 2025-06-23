using SchemeApplication.ViewModels.CanvasFigures;

namespace SchemeApplication.Services.Interfaces
{
    /// <summary>
    /// Інтерфейс для сервісу вікна симуляції
    /// </summary>
    internal interface ISchemeSimulatingService
    {
        bool IsSimulating { get; }

        event Action OnFinishSimulating;

        void StartSimulate(List<InputBlockFigureViewModel> inputBlocks, List<BlockFigureViewModel> outputBlocks);
    }
}
