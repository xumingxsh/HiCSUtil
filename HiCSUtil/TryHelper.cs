using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCSUtil
{
    /// <summary>
    /// 异常处理辅助类
    /// 注: 该类主要帮助捕获异常,1) 写错误日志 2) 如果出错,返回默认的数据.
    /// 该功能可以由AOP实现,考虑到AOP太麻烦,故提供此类
    /// XuminRong 2016-06-03
    /// </summary>
    public sealed class TryHelper
    {
        /// <summary>
        /// 对函数添加异常处理
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="errBack">错误返回值</param>
        /// <param name="call">函数</param>
        /// <returns></returns>
        public static T OnTry<T>(T errBack, Func<T> call)
        {
            try
            {
               T t= call();
               return (T)HiTypeHelper.ChangeType<T>(t);
            }
            catch (Exception ex)
            {
                HiLog.Error(ex.ToString());
                return errBack;
            }
        }

        /// <summary>
        /// 对函数添加异常处理
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="errBack">错误返值</param>
        /// <param name="call">函数</param>
        /// <returns></returns>
        public static T OnTryEx<T>(T errBack, Func<object> call)
        {
            try
            {
                object t = call();
                if (t == null || t is DBNull)
                {
                    return errBack;
                }
                return (T)t;
            }
            catch (Exception ex)
            {
                HiLog.Error(ex.ToString());
                return errBack;
            }
        }

        /// <summary>
        /// 对函数添加异常处理(无返回值)
        /// </summary>
        /// <param name="call"></param>
        public static void OnTry(Action call)
        {
            try
            {
                call();
            }
            catch (Exception ex)
            {
                HiLog.Error(ex.ToString());
            }
        }
    }
}
