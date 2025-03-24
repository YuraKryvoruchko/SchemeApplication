using System.Windows.Controls;
using SchemeApplication.Services.Interfaces;
using SchemeApplication.Views;
using SchemeApplication.ViewModels;
using SchemeApplication.Models;
using SchemeApplication.Infrastructure.BlockLogics;

namespace SchemeApplication.Services
{
    internal class BlockBuilderService : IBlockBuilderService
    {
        private Canvas _canvas;

        public static BlockBuilderService? Singleton { get; set; }

        public BlockBuilderService(Canvas canvas)
        {
            _canvas = canvas;
        }

        public void CreateBlock()
        {
            Models.Block model = new Models.Block()
            {
                Name = "And",
                InputsCount = 2,
                OutputsCount = 1,
                InputBlocks = new Models.Block[2]
            };
            model.Logic = new AndBlockLogic(model);

            Views.Block block = new Views.Block() 
            {
                DataContext = new BlockViewModel(model),
                Width = 120,
                Height = 70
            };
            _canvas.Children.Add(block);
        }
    }
}
