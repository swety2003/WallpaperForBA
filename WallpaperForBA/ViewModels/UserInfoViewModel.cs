using CommunityToolkit.Mvvm.ComponentModel;
using WallpaperForBA.Shared.ViewUtil;

namespace WallpaperForBA.ViewModels
{
    public partial class UserInfoViewModel : ViewModelBase
    {
        public override void Init()
        {
            UpdateInterval = 60;
            base.Init();
            Update();
        }
        public override void Update()
        {
            UpdateUserInfo();
            UpdateTime();
        }

        /// <summary>
        /// 
        /// </summary>
        [ObservableProperty] private string userName;

        [ObservableProperty] private string machineName;

        void UpdateUserInfo()
        {
            UserName = Environment.UserName;
            MachineName = Environment.MachineName;
        }


        /// <summary>
        /// 
        /// </summary>
        [ObservableProperty] private DateTime nowTime;

        public void UpdateTime()
        {
            NowTime = DateTime.Now;
        }
    }
}