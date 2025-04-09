using SchemeApplication.Models;

namespace SchemeApplication.Data
{
    internal class TestData
    {
        #region ListBlocks

        private static List<ListBlock> _listBlocks = new List<ListBlock>()
        {
            new ListBlock() { Name = "AND", IndexOfBlockConfig = 0 },
            new ListBlock() { Name = "OR", IndexOfBlockConfig = 1 },
            new ListBlock() { Name = "NOT", IndexOfBlockConfig = 2 }
        };

        public static IReadOnlyList<ListBlock> ListBlocks { get => _listBlocks; }

        #endregion

        #region BlockConfigs

        private static List<Block> _blockList = new List<Block>() 
        {
            new Block() { InputBlocks = null, Name = "AND", InputsCount = 2, OutputsCount = 1 },
            new Block() { InputBlocks = null, Name = "OR", InputsCount = 2, OutputsCount = 1 },
            new Block() { InputBlocks = null, Name = "NOT", InputsCount = 1, OutputsCount = 1 },
        };

        public static IReadOnlyList<Block> BlockConfigs { get => _blockList; }

        #endregion
    }
}
