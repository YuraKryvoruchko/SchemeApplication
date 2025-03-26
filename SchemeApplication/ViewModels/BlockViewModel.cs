using SchemeApplication.Models;
using SchemeApplication.ViewModels.Base;
using System.Windows;

namespace SchemeApplication.ViewModels
{
    internal class BlockViewModel : ViewModel
    {
        private Block _block;

        #region Properties

        #region Name

        private string? _name;

        public string? Name
        {
            get => _name;
            set 
            {
                Set(ref _name, value);
                _block.Name = value;
            }
        }

        #endregion

        #region Image

        private string? _image;

        public string? Image
        {
            get { return _image; }
            set 
            { 
                Set(ref _image, value);
                _block.Image = value;
            }
        }


        #endregion

        #region Position

        private Point _position;

        public Point Position
        {
            get => _position;
            set 
            {
                Set(ref _position, value);
                _block.Position = value;
            } 
        }

        #endregion

        #endregion

        public BlockViewModel(Block block)
        {
            _block = block;
            Name = _block.Name;
            Image = _block.Image;
            Position = _block.Position;
        }
    }
}
