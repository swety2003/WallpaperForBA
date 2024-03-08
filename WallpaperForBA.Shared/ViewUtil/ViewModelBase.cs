using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WallpaperForBA.Shared.ViewUtil
{
    public abstract class ViewModelBase : ObservableObject
    {
        public ViewModelBase(UserControl control):base()
        {
            view = control;
        }

        public ViewModelBase()
        {
            //Task.Run(Init);
            Init();
        }

        private int interval = 1;

        public int UpdateInterval
        {
            get { return interval; }
            set
            {
                interval = value;
                if (timer != null)
                {
                    timer.Interval = new TimeSpan(0, 0, value);
                }
            }
        }

        public abstract void Update();

        public virtual void Init()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, interval);
            timer.Tick += (object? s, EventArgs e) =>
            {
                Update();
            };
            timer.Start();
        }

        private DispatcherTimer? timer { get; set; }


        private UserControl? view { get; set; }


        public T GetView<T>()
        {
            if (view is T v)
                return v;
            throw new NotSupportedException();
        }

        public void SetView(UserControl uc)
        {
            view = uc;
        }
    }
}
