using SchemeApplication.Infrastructure.BlockLogics.Base;
using SchemeApplication.ViewModels.CanvasFigures;

namespace SchemeApplication.Infrastructure.BlockLogics
{
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
    }
}
