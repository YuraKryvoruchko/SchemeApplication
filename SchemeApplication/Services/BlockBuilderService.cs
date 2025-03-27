using System.Windows.Controls;
using System.Windows;
using SchemeApplication.Services.Interfaces;
using SchemeApplication.ViewModels;
using SchemeApplication.Models;
using SchemeApplication.Infrastructure.BlockLogics;
using System.Windows.Data;

namespace SchemeApplication.Services
{
    internal class BlockBuilderService : IBlockBuilderService
    {
        private Canvas _canvas;

        public static BlockBuilderService? Singleton { get; set; }

        public List<Block> CreatedBlocks { get; private set; }

        public BlockBuilderService(Canvas canvas)
        {
            _canvas = canvas;
            CreatedBlocks = new List<Block>();
        }

        public void CreateBlock(Point point)
        {
            Block model = new Block()
            {
                Name = "And",
                InputsCount = 2,
                OutputsCount = 1,
                Position = point,
                InputBlocks = new Block[2]
            };
            model.Logic = new AndBlockLogic(model);

            Views.Block block = CreateViewBlock(model);
            _canvas.Children.Add(block);
            CreatedBlocks.Add(model);
        }
        public void DeleteBlock() { throw new NotImplementedException(); }
        public void MoveBlock() { throw new NotImplementedException(); }
        public void GetFrom(Block block, int fromOutputNumber) { throw new NotImplementedException(); }
        public void InputTo(Block block, int toInputNumber) { throw new NotImplementedException(); }
        public void RejectCurrentConnection() { throw new NotImplementedException(); }
        public void RejectConnection() { throw new NotImplementedException(); }

        private Views.Block CreateViewBlock(Block model)
        {
            Views.Block block = new Views.Block()
            {
                DataContext = new BlockViewModel(model),
                Width = 120,
                Height = 70
            };

            Binding leftPropertyBinding = new Binding(nameof(Block.Position) + "." + nameof(Block.Position.X));
            leftPropertyBinding.Mode = BindingMode.TwoWay;
            Binding topPropertyBinding = new Binding(nameof(Block.Position) + "." + nameof(Block.Position.Y));
            topPropertyBinding.Mode = BindingMode.TwoWay;
            block.SetBinding(Canvas.LeftProperty, leftPropertyBinding);
            block.SetBinding(Canvas.TopProperty, topPropertyBinding);

            return block;
        }
    }
}
