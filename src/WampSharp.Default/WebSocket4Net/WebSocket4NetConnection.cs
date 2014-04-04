﻿using System;
using SuperSocket.ClientEngine;
using WampSharp.Core.Listener;
using WampSharp.Core.Message;
using WampSharp.V2.Core.Listener;
using WebSocket4Net;

namespace WampSharp.WebSocket4Net
{
    public abstract class WebSocket4NetConnection<TMessage> : IControlledWampConnection<TMessage>
    {
        #region Fields

        private readonly IWampBinding<TMessage> mBinding;

        private readonly WebSocket mWebSocket;
        
        #endregion

        public WebSocket4NetConnection(string serverAddress,
                                       IWampBinding<TMessage> binding)
        {
            mBinding = binding;
            mWebSocket = new WebSocket(serverAddress, binding.Name);
            mWebSocket.Opened += WebSocketOnOpened;
            mWebSocket.Closed += WebSocketOnClosed;
            mWebSocket.Error += WebSocketOnError;
        }

        public IWampBinding<TMessage> Binding
        {
            get
            {
                return mBinding;
            }
        }

        protected WebSocket WebSocket
        {
            get
            {
                return mWebSocket;
            }
        }


        private void WebSocketOnOpened(object sender, EventArgs eventArgs)
        {
            RaiseConnectionOpen();
        }

        private void WebSocketOnClosed(object sender, EventArgs eventArgs)
        {
            RaiseConnectionClosed();
        }

        private void WebSocketOnError(object sender, ErrorEventArgs e)
        {
            RaiseConnectionClosed();
        }

        public void Connect()
        {
            mWebSocket.Open();
        }

        public virtual void Dispose()
        {
            mWebSocket.Close();
        }

        public abstract void Send(WampMessage<TMessage> message);

        public event EventHandler ConnectionOpen;

        public event EventHandler<WampMessageArrivedEventArgs<TMessage>> MessageArrived;

        public event EventHandler ConnectionClosed;

        protected virtual void RaiseMessageArrived(WampMessage<TMessage> message)
        {
            EventHandler<WampMessageArrivedEventArgs<TMessage>> handler = MessageArrived;
            
            if (handler != null)
            {
                WampMessageArrivedEventArgs<TMessage> eventArgs = new WampMessageArrivedEventArgs<TMessage>(message);
                handler(this, eventArgs);
            }
        }
        
        protected virtual void RaiseConnectionOpen()
        {
            EventHandler handler = ConnectionOpen;
            
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void RaiseConnectionClosed()
        {
            EventHandler handler = ConnectionClosed;
            
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}