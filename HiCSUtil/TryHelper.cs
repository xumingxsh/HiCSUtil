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
        public delegate T ReturnCallBack<T>();
        public delegate void NoReturnCallBack();
        public static T OnTry<T>(ReturnCallBack<T> call)
        {
            try
            {
               T t= call();
               return (T)HiTypeHelper.ChangeType<T>(t);
            }
            catch (Exception ex)
            {
                HiLog.Error(ex.ToString());
                return (T)HiTypeHelper.GetMyDefault<T>();
            }
        }


        public static void OnTry(NoReturnCallBack call)
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
