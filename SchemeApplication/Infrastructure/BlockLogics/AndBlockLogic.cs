using SchemeApplication.Infrastructure.BlockLogics.Base;
using SchemeApplication.ViewModels.CanvasFigures;

namespace SchemeApplication.Infrastructure.BlockLogics
{
    internal class AndBlockLogic : BlockLogic
    {
        public override bool Execute()
        {
            BlockFigureViewModel? firstBlock = Block?.TryGetConnectedBlockOrNull(0);
            BlockFigureViewModel? secondBlock = Block?.TryGetConnectedBlockOrNull(1);
            if(firstBlock == null || secondBlock == null)
            {
                throw new Exception();
            }

            return firstBlock.Execute() && secondBlock.Execute();
        }
    }
}
