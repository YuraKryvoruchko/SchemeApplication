using SchemeApplication.Infrastructure.BlockLogics.Base;
using SchemeApplication.ViewModels.CanvasFigures;

namespace SchemeApplication.Infrastructure.BlockLogics
{
    /// <summary>
    /// Реалізація функції розгалуження сигналу
    /// </summary>
    internal class SplitterBlockLogic : BlockLogic
    {
        public override bool Execute()
        {
            BlockFigureViewModel? firstBlock = Block?.TryGetConnectedBlockOrNull(0);
            if (firstBlock == null)
            {
                throw new Exception();
            }

            return firstBlock.Execute();
        }
        public override bool CanExecute()
        {
            BlockFigureViewModel? firstBlock = Block?.TryGetConnectedBlockOrNull(0);
            if (firstBlock == null)
            {
                return false;
            }

            return firstBlock.CanExecute();
        }
    }
}
