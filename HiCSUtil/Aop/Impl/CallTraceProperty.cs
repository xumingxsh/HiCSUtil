using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Activation;

namespace HiCSUtil
{
    public class CallTraceProperty : IContextProperty, IContributeObjectSink
    {
        private OnProcessHandle evt = null;
        public CallTraceProperty(OnProcessHandle handle)
        {
            evt = handle;
        }

        //IContributeObjectSink的接口方法，实例化消息接收器
        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink next)
        {
            return new CallTraceSink(next, evt);
        }

        //IContextProperty接口方法，如果该方法返回ture,在新的上下文环境中激活对象
        public bool IsNewContextOK(Context newCtx)
        {
            return true;
        }

        //IContextProperty接口方法，提供高级使用
        public void Freeze(Context newCtx)
        {
        }

        //IContextProperty接口属性
        public string Name
        {
            get { return "MethodTrace"; }
        }
    }
}
