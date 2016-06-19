using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace HiCSUtil
{
    /// <summary>
    /// C函数调用
    /// </summary>
    public class HiWin32API
    {
        /// <summary>
        /// 获得模块句柄
        /// </summary>
        /// <param name="lpModuleName"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        
        
        /// <summary>
        /// 找出某个窗口的创建者（线程或进程），返回创建者的标志符
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpdwProcessId"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", SetLastError = true,
           CharSet = CharSet.Unicode, ExactSpelling = true,
           CallingConvention = CallingConvention.StdCall)]
        public static extern long GetWindowThreadProcessId(long hWnd, long lpdwProcessId);

       

        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hwnd, uint Msg, long wParam, long lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll", EntryPoint = "PostMessageW")]
        public static extern int PostMessage(int hwnd, int wMsg, int wParam, int lParam);

        /// <summary>
        /// 通常，系统内的每个线程都有自己的输入队列。
        /// 本函数（既“连接线程输入函数”）允许线程和进程共享输入队列。
        /// 连接了线程后，输入焦点、窗口激活、鼠标捕获、键盘状态以及输入队列状态都会进入共享状态。
        /// 调用这个函数时，会重设键盘状态。
        /// </summary>
        /// <param name="idAttach"></param>
        /// <param name="idAttachTo"></param>
        /// <param name="fAttach"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int AttachThreadInput(int idAttach, int idAttachTo, int fAttach);

        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();


        /// <summary>
        /// 转换当前按键信息
        /// </summary>
        /// <param name="uVirtKey"></param>
        /// <param name="uScanCode"></param>
        /// <param name="lpbKeyState"></param>
        /// <param name="lpwTransKey"></param>
        /// <param name="fuState"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int ToAscii(UInt32 uVirtKey, UInt32 uScanCode,
            byte[] lpbKeyState, byte[] lpwTransKey, UInt32 fuState);

        /// <summary>
        /// 获取按键状态
        /// </summary>
        /// <param name="pbKeyState"></param>
        /// <returns>非0表示成功</returns>
        [DllImport("user32.dll")]
        public static extern int GetKeyboardState(byte[] pbKeyState);

        [DllImport("user32.dll")]
        public static extern short GetKeyStates(int vKey);
        
        /// <summary>
        /// 合成一次击键事件。系统可使用这种合成的击键事件来产生WM_KEYUP或WM_KEYDOWN消息
        /// </summary>
        /// <param name="bVk"></param>
        /// <param name="bScan"></param>
        /// <param name="dwFlags"></param>
        /// <param name="dwExtraInfo"></param>
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        /// <summary>
        /// 获取当前鼠标位置
        /// </summary>
        /// <param name="lpPoint"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public extern static int GetCursorPos(ref WinEnum.POINT lpPoint);

        /// <summary>
        /// 安装钩子
        /// </summary>
        /// <param name="idHook"></param>
        /// <param name="lpfn"></param>
        /// <param name="hInstance"></param>
        /// <param name="threadId"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr SetWindowsHookEx(WinEnum.WH_Event_Hook_Type idHook,
            Func<int, Int32, IntPtr, int> lpfn,
            IntPtr pInstance, int threadId);

        /// <summary>
        /// 卸载钩子
        /// </summary>
        /// <param name="idHook"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(IntPtr pHookHandle);

        /// <summary>
        /// 传递钩子
        /// </summary>
        /// <param name="idHook"></param>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(IntPtr pHookHandle, int nCode,
            Int32 wParam, IntPtr lParam);


        /// <summary>
        /// 检索处理顶级窗口的类名和窗口名称匹配指定的字符串。
        /// 这个函数不搜索子窗口。
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 应用程序可以使用SetParent函数来设置弹出式窗口，层叠窗口或子窗口的父窗口。
        /// 新的窗口与窗口必须属于同一应用程序。
        /// </summary>
        /// <param name="hWndChild"></param>
        /// <param name="hWndNewParent"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        /// <summary>
        /// 获得指定窗口的有关信息，函数也获得在额外窗口内存中指定偏移位地址的32位度整型值
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
        public static extern long GetWindowLong(IntPtr hwnd, int nIndex);

        /// <summary>
        /// 该函数用来改变指定窗口的属性．函数也将指定的一个32位值设置在窗口的额外存储空间的指定偏移位置。
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="nIndex"></param>
        /// <param name="dwNewLong"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "SetWindowLongA", SetLastError = true)]
        public static extern long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);

        /// <summary>
        /// 改变一个子窗口，弹出式窗口或顶层窗口的尺寸，位置和Z序。
        /// 子窗口，弹出式窗口，及顶层窗口根据它们在屏幕上出现的顺序排序、
        /// 顶层窗口设置的级别最高，并且被设置为Z序的第一个窗口。
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="hWndInsertAfter"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="wFlags"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern long SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy, long wFlags);

        /// <summary>
        /// 改变指定窗口的位置和大小。
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="repaint"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

        /// <summary>
        /// 获取一个前台窗口的句柄（窗口与用户当前的工作）。
        /// 该系统分配给其他线程比它的前台窗口的线程创建一个稍微更高的优先级。
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetForegroundWindow();

        /// <summary>
        /// 确定当前焦点位于哪个控件上。
        /// 语法GetFocus ( )返回值GraphicObject。
        /// 函数执行成功时返回当前得到焦点控件的引用，发生错误时返回无效引用。
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetFocus();
    }
}
