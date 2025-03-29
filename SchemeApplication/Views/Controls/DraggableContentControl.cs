using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SchemeApplication.Views.Controls
{
    public class DraggableContentControl : ContentControl
    {
        #region Properties

        #region PositionProperty

        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.Register("Position", typeof(Point), typeof(DraggableContentControl), new PropertyMetadata(OnPositionPropertyChanged));

        public Point Position
        {
            get { return (Point)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }

        private static void OnPositionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DraggableContentControl control = d as DraggableContentControl;
            Point newValue = (Point)e.NewValue;
            Canvas.SetLeft(control, newValue.X);
            Canvas.SetTop(control, newValue.Y);
        }

        #endregion

        #region IsDraggableProperty

        public static readonly DependencyProperty IsDraggableProperty =
            DependencyProperty.Register("IsDraggable", typeof(bool), typeof(DraggableContentControl), new PropertyMetadata(true));

        public bool IsDraggable
        {
            get { return (bool)GetValue(IsDraggableProperty); }
            set { SetValue(IsDraggableProperty, value); }
        }

        #endregion

        #endregion

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
            if (!IsDraggable)
            {
                return;
            }

            this.IsDragActive = this.IsEnabled;
            if (!this.IsDragActive)
            {
                return;
            }

            Point relativeDragStartPosition = e.GetPosition(this.ParentInputElement);

            this.DragOffset = new Point(
              relativeDragStartPosition.X - Canvas.GetLeft(this),
              relativeDragStartPosition.Y - Canvas.GetTop(this));

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

            currentPosition.Offset(-this.DragOffset.X, -this.DragOffset.Y);
            Position = currentPosition;
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
