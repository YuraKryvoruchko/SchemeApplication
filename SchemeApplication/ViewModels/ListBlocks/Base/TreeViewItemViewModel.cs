using SchemeApplication.ViewModels.Base;

namespace SchemeApplication.ViewModels.ListBlocks.Base
{
    /// <summary>
    /// Базовий клас, який надає дані про стан елемента у деревоподібному списку.
    /// </summary>
    internal class TreeViewItemViewModel : ViewModel
    {
        #region Properties

        #region Is Selected

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { Set(ref _isSelected, value); }
        }

        #endregion

        #region IsExpanded

        private bool _isExpanded;
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { Set(ref _isExpanded, value); }
        }

        #endregion

        #endregion
    }
}
