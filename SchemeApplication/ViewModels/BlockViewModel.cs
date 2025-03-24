using SchemeApplication.Models;
using SchemeApplication.ViewModels.Base;
using System.Drawing;

namespace SchemeApplication.ViewModels
{
    internal class BlockViewModel : ViewModel
    {
        private Block _block;

        #region Properties

        #region Name

        private string _name;

        public string Name
        {
            get => _block.Name;
            set => Set(ref _name, value);
        }

        #endregion

        #region Position

        private Point _position;

        public Point Position
        {
            get => _block.Position;
            set => Set(ref _position, value);
        }

        #endregion

        #endregion

        public BlockViewModel()
        { }
        public BlockViewModel(Block block)
        {
            _block = block;
        }
    }
}
