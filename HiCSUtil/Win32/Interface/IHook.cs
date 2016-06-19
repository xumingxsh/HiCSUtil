using System;
using System.Runtime.InteropServices;

namespace HiCSUtil
{
    public interface IHook
    {
        /// <summary>
        /// 安装钩子
        /// </summary>
        /// <param name="idHook"></param>
        /// <param name="lpfn"></param>
        /// <param name="pInstance"></param>
        /// <param name="threadId"></param>
        /// <returns></returns>
        IntPtr SetWindowsHookEx(WinEnum.WH_Event_Hook_Type idHook,
            Func<int, Int32, IntPtr, int> lpfn, IntPtr pInstance, int threadId);

        /// <summary>
        /// 卸载钩子
        /// </summary>
        /// <param name="idHook"></param>
        /// <returns></returns>
        bool UnhookWindowsHookEx(IntPtr pHookHandle);

        /// <summary>
        /// 传递钩子
        /// </summary>
        /// <param name="idHook"></param>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        int CallNextHookEx(IntPtr pHookHandle, int nCode,
            Int32 wParam, IntPtr lParam);
    }
}
