using System;
using System.Runtime.InteropServices;

namespace HiCSUtil
{
    public interface IThread
    {
        /// <summary>
        /// 获得模块句柄
        /// </summary>
        /// <param name="lpModuleName"></param>
        /// <returns></returns>
        IntPtr GetModuleHandle(string lpModuleName);

        /// <summary>
        /// 找出某个窗口的创建者（线程或进程），返回创建者的标志符
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpdwProcessId"></param>
        /// <returns></returns>
        long GetWindowThreadProcessId(long hWnd, long lpdwProcessId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int GetCurrentThreadId();
    }
}
