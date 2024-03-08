
using CommunityToolkit.Mvvm.ComponentModel;
using CZGL.SystemInfo;
using WallpaperForBA.Models;

namespace WallpaperForBA.ViewModels
{
    public partial class RightViewModel : ViewModelBase
    {
        public override void Init()
        {
            base.Init();

            v1 = CPUHelper.GetCPUTime();
            network = NetworkInfo.TryGetRealNetworkInfo() ?? throw new Exception();
            oldRate = network.GetIpv4Speed();

            Update();
        }
        public override void Update()
        {
            UpdateTrafficMonitor();
            UpdateBattery();
        }
        /// <summary>
        /// 
        /// </summary>
        private NetworkInfo network;
        private CPUTime v1;
        private Rate oldRate;

        [ObservableProperty] private int cpuLoad;
        [ObservableProperty] private int ramLoad;

        [ObservableProperty] private NetItem download;
        [ObservableProperty] private NetItem upload;

        private void UpdateTrafficMonitor()
        {

            var v2 = CPUHelper.GetCPUTime();
            var value = CPUHelper.CalculateCPULoad(v1, v2);
            v1 = v2;

            var memory = MemoryHelper.GetMemoryValue();
            var newRate = network.GetIpv4Speed();
            var speed = NetworkInfo.GetSpeed(oldRate, newRate);
            oldRate = newRate;

            CpuLoad = (int)(value * 100);
            RamLoad = (int)memory.UsedPercentage;

            Upload = new NetItem(speed.Sent.Size.ToString(), speed.Sent.SizeType.ToString());
            Download = new NetItem(speed.Received.Size.ToString(), speed.Received.SizeType.ToString());
        }


        /// <summary>
        /// 
        /// </summary>
        [ObservableProperty] private int lifePercent;
        public void UpdateBattery()
        {
            Windows.Win32.System.Power.SYSTEM_POWER_STATUS status;
            PInvoke.GetSystemPowerStatus(out status);
            LifePercent = status.BatteryLifePercent;


        }
    }
}