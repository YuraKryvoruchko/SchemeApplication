using SchemeApplication.ViewModels.CanvasFigures;

namespace SchemeApplication.Infrastructure.BlockLogics.Base
{
    internal abstract class BlockLogic
    {
        protected BlockFigureViewModel Block { get; }

        public BlockLogic(BlockFigureViewModel block)
        {
            Block = block;
        }

        public abstract bool Execute();
    }
}
