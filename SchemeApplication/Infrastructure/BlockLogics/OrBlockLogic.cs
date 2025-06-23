using SchemeApplication.Infrastructure.BlockLogics.Base;
using SchemeApplication.ViewModels.CanvasFigures;

namespace SchemeApplication.Infrastructure.BlockLogics
{
    /// <summary>
    /// Реалізація операції логічного АБО
    /// </summary>
    internal class OrBlockLogic : BlockLogic
    {
        public override bool Execute()
        {
            BlockFigureViewModel? firstBlock = Block?.TryGetConnectedBlockOrNull(0);
            BlockFigureViewModel? secondBlock = Block?.TryGetConnectedBlockOrNull(1);
            if (firstBlock == null || secondBlock == null)
            {
                throw new Exception();
            }

            return firstBlock.Execute() || secondBlock.Execute();
        }
        public override bool CanExecute()
        {
            BlockFigureViewModel? firstBlock = Block?.TryGetConnectedBlockOrNull(0);
            BlockFigureViewModel? secondBlock = Block?.TryGetConnectedBlockOrNull(1);
            if (firstBlock == null || secondBlock == null)
            {
                return false;
            }

            return firstBlock.CanExecute() && secondBlock.CanExecute();
        }
    }
}
