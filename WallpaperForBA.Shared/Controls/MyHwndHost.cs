
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Interop;
using Windows.Win32;
using Windows.Win32.UI.WindowsAndMessaging;
using Windows.Win32.Foundation;
using System.Windows.Media;

namespace WallpaperForBA.Shared.Controls
{
    public class MyHwndHost : HwndHost
    {



        private IntPtr ChildHandle = IntPtr.Zero;

        public MyHwndHost(IntPtr handle)
        {
            ChildHandle = handle;
        }

        public MyHwndHost()
        {
            if (ChildHandle == IntPtr.Zero)
            {

                ChildHandle = new nint(0x0005003C);
            }
        }


        protected override HandleRef BuildWindowCore(HandleRef hwndParent)
        {
            HandleRef href = new HandleRef();

            if (ChildHandle != IntPtr.Zero)
            {
                const int WS_CHILD = 0x40000000;
                const int WS_CLIPCHILDREN = 0x02000000;
                try
                {
                    var hWindow = new HWND(ChildHandle);
                    PInvoke.SetWindowLong(hWindow, WINDOW_LONG_PTR_INDEX.GWL_STYLE, PInvoke.GetWindowLong(hWindow, WINDOW_LONG_PTR_INDEX.GWL_STYLE) | WS_CHILD| WS_CLIPCHILDREN);
                    //PInvoke.SetParent(hWindow, new HWND(hwndParent.Handle));
                }
                catch (Exception ex)
                {

                }

                var parameters = new HwndSourceParameters("walterlv")
                {
                    ParentWindow = hwndParent.Handle,
                    WindowStyle = WS_CHILD,
                };
                var _source = new HwndSource(parameters);
                var bd = new Border();
                bd.Background = Brushes.Red;
                // 这里的 ChildPage 是一个继承自 UseControl 的 WPF 控件，你可以自己创建自己的 WPF 控件。
                _source.RootVisual = bd;
                return new HandleRef(this, _source.Handle);

            }

            return href;
        }


        protected override void DestroyWindowCore(HandleRef hwnd)
        {

        }

    }
    
}

