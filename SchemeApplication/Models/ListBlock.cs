namespace SchemeApplication.Models
{
    /// <summary>
    /// Дані про елемент списку блоку
    /// </summary>
    internal class ListBlock
    {
        public string? Name { get; set; }
        public string? ImagePath { get; set; }
        public string? ToolTipKey { get; set; }
        public int IndexOfBlockConfig { get; set; }
    }
}
