using SchemeApplication.ViewModels.CanvasFigures;

namespace SchemeApplication.Models
{
    /// <summary>
    /// Дані про логічні блоки
    /// </summary>
    internal class Block
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int InputsCount { get; set; }
        public int OutputsCount { get; set; }
        public BlockType Type { get; set; }
    }
}
