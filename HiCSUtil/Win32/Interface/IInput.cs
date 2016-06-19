using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiCSUtil
{
    public interface IInput
    {
        /// <summary>
        /// 转换当前按键信息
        /// </summary>
        /// <param name="uVirtKey"></param>
        /// <param name="uScanCode"></param>
        /// <param name="lpbKeyState"></param>
        /// <param name="lpwTransKey"></param>
        /// <param name="fuState"></param>
        /// <returns></returns>
        int ToAscii(UInt32 uVirtKey, UInt32 uScanCode,
              byte[] lpbKeyState, byte[] lpwTransKey, UInt32 fuState);

        /// <summary>
        /// 获取按键状态
        /// </summary>
        /// <param name="pbKeyState"></param>
        /// <returns>非0表示成功</returns>
        int GetKeyboardState(byte[] pbKeyState);

        short GetKeyStates(int vKey);

        /// <summary>
        /// 获取当前鼠标位置
        /// </summary>
        /// <param name="lpPoint"></param>
        /// <returns></returns>
        int GetCursorPos(ref WinEnum.POINT lpPoint);

        /// <summary>
        /// 合成一次击键事件。系统可使用这种合成的击键事件来产生WM_KEYUP或WM_KEYDOWN消息
        /// </summary>
        /// <param name="bVk"></param>
        /// <param name="bScan"></param>
        /// <param name="dwFlags"></param>
        /// <param name="dwExtraInfo"></param>
        void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

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
        int AttachThreadInput(int idAttach, int idAttachTo, int fAttach);
    }
}
