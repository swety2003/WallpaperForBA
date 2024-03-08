using Windows.Win32.UI.WindowsAndMessaging;

namespace WallpaperForBA.Utils
{
    static class WindowUtil
    {
        static HWND FindFolderViewHwnd()
        {
            try
            {
                var hWND = PInvoke.FindWindow("Progman", "Program Manager");
                var ret = PInvoke.FindWindowEx(hWND, HWND.Null, "SHELLDLL_DefView", null);
                if (ret == HWND.Null)
                {
                    throw new Exception();
                }
                return ret;

            }
            catch
            {
                return FindFolderViewHwnd_WP();
            }

        }
        static HWND FindFolderViewHwnd_WP()
        {
            var i = 0;
            var hWND = PInvoke.FindWindow("WorkerW", null);
            var ret = PInvoke.FindWindowEx(hWND, HWND.Null, "SHELLDLL_DefView", null);
            while (ret == HWND.Null && i <= 100)
            {
                i++;
                hWND = PInvoke.FindWindowEx(HWND.Null, hWND, "WorkerW", null);
                if (hWND == HWND.Null) throw new Exception();

                //ret = PInvoke.FindWindowEx(hWND, HWND.Null, "TXMiniSkin", null);
                //if (ret != HWND.Null) break;

                ret = PInvoke.FindWindowEx(hWND, HWND.Null, "SHELLDLL_DefView", null);

            }
            if (ret == HWND.Null) throw new Exception();
            return hWND;
        }

        internal static void ShowInDesktop(this Window w)
        {
            w.WindowStyle = WindowStyle.None;
            var hWND = new HWND(new WindowInteropHelper(w).Handle);
            var h = new HWND(FindFolderViewHwnd());
            PInvoke.SetParent(hWND, h);
            PInvoke.SetWindowPos(hWND, new HWND(1), 0, 0, 0, 0, SET_WINDOW_POS_FLAGS.SWP_NOMOVE | SET_WINDOW_POS_FLAGS.SWP_NOSIZE);
            w.WindowState = WindowState.Maximized;
        }
    }
}
