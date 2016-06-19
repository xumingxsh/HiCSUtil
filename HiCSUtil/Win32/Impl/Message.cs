using System;

namespace HiCSUtil.Win32.Impl
{
    partial class WinAll
    {
        public bool PostMessage(IntPtr hwnd, uint Msg, long wParam, long lParam)
        {
            return HiWin32API.PostMessage(hwnd, Msg, wParam, lParam);
        }

        public int PostMessage(int hwnd, int wMsg, int wParam, int lParam)
        {
            return HiWin32API.PostMessage(hwnd, wMsg, wParam, lParam);
        }

        public int SendMessage(int hwnd, int wMsg, int wParam, int lParam)
        {
            return HiWin32API.SendMessage(hwnd, wMsg, wParam, lParam);
        }
    }
}
