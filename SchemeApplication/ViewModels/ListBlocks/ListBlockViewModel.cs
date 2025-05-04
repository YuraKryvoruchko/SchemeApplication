using SchemeApplication.Models;
using SchemeApplication.ViewModels.ListBlocks.Base;

namespace SchemeApplication.ViewModels.ListBlocks
{
    internal class ListBlockViewModel : TreeViewItemViewModel
    {
        #region Fields

        private readonly ListBlock _listBlock;

        #endregion

        #region Properites

        #region Name

        public string? Name { get => _listBlock.Name; }

        #endregion

        #region Image Path

        public string? ImagePath { get => _listBlock.ImagePath; }

        #endregion

        #region Index Of Block Config

        public int IndexOfBlockConfig { get => _listBlock.IndexOfBlockConfig; }

        #endregion

        #endregion

        #region Constructors

        public ListBlockViewModel(ListBlock listBlock)
        {
            _listBlock = listBlock;
        }

        #endregion
    }
}
