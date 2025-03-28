using System.Windows;
using System.Windows.Controls;

namespace SchemeApplication.Views.Controls
{
    internal class ItemsCanvas : ItemsControl
    {
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is DraggableContentControl;
        }
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new DraggableContentControl();
        }
    }
}
