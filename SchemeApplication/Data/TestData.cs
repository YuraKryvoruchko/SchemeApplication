using SchemeApplication.Models;
using SchemeApplication.ViewModels.CanvasFigures;

namespace SchemeApplication.Data
{
    internal class TestData
    {
        #region ListBlocks

        private static List<ListBlock> _listBlocks = new List<ListBlock>()
        {
            new ListBlock() { Name = "AND", IndexOfBlockConfig = 0 },
            new ListBlock() { Name = "OR", IndexOfBlockConfig = 1 },
            new ListBlock() { Name = "NOT", IndexOfBlockConfig = 2 },
            new ListBlock() { Name = "INPUT", IndexOfBlockConfig = 3 },
            new ListBlock() { Name = "OUTPUT", IndexOfBlockConfig = 4 },
        };

        public static IReadOnlyList<ListBlock> ListBlocks { get => _listBlocks; }

        #endregion

        #region BlockConfigs

        private static List<Block> _blockList = new List<Block>()
        {
            new Block() { Name = "AND", InputsCount = 2, OutputsCount = 1, Type = BlockType.And },
            new Block() { Name = "OR", InputsCount = 2, OutputsCount = 1, Type = BlockType.Or },
            new Block() { Name = "NOT", InputsCount = 1, OutputsCount = 1, Type = BlockType.Not },
            new Block() { InputsCount = 0, OutputsCount = 1, Type = BlockType.Input },
            new Block() { InputsCount = 1, OutputsCount = 0, Type = BlockType.Output }
        };

        public static IReadOnlyList<Block> BlockConfigs { get => _blockList; }

        #endregion
    }
}
