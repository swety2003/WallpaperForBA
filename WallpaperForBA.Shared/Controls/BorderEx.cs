using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WallpaperForBA.Shared.Controls
{
    public class SkewedBorder : Border
    {


        public double SkewX
        {
            get { return (double)GetValue(SkewXProperty); }
            set { SetValue(SkewXProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SkewX.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SkewXProperty =
            DependencyProperty.Register("SkewX", typeof(double), typeof(SkewedBorder), new PropertyMetadata((double)0, propertyChangedCallback: (DependencyObject depObj, DependencyPropertyChangedEventArgs e) =>
            {
                var self = (SkewedBorder)depObj; var nv = (double)e.NewValue;
                self.RenderTransform = new SkewTransform(nv, 0);
                if (self.Child != null)
                {
                    self.Child.RenderTransform = new SkewTransform(0 - nv, 0);

                }

            }));

        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);
            if (visualAdded is UIElement el)
            {
                el.RenderTransform = new SkewTransform(0 - SkewX, 0);
            }

        }

    }

}
