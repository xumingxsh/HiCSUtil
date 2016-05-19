using System;
using System.Collections.Generic;
using HiCSUtil.Serial.Impl;

namespace HiCSUtil
{
    /// <summary>
    /// 串口消息回调接口
    /// </summary>
    /// <param name="text"></param>
    public delegate void HiSerialPortCallBack(string text);

    /// <summary>
    /// 串口读取辅助类
    /// </summary>
    public sealed class HiSerialPort
    {
        public HiSerialPort()
        {
        }

        /// <summary>
        /// 获取机器的所有串口
        /// </summary>
        /// <returns></returns>
        public static List<string> GetPorts()
        {
            return HiSerialPortImpl.GetPorts();
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="port">串口</param>
        /// <param name="baud">波特率</param>
        /// <param name="callBack">回调函数</param>
        /// <returns>是否成功</returns>
        public bool Open(string port, int baud, HiSerialPortCallBack callBack = null)
        {
            if (string.IsNullOrWhiteSpace(port) || baud < 1)
            {
                return false;
            }
            return impl.Open(port, baud, callBack);
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Close()
        {
            impl.Close();
        }

        HiCSUtil.Serial.Impl.HiSerialPortImpl impl = new Serial.Impl.HiSerialPortImpl();
    }
}
