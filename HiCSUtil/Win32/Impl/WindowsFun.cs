using System;

namespace HiCSUtil.Win32.Impl
{
    partial class WinAll
    {
        public IntPtr FindWindow(string lpClassName, string lpWindowName)
        {
            return HiWin32API.FindWindow(lpClassName, lpWindowName);
        }

        public long SetParent(IntPtr hWndChild, IntPtr hWndNewParent)
        {
            return HiWin32API.SetParent(hWndChild, hWndNewParent);
        }

        public long GetWindowLong(IntPtr hwnd, int nIndex)
        {
            return HiWin32API.GetWindowLong(hwnd, nIndex);
        }

        public long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong)
        {
            return HiWin32API.SetWindowLong(hwnd, nIndex, dwNewLong);
        }

        public long SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy, long wFlags)
        {
            return HiWin32API.SetWindowPos(hwnd, hWndInsertAfter, x, y, cx, cy, wFlags);
        }

        public bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint)
        {
            return HiWin32API.MoveWindow(hwnd, x, y, cx, cy, repaint);
        }

        public int GetForegroundWindow()
        {
            return HiWin32API.GetForegroundWindow();
        }

        public int GetFocus()
        {
            return HiWin32API.GetFocus();
        }
    }
}
