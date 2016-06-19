using System;
using System.Collections.Generic;
using System.Linq;
using HiCSUtil.Win32.Impl;

namespace HiCSUtil.Win32
{
    public class HiWin32
    {
        /// <summary>
        /// 所有接口
        /// </summary>
        public static IWinAll API
        {
            get
            {
                return impl as IWinAll;
            }
        }

        /// <summary>
        /// 关于钩子(hook)的函数
        /// </summary>
        public static IHook Hook
        {
            get
            {
                return impl as IHook;
            }
        }

        /// <summary>
        /// 窗体相关的函数
        /// </summary>
        public static IWnd WndFunc
        {
            get
            {
                return impl as IWnd;
            }            
        }

        /// <summary>
        /// 键盘鼠标相关的函数
        /// </summary>
        public static IInput Input
        {
            get
            {
                return impl as IInput;
            }
        }

        public static IThread Thread
        {
            get
            {
                return impl as IThread;
            }
        }

        public static IMessage Message
        {
            get
            {
                return impl as IMessage;
            }
        }

        static WinAll impl = new WinAll();
    }
}
