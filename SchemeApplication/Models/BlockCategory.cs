namespace SchemeApplication.Models
{
    internal class BlockCategory
    {
        public string? Name { get; set; }
        public ICollection<ListBlock>? ListBlocks { get; set; }
    }
}
