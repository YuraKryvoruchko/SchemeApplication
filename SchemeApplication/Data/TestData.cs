using SchemeApplication.Models;
using SchemeApplication.ViewModels.CanvasFigures;
using System.IO;

namespace SchemeApplication.Data
{
    internal class TestData
    {
        #region ListBlockCategories

        private static List<BlockCategory> _blockCategories = new List<BlockCategory>()
        {
            new BlockCategory()
            {
                Name = "SYSTEM BLOCKS",
                ListBlocks = new ListBlock[]
                {
                    new ListBlock() { Name = "INPUT", IndexOfBlockConfig = 3 },
                    new ListBlock() { Name = "OUTPUT", IndexOfBlockConfig = 4 },
                }
            },
            new BlockCategory()
            {
                Name = "LOGICAL BLOCKS",
                ListBlocks = new ListBlock[]
                {
                    new ListBlock() { Name = "AND", IndexOfBlockConfig = 0 },
                    new ListBlock() { Name = "OR", IndexOfBlockConfig = 1 },
                    new ListBlock() { Name = "NOT", IndexOfBlockConfig = 2 },
                }
            },
            new BlockCategory()
            {
                Name = "SPLIT BLOCKS",
                ListBlocks = new ListBlock[]
                {
                    new ListBlock() { Name = "DOUBLE SPLIT", IndexOfBlockConfig = 5 },
                    new ListBlock() { Name = "TRIPLE SPLIT", IndexOfBlockConfig = 6 },
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
