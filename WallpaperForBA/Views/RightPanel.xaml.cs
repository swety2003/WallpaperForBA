using WallpaperForBA.ViewModels;
using Application = System.Windows.Application;

namespace WallpaperForBA.Views
{
    /// <summary>
    /// BottomPanel.xaml 的交互逻辑
    /// </summary>
    public partial class RightPanel : MyViewBase<RightViewModel>
    {
        public RightPanel()
        {
            InitializeComponent();
        }

        private void SkewedBorder_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Image_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            new SettingsWindow().Show();
        }
    }
}
