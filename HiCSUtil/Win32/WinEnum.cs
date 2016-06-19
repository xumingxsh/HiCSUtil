using System;
using System.Runtime.InteropServices;

namespace HiCSUtil
{
    /// <summary>
    /// Win32接口的相关枚举
    /// </summary>
    public static class WinEnum
    {
        public enum WH_Event_Hook_Type : int
        {
            /// <summary>
            /// 底层键盘钩子
            /// </summary>
            WH_KEYBOARD_LL = 13,

            /// <summary>
            /// 底层鼠标钩子
            /// </summary>
            WH_MOUSE_LL = 14
        }


        public enum WM_MOUSE : int
        {
            /// <summary>
            /// 鼠标开始
            /// </summary>
            WM_MOUSEFIRST = 0x200,

            /// <summary>
            /// 鼠标移动
            /// </summary>
            WM_MOUSEMOVE = 0x200,

            /// <summary>
            /// 左键按下
            /// </summary>
            WM_LBUTTONDOWN = 0x201,

            /// <summary>
            /// 左键释放
            /// </summary>
            WM_LBUTTONUP = 0x202,

            /// <summary>
            /// 左键双击
            /// </summary>
            WM_LBUTTONDBLCLK = 0x203,

            /// <summary>
            /// 右键按下
            /// </summary>
            WM_RBUTTONDOWN = 0x204,

            /// <summary>
            /// 右键释放
            /// </summary>
            WM_RBUTTONUP = 0x205,

            /// <summary>
            /// 右键双击
            /// </summary>
            WM_RBUTTONDBLCLK = 0x206,

            /// <summary>
            /// 中键按下
            /// </summary>
            WM_MBUTTONDOWN = 0x207,

            /// <summary>
            /// 中键释放
            /// </summary>
            WM_MBUTTONUP = 0x208,

            /// <summary>
            /// 中键双击
            /// </summary>
            WM_MBUTTONDBLCLK = 0x209,

            /// <summary>
            /// 滚轮滚动
            /// </summary>
            /// <remarks>WINNT4.0以上才支持此消息</remarks>
            WM_MOUSEWHEEL = 0x020A
        }

        public enum WM_KEYBOARD : int
        {
            /// <summary>
            /// 非系统按键按下
            /// </summary>
            WM_KEYDOWN = 0x100,

            /// <summary>
            /// 非系统按键释放
            /// </summary>
            WM_KEYUP = 0x101,

            /// <summary>
            /// 系统按键按下
            /// </summary>
            WM_SYSKEYDOWN = 0x104,

            /// <summary>
            /// 系统按键释放
            /// </summary>
            WM_SYSKEYUP = 0x105
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }
        public enum VirtualKeys : byte
        {
            VK_NUMLOCK = 0x90, //数字锁定键 
            VK_SCROLL = 0x91,  //滚动锁定 
            VK_CAPITAL = 0x14, //大小写锁定 
            VK_SHIFT = 0x10,   //Shift
            VK_CONTROL = 0x11, //Ctrl
            VK_A = 62
        }

        public const int WM_MOUSEACTIVATE = 0x21;
        public const int WM_KEYDOWN = 0x100;
        public const int WS_EX_MDICHILD = 0x40;
        public const int WS_VISIBLE = 0x10000000;
        public const int WM_CLOSE = 0x10;
        public const int WS_CHILD = 0x40000000;
        public const int WS_EX_NOACTIVATE = 0x8000000;

        public const int SWP_NOOWNERZORDER = 0x200;
        public const int SWP_NOREDRAW = 0x8;
        public const int SWP_NOZORDER = 0x4;
        public const int SWP_SHOWWINDOW = 0x0040;
        public const int SWP_FRAMECHANGED = 0x20;
        public const int SWP_NOACTIVATE = 0x10;
        public const int SWP_ASYNCWINDOWPOS = 0x4000;
        public const int SWP_NOMOVE = 0x2;
        public const int SWP_NOSIZE = 0x1;

        public const int GWL_STYLE = (-16);

        public const int MA_NOACTIVATE = 3;
        public const uint KEYEVENTF_EXTENDEDKEY = 0x1;
        public const uint KEYEVENTF_KEYUP = 0x2;
    }
}
