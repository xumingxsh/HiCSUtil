using System;

namespace HiCSUtil.Win32.Impl
{
    partial class WinAll
    {
        public IntPtr SetWindowsHookEx(WinEnum.WH_Event_Hook_Type idHook, 
            Func<int, Int32, IntPtr, int> lpfn,
            IntPtr pInstance, int threadId)
        {
            return HiWin32API.SetWindowsHookEx(idHook, lpfn, pInstance, threadId);
        }

        public bool UnhookWindowsHookEx(IntPtr pHookHandle)
        {
            return HiWin32API.UnhookWindowsHookEx(pHookHandle);
        }

        public int CallNextHookEx(IntPtr pHookHandle, int nCode,
            Int32 wParam, IntPtr lParam)
        {
            return HiWin32API.CallNextHookEx(pHookHandle, nCode, wParam, lParam);
        }
    }
}
