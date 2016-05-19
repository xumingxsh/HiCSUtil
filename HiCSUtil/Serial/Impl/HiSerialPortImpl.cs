using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace HiCSUtil.Serial.Impl
{
    class HiSerialPortImpl
    {
        public static List<string> GetPorts()
        {
            List<string> lst = new List<string>();
            foreach (string port in SerialPort.GetPortNames())
            {
                lst.Add(port);
            }
            return lst;
        }

        public HiSerialPortImpl()
        {
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.Encoding = Encoding.UTF8;
            serialPort.DataReceived += ReceiveData;

            serialPort.ErrorReceived += (object sender, SerialErrorReceivedEventArgs e) => {
                HiLog.Error(string.Format("serial port({0}) receive a error type is:{1}", 
                    serialPort.PortName, e.EventType));
            };
            serialPort.PinChanged += (object sender, SerialPinChangedEventArgs e)=>{
            if (handler != null)
            {
                HiLog.Error(string.Format("serial port({0}) pin is change, script:{1}",
                    serialPort.PortName, e.EventType));
            }};
        }
        public bool Open(string port, int baud, HiSerialPortCallBack callBack)
        {
            if (callBack != null)
            {
                handler = callBack;
            }
            if (serialPort.PortName != null && serialPort.PortName.Equals(port))
            {
                if (serialPort.IsOpen)
                {
                    isOpen = true;
                    return true;
                }
                serialPort.BaudRate  = baud;
                serialPort.Open();
                HiLog.Debug(string.Format("serial port({0}) open", port));
                isOpen = true;
                return true;
            }
            if (serialPort.IsOpen)
            {
                Close();
            }
            serialPort.PortName = port;
            serialPort.BaudRate = baud;
            serialPort.Open();
            HiLog.Debug(string.Format("serial port({0}) open", port));
            isOpen = true;
            return true;
        }

        public bool IsOpen
        {
            get
            {
                return serialPort.IsOpen;
            }
        }

        public void Close()
        {
            serialPort.Close();
            isOpen = false;
            HiLog.Debug(string.Format("serial port({0}) close", serialPort.PortName));
        }

        /// <summary>
        /// 检查串口是否连接,如果未连接,则重新连接
        /// </summary>
        public void CheckState()
        {
            if (!isOpen || serialPort.IsOpen)
            {
                return;
            }
            serialPort.Open();
            HiLog.Debug(string.Format("serial port({0}) open", serialPort.PortName));
        }

        SerialPort serialPort = new SerialPort();
        public HiSerialPortCallBack handler = null;
        bool isOpen = false;

        private void ReceiveData(object sender, SerialDataReceivedEventArgs e)
        {
            if (handler == null)
            {
                return;
            }
            SerialPort port = sender as SerialPort;
            if (port == null)
            {
                return;
            }

            int length = port.BytesToRead;
            byte[] bytes = new byte[length];

            for (int i = 0; i < length; i++)
            {
                serialPort.Read(bytes, i, 1);
            }

            StringBuilder strb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                strb.Append(bytes[i].ToString());
            }
            handler(strb.ToString());
        }
    }
}
