using System.Windows.Threading;

namespace WallpaperForBA.Utils
{
    class TimerTick
    {
        DispatcherTimer Timer = new DispatcherTimer();
        public TimerTick(int seconds, Action action)
        {
            action();
            Timer.Interval = new TimeSpan(0, 0, seconds);
            Timer.Tick += (object sender, EventArgs e) =>
            {
                action.Invoke();
            };
        }

        public void Start()
        {
            this.Timer.Start();
        }
    }
}
