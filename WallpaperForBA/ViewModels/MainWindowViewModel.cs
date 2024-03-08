using CommunityToolkit.Mvvm.ComponentModel;
using CZGL.SystemInfo;
using WallpaperForBA.Models;
using WallpaperForBA.Utils;
using Windows.Win32.System.Power;

namespace WallpaperForBA.ViewModels
{
    partial class MainWindowViewModel : ObservableObject
    {
        MainWindow? View { get; set; }

        public MainWindowViewModel() { }

        public MainWindowViewModel(MainWindow mainWindow):base ()
        {
            View = mainWindow;
        }





        


    }
}
