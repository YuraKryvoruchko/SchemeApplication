using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SchemeApplication.Views.Controls
{
    public class DraggableContentControl : ContentControl
    {
        private IInputElement ParentInputElement { get; set; }
        private bool IsDragActive { get; set; }
        private Point DragOffset { get; set; }

        public DraggableContentControl()
        {
            this.PreviewMouseLeftButtonDown += InitializeDrag_OnLeftMouseButtonDown;
            this.PreviewMouseLeftButtonUp += CompleteDrag_OnLeftMouseButtonUp;
            this.PreviewMouseMove += Drag_OnMouseMove;
            this.RenderTransformOrigin = new Point(0.5, 0.5);
        }

        #region Overrides of FrameworkElement

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            // Parent is required to calculate the relative mouse coordinates.
            DependencyObject parentControl = this.Parent;
            if (parentControl == null
                && !TryFindParentElement(this, out parentControl)
                && !(parentControl is IInputElement))
            {
                return;
            }

            this.ParentInputElement = parentControl as IInputElement;
        }

        #endregion

        private void InitializeDrag_OnLeftMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Do nothing if disabled
            this.IsDragActive = this.IsEnabled;
            if (!this.IsDragActive)
            {
                return;
            }

            Point relativeDragStartPosition = e.GetPosition(this.ParentInputElement);

            // Calculate the drag offset to allow the content to be dragged 
            // relative to the clicked coordinates (instead of the top-left corner)
            this.DragOffset = new Point(
              relativeDragStartPosition.X - Canvas.GetLeft(this),
              relativeDragStartPosition.Y - Canvas.GetTop(this));

            // Prevent other controls from stealing mouse input while dragging
            CaptureMouse();
        }

        private void CompleteDrag_OnLeftMouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.IsDragActive = false;
            ReleaseMouseCapture();
        }

        private void Drag_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (!this.IsDragActive)
            {
                return;
            }

            Point currentPosition = e.GetPosition(this.ParentInputElement);

            // Apply the drag offset to drag relative to the 
            // initial mouse down coordinates (instead of the top-left corner)
            currentPosition.Offset(-this.DragOffset.X, -this.DragOffset.Y);
            Canvas.SetLeft(this, currentPosition.X);
            Canvas.SetTop(this, currentPosition.Y);
        }

        private bool TryFindParentElement<TParent>(DependencyObject child, out TParent resultElement)
          where TParent : DependencyObject
        {
            resultElement = null;

            if (child == null)
            {
                return false;
            }

            DependencyObject parentElement = VisualTreeHelper.GetParent(child);

            if (parentElement is TParent)
            {
                resultElement = parentElement as TParent;
                return true;
            }

            return TryFindParentElement(parentElement, out resultElement);
        }
    }
}
