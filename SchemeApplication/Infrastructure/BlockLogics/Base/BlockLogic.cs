using SchemeApplication.Models;

namespace SchemeApplication.Infrastructure.BlockLogics.Base
{
    internal abstract class BlockLogic
    {
        protected Block Block { get; }

        public BlockLogic(Block block)
        {
            Block = block;
        }

        public abstract bool Execute();
    }
}
