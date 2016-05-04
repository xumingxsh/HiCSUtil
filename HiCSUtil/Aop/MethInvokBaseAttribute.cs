using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Services;

namespace HiCSUtil
{
    public delegate IMethodReturnMessage OnExecuteHandle();

    /// <summary>
    /// 方法执行前的处理
    /// </summary>
    /// <param name="call"></param>
    public delegate IMethodReturnMessage OnProcessHandle(IMethodCallMessage msg, OnExecuteHandle evt);

    /// <summary>
    /// 方法AOP定制特性
    /// 用于添加日志,事务等
    /// </summary>
    public class MethInvokBaseAttribute : ProxyAttribute
    {
        private readonly MarshalByRefObject target;
        public OnProcessHandle Handle { set; get; }

        /*
        //得到透明代理
        public override MarshalByRefObject CreateInstance(Type serverType)
        {
            //未初始化的实例
            MarshalByRefObject target = base.CreateInstance(serverType);
            InterceptProxy rp = new InterceptProxy(target, serverType);
            rp.Handle = Handle;
            return (MarshalByRefObject)rp.GetTransparentProxy();
        }*/

        public override RealProxy CreateProxy(ObjRef objRef, Type serverType, object serverObject, Context serverContext)
        {
            InterceptProxy rp = new InterceptProxy(target, serverType);
            rp.Handle = Handle;
            return rp;
        }
    }
}
