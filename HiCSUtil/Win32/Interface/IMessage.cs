using System;

namespace HiCSUtil
{
    public interface IMessage
    {        
        bool PostMessage(IntPtr hwnd, uint Msg, long wParam, long lParam);
        int PostMessage(int hwnd, int wMsg, int wParam, int lParam);
        int SendMessage(int hwnd, int wMsg, int wParam, int lParam);
    }
}
