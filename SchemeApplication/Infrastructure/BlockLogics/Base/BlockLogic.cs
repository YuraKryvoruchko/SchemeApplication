using SchemeApplication.ViewModels.CanvasFigures;

namespace SchemeApplication.Infrastructure.BlockLogics.Base
{
    internal abstract class BlockLogic
    {
        public BlockFigureViewModel? Block { get; set; }

        public abstract bool Execute();
    }
}
