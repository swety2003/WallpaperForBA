using WallpaperForBA.Utils;
using WallpaperForBA.ViewModels;
using WallpaperForBA.Views;

namespace WallpaperForBA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(this);
        }

        private MainWindowViewModel ViewModel => this.DataContext as MainWindowViewModel ?? throw new NotImplementedException();

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.ShowInDesktop();

        }

    }
}