using System;
using HiCSUtil;

namespace HiCSUtil.Win32.Impl
{
    partial class WinAll
    {
        public int ToAscii(UInt32 uVirtKey, UInt32 uScanCode,
              byte[] lpbKeyState, byte[] lpwTransKey, UInt32 fuState)
        {
            return HiWin32API.ToAscii(uVirtKey, uScanCode, lpbKeyState, lpwTransKey, fuState);
        }

        public int GetKeyboardState(byte[] pbKeyState)
        {
            return HiWin32API.GetKeyboardState(pbKeyState);
        }

        public short GetKeyStates(int vKey)
        {
            return HiWin32API.GetKeyStates(vKey);
        }

        public int GetCursorPos(ref WinEnum.POINT lpPoint)
        {
            return HiWin32API.GetCursorPos(ref lpPoint);
        }

        public void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo)
        {
            HiWin32API.keybd_event(bVk, bScan, dwFlags, dwExtraInfo);
        }

        public int AttachThreadInput(int idAttach, int idAttachTo, int fAttach)
        {
            return HiWin32API.AttachThreadInput(idAttach, idAttachTo, fAttach);
        }
    }
}
