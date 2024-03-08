using System.Windows.Controls;
using WallpaperForBA.Shared.ViewUtil;


namespace WallpaperForBA.Shared.Controls
{
    public class MyViewBase<T> : UserControl where T : ViewModelBase, new()
    {
        private T? viewmodel;

        public T? VM => viewmodel;

        public MyViewBase()
        {
            viewmodel = new T();
            viewmodel.SetView(this);
            DataContext = viewmodel;
        }
    }

    public class MyViewBase : UserControl
    {
        public MyViewBase()
        {
            throw new NotSupportedException();
        }
    }
}
