using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SchemeApplication.Views.Controls
{
    internal class ItemsCanvas : ItemsControl
    {
        public Canvas Canvas { get; private set; }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is DraggableContentControl;
        }
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new DraggableContentControl();
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.Loaded += (s, e) =>
            {
                Canvas = FindVisualChildCanvas(this);
            };
        }

        private Canvas FindVisualChildCanvas(DependencyObject parent)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is Canvas correctlyTyped)
                    return correctlyTyped;

                var result = FindVisualChildCanvas(child);
                if (result != null)
                    return result;
            }
            throw new Exception("Panel template must be Canvas!");
        }
    }
}
