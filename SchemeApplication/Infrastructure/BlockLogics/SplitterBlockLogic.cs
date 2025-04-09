using SchemeApplication.Infrastructure.BlockLogics.Base;
using SchemeApplication.ViewModels.CanvasFigures;

namespace SchemeApplication.Infrastructure.BlockLogics
{
    internal class SplitterBlockLogic(BlockFigureViewModel block) : BlockLogic(block)
    {
        public override bool Execute()
        {
            return Block.Execute(0);
        }
    }
}
