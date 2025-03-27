using SchemeApplication.Models;

namespace SchemeApplication.Data
{
    internal class TestData
    {
        private static List<ListBlock> _listBlocks = new List<ListBlock>()
        {
            new ListBlock() { Name = "AND" },
            new ListBlock() { Name = "OR" },
            new ListBlock() { Name = "NOT" }
        };
        public static IReadOnlyList<ListBlock> ListBlocks { get => _listBlocks; }
    }
}
