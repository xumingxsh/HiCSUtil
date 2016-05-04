using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Activation;


namespace HiCSUtil
{
    public class CallTraceSink : IMessageSink 
    {
        private IMessageSink nextSink;  //保存下一个接收器

        private OnProcessHandle evt = null;

        //在构造器中初始化下一个接收器
        public CallTraceSink(IMessageSink next, OnProcessHandle handle)
        {
            nextSink = next;
            evt = handle;
        }

        //必须实现的IMessageSink接口属性
        public IMessageSink NextSink
        {
            get
            {
                return nextSink;
            }
        }

        //实现IMessageSink的接口方法，当消息传递的时候，该方法被调用
        public IMessage SyncProcessMessage(IMessage msg)
        {
            IMethodCallMessage call = msg as IMethodCallMessage;
            IMessage retMsg = null;
            //if (evt != null)
            //{
            //    retMsg = evt(nextSink, call);
            //}
            //else
            //{
            //    retMsg = nextSink.SyncProcessMessage(call);
            //}
            return retMsg;
        }

        //IMessageSink接口方法，用于异步处理，我们不实现异步处理，所以简单返回null,
        //不管是同步还是异步，这个方法都需要定义
        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            return null;
        }
    }
}
