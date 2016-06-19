using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiCSUtil.Win32.Impl
{
    partial class WinAll
    {
        public IntPtr GetModuleHandle(string lpModuleName)
        {
            return HiWin32API.GetModuleHandle(lpModuleName);
        }

        public long GetWindowThreadProcessId(long hWnd, long lpdwProcessId)
        {
            return HiWin32API.GetWindowThreadProcessId(hWnd, lpdwProcessId);
        }

        public int GetCurrentThreadId()
        {
            return HiWin32API.GetCurrentThreadId();
        }
    }
}
