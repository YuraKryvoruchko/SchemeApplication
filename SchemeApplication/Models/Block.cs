using System.Drawing;
using SchemeApplication.Infrastructure.BlockLogics.Base;

namespace SchemeApplication.Models
{
    internal class Block
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int InputsCount { get; set; }
        public int OutputsCount { get; set; }
        public Point Position { get; set; }
        public required Block[] InputBlocks { get; set; }
        public required BlockLogic Logic { get; set; }
    }
}
