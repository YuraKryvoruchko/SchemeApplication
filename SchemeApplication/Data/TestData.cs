using SchemeApplication.Models;
using SchemeApplication.ViewModels.CanvasFigures;

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
            new Block() { Name = "AND", InputsCount = 2, OutputsCount = 1, Type = BlockType.And },
            new Block() { Name = "OR", InputsCount = 2, OutputsCount = 1, Type = BlockType.Or },
            new Block() { Name = "NOT", InputsCount = 1, OutputsCount = 1, Type = BlockType.Not },
            new Block() { InputsCount = 0, OutputsCount = 1, Type = BlockType.Input },
            new Block() { InputsCount = 1, OutputsCount = 0, Type = BlockType.Output },
            new Block() { Name = "DOUBLE SPLIT", InputsCount = 1, OutputsCount = 2, Type = BlockType.Split },
            new Block() { Name = "TRIPLE SPLIT", InputsCount = 1, OutputsCount = 3, Type = BlockType.Split },
        };

        public static IReadOnlyList<Block> BlockConfigs { get => _blockList; }

        #endregion
    }
}
