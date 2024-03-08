using Peter;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using WallpaperForBA.Models;
using WallpaperForBA.ViewModels;
using ListBox = System.Windows.Controls.ListBox;

namespace WallpaperForBA.Views
{
    /// <summary>
    /// BottomPanel.xaml 的交互逻辑
    /// </summary>
    public partial class BottomPanel : MyViewBase<BottomPanelViewModel>
    {
        public BottomPanel()
        {
            InitializeComponent();
            UseTheScrollViewerScrolling(ic);
        }

        public void UseTheScrollViewerScrolling(FrameworkElement fElement)
        {
            fElement.PreviewMouseWheel += (sender, e) =>
            {
                sv.ScrollToVerticalOffset(sv.VerticalOffset - e.Delta);
            };
        }
        private void Border_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            var lb = (Border)sender;
            List<FileInfo> fis = new List<FileInfo>();


            if (lb.DataContext is DeskIcons di)
            {
                fis.Add(new FileInfo(di.lnk_path));
            }
            PInvoke.GetCursorPos(out System.Drawing.Point pt);
            ShellContextMenu ctxMnu = new ShellContextMenu();
            ctxMnu.ShowContextMenu(fis.ToArray(), pt);
        }

        private void Border_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var lb = (Border)sender;
            var f = lb.DataContext as DeskIcons;
            if (f != null)
            {
                Process.Start("explorer.exe", f.lnk_path);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            VM?.UpdateIcons();
        }

        //private void StackPanel_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    var sp = sender as StackPanel;
        //    if (sp.DataContext is DeskIcons di)
        //    {
        //        ShellContextMenu ctxMnu = new ShellContextMenu();
        //        FileInfo[] arrFI = new FileInfo[1];
        //        arrFI[0] = new FileInfo(this.treeMain.SelectedNode.Tag.ToString());
        //        ctxMnu.ShowContextMenu(arrFI, this.PointToScreen(new Point(e.X, e.Y)));
        //    }
        //}
    }
}
