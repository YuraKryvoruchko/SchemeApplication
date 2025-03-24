using SchemeApplication.Infrastructure.BlockLogics.Base;
using SchemeApplication.Models;

namespace SchemeApplication.Infrastructure.BlockLogics
{
    internal class OrBlockLogic(Block block) : BlockLogic(block)
    {
        public override bool Execute()
        {
            return Block.InputBlocks[0].Logic.Execute() || Block.InputBlocks[1].Logic.Execute();
        }
    }
}
