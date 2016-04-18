using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCSUtil
{
    /// <summary>
    /// 日志处理类
    /// XuminRong 2016-04-18
    /// </summary>
    public static class HiLog
    {
        /// <summary>
        /// 日志枚举
        /// </summary>
        public enum LogType
        {
            LT_Info,
            LT_Debug,
            LT_Alarm,
            LT_Error
        }

        /// <summary>
        /// 日志实现委托
        /// </summary>
        /// <param name="script"></param>
        /// <param name="type"></param>
        public delegate void OnLOG(string script, LogType type);

        private static OnLOG onlog = null;

        /// <summary>
        /// 设置日志回调函数
        /// </summary>
        /// <param name="logfun"></param>
        public static void SetLogFun(OnLOG logfun)
        {
            onlog = logfun;
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="script"></param>
        /// <param name="type"></param>
        public static void Write(string script, LogType type = LogType.LT_Debug)
        {
            if (onlog != null)
            {
                onlog(script, type);
            }
        }

        /// <summary>
        /// 写调试日志
        /// </summary>
        /// <param name="script"></param>
        public static void Debug(string script)
        {
            Write(script, LogType.LT_Debug);
        }

        /// <summary>
        /// 写描述日志
        /// </summary>
        /// <param name="script"></param>
        public static void Info(string script)
        {
            Write(script, LogType.LT_Info);
        }

        /// <summary>
        /// 写报警日志
        /// </summary>
        /// <param name="script"></param>
        public static void Alarm(string script)
        {
            Write(script, LogType.LT_Alarm);
        }

        /// <summary>
        /// 写错误日志
        /// </summary>
        /// <param name="script"></param>
        public static void Error(string script)
        {
            Write(script, LogType.LT_Error);
        }
    }
}
