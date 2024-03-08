using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WallpaperForBA.Models;
using WallpaperForBA.Utils;

namespace WallpaperForBA.ViewModels
{
    public partial class BottomPanelViewModel : ViewModelBase
    {
        public override void Init()
        {
            base.Init();

            UpdateIcons();
        }
        public override void Update()
        {
            UpdateTime();
        }

        [ObservableProperty] ObservableCollection<DeskIcons> icons;

        /// <summary>
        /// 
        /// </summary>
        [ObservableProperty] private DateTime nowTime;

        [ObservableProperty] private double hourDeg;

        [ObservableProperty] private double minDeg;

        [ObservableProperty] private double secondDeg;

        public void UpdateTime()
        {

            NowTime = DateTime.Now;

            HourDeg = NowTime.Hour * 30 + NowTime.Minute * 30 / 60 - 90;

            MinDeg = NowTime.Minute * 6 + NowTime.Second * 6 / 60 - 90;

            SecondDeg = NowTime.Second * 6 - 90;
        }

        public void UpdateIcons()
        {

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//桌面路径 

            Icons = new ObservableCollection<DeskIcons>(LnkUtil.GetAll(desktop));
        }
    }
}
