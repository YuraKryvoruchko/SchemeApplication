﻿using SchemeApplication.Models;
using SchemeApplication.ViewModels.ListBlocks.Base;

namespace SchemeApplication.ViewModels.ListBlocks
{
    /// <summary>
    /// Viewmodel категорії блоків, яка надає дані про категорію та самі елементи категорії.
    /// </summary>
    internal class BlockCategoryViewModel : TreeViewItemViewModel
    {
        #region Fields

        private readonly BlockCategory _blockCategory;

        #endregion

        #region Properties

        #region Name

        public string? Name { get => _blockCategory.Name; }

        #endregion

        #region Tool Tip Key

        public string? ToolTipKey { get => _blockCategory.ToolTipKey; }

        #endregion

        #region List Blocks

        private ICollection<ListBlockViewModel> _listBlocks;

        public ICollection<ListBlockViewModel> ListBlocks { get => _listBlocks; }

        #endregion

        #endregion

        #region Constructors

        public BlockCategoryViewModel(BlockCategory blockCategory)
        {
            _blockCategory = blockCategory;
            _listBlocks = new List<ListBlockViewModel>(blockCategory.ListBlocks.Count);
            foreach (var block in blockCategory.ListBlocks)
            {
                _listBlocks.Add(new ListBlockViewModel(block));
            }
        }

        #endregion
    }
}
