using System.Windows;
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
        public BlockLogic Logic { get; set; }
    }
    internal class Line
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
    }
}
