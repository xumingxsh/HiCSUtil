using System;

namespace HiCSUtil
{
    public  interface IWnd
    {
        /// <summary>
        /// 检索处理顶级窗口的类名和窗口名称匹配指定的字符串。这个函数不搜索子窗口。
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 应用程序可以使用SetParent函数来设置弹出式窗口，层叠窗口或子窗口的父窗口。
        /// 新的窗口与窗口必须属于同一应用程序。
        /// </summary>
        /// <param name="hWndChild"></param>
        /// <param name="hWndNewParent"></param>
        /// <returns></returns>
        long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        /// <summary>
        /// 该函数获得指定窗口的有关信息，函数也获得在额外窗口内存中指定偏移位地址的32位度整型值。
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        long GetWindowLong(IntPtr hwnd, int nIndex);

        /// <summary>
        /// 该函数用来改变指定窗口的属性．函数也将指定的一个32位值设置在窗口的额外存储空间的指定偏移位置。
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="nIndex"></param>
        /// <param name="dwNewLong"></param>
        /// <returns></returns>
        long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);

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
        long SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy, long wFlags);

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
        bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

        /// <summary>
        /// 获取一个前台窗口的句柄（窗口与用户当前的工作）。
        /// 该系统分配给其他线程比它的前台窗口的线程创建一个稍微更高的优先级。
        /// </summary>
        /// <returns></returns>
        int GetForegroundWindow();

        /// <summary>
        /// 确定当前焦点位于哪个控件上。
        /// 语法GetFocus ( )返回值GraphicObject。
        /// 函数执行成功时返回当前得到焦点控件的引用，发生错误时返回无效引用。
        /// </summary>
        /// <returns></returns>
        int GetFocus();
    }
}
