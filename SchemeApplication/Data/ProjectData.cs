using SchemeApplication.Models;
using SchemeApplication.ViewModels.CanvasFigures;

namespace SchemeApplication.Data
{
    internal class ProjectData
    {
        #region ListBlockCategories

        private static List<BlockCategory> _blockCategories = new List<BlockCategory>()
        {
            new BlockCategory()
            {
                Name = "SystemBlocksStr",
                ToolTipKey = "SystemBlocksToolTipStr",
                ListBlocks = new ListBlock[]
                {
                    new ListBlock() { Name = "Input", ToolTipKey = "InputToolTipStr", ImagePath = "/Resources/Images/block_icons/input_icon.png", IndexOfBlockConfig = 3 },
                    new ListBlock() { Name = "Output", ToolTipKey = "OutputToolTipStr", ImagePath = "/Resources/Images/block_icons/output_icon.png", IndexOfBlockConfig = 4 },
                }
            },
            new BlockCategory()
            {
                Name = "LogicalBlocksStr",
                ToolTipKey = "LogicalBlocksToolTipStr",
                ListBlocks = new ListBlock[]
                {
                    new ListBlock() { Name = "And", ToolTipKey = "AndToolTipStr", ImagePath = "/Resources/Images/block_icons/and_icon.png", IndexOfBlockConfig = 0 },
                    new ListBlock() { Name = "Or", ToolTipKey = "OrToolTipStr", ImagePath = "/Resources/Images/block_icons/or_icon.png", IndexOfBlockConfig = 1 },
                    new ListBlock() { Name = "Not", ToolTipKey = "NotToolTipStr", ImagePath = "/Resources/Images/block_icons/not_icon.png", IndexOfBlockConfig = 2 },
                }
            },
            new BlockCategory()
            {
                Name = "SplitBlocksStr",
                ToolTipKey = "SplitBlocksToolTipStr",
                ListBlocks = new ListBlock[]
                {
                    new ListBlock() { Name = "Double splitter", ToolTipKey = "DoubleSplitterToolTipStr", ImagePath = "/Resources/Images/block_icons/split_2_icon.png", IndexOfBlockConfig = 5 },
                    new ListBlock() { Name = "Triple splitter", ToolTipKey = "TripleSplitterToolTipStr", ImagePath = "/Resources/Images/block_icons/split_3_icon.png", IndexOfBlockConfig = 6 },
                }
            }
        };

        public static IReadOnlyList<BlockCategory> BlockCategories { get => _blockCategories; }

        #endregion

        #region BlockConfigs

        private static List<Block> _blockList = new List<Block>()
        {
            new Block() { Name = "AND", InputsCount = 2, OutputsCount = 1, Type = BlockType.And, Image = "/Resources/Images/Blocks/block_and.png"},
            new Block() { Name = "OR", InputsCount = 2, OutputsCount = 1, Type = BlockType.Or, Image = "/Resources/Images/Blocks/block_or.png"},
            new Block() { Name = "NOT", InputsCount = 1, OutputsCount = 1, Type = BlockType.Not, Image = "/Resources/Images/Blocks/block_not.png"},
            new Block() { InputsCount = 0, OutputsCount = 1, Type = BlockType.Input, Image = "/Resources/Images/Blocks/block_input.png" },
            new Block() { InputsCount = 1, OutputsCount = 0, Type = BlockType.Output, Image = "/Resources/Images/Blocks/block_output.png" },
            new Block() { Name = "DOUBLE SPLIT", InputsCount = 1, OutputsCount = 2, Type = BlockType.Split, Image = "/Resources/Images/Blocks/block_split_2.png" },
            new Block() { Name = "TRIPLE SPLIT", InputsCount = 1, OutputsCount = 3, Type = BlockType.Split, Image = "/Resources/Images/Blocks/block_split_3.png" },
        };

        public static IReadOnlyList<Block> BlockConfigs { get => _blockList; }

        #endregion
    }
}
