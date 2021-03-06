﻿using System.Threading.Tasks;
using WampSharp.V2.CalleeProxy;
using WampSharp.V2.Client;

namespace WampSharp.V2.Testament.Client
{
    //------------------------------------------------------------------------------
    // <auto-generated>
    //     This code was generated by a tool.
    //
    //     Changes to this file may cause incorrect behavior and will be lost if
    //     the code is regenerated.
    // </auto-generated>
    //------------------------------------------------------------------------------
    internal class WampTestamentServiceProxy : CalleeProxyBase, global::WampSharp.V2.Testament.Client.IWampTestamentServiceProxy
    {
        private static readonly InvokeSyncDelegate<object> mMethodHandler0 = GetInvokeSync<object>(
            GetMethodInfo((global::WampSharp.V2.Testament.Client.IWampTestamentServiceProxy instance) => instance.AddTestament(default(string), default(object[]), default(global::System.Collections.Generic.IDictionary<string, object>)))
        );
        private static readonly InvokeSyncDelegate<object> mMethodHandler1 = GetInvokeSync<object>(
            GetMethodInfo((global::WampSharp.V2.Testament.Client.IWampTestamentServiceProxy instance) => instance.AddTestament(default(string), default(object[]), default(global::System.Collections.Generic.IDictionary<string, object>), default(global::WampSharp.V2.Core.Contracts.PublishOptions)))
        );
        private static readonly InvokeSyncDelegate<object> mMethodHandler2 = GetInvokeSync<object>(
            GetMethodInfo((global::WampSharp.V2.Testament.Client.IWampTestamentServiceProxy instance) => instance.AddTestament(default(string), default(object[]), default(global::System.Collections.Generic.IDictionary<string, object>), default(global::WampSharp.V2.Core.Contracts.PublishOptions), default(string)))
        );
        private static readonly InvokeSyncDelegate<int> mMethodHandler3 = GetInvokeSync<int>(
            GetMethodInfo((global::WampSharp.V2.Testament.Client.IWampTestamentServiceProxy instance) => instance.FlushTestaments())
        );
        private static readonly InvokeSyncDelegate<int> mMethodHandler4 = GetInvokeSync<int>(
            GetMethodInfo((global::WampSharp.V2.Testament.Client.IWampTestamentServiceProxy instance) => instance.FlushTestaments(default(string)))
        );
        private static readonly InvokeAsyncDelegate<object> mMethodHandler5 = GetInvokeAsync<object>(
            GetMethodInfo((global::WampSharp.V2.Testament.Client.IWampTestamentServiceProxy instance) => instance.AddTestamentAsync(default(string), default(object[]), default(global::System.Collections.Generic.IDictionary<string, object>)))
        );
        private static readonly InvokeAsyncDelegate<object> mMethodHandler6 = GetInvokeAsync<object>(
            GetMethodInfo((global::WampSharp.V2.Testament.Client.IWampTestamentServiceProxy instance) => instance.AddTestamentAsync(default(string), default(object[]), default(global::System.Collections.Generic.IDictionary<string, object>), default(global::WampSharp.V2.Core.Contracts.PublishOptions)))
        );
        private static readonly InvokeAsyncDelegate<object> mMethodHandler7 = GetInvokeAsync<object>(
            GetMethodInfo((global::WampSharp.V2.Testament.Client.IWampTestamentServiceProxy instance) => instance.AddTestamentAsync(default(string), default(object[]), default(global::System.Collections.Generic.IDictionary<string, object>), default(global::WampSharp.V2.Core.Contracts.PublishOptions), default(string)))
        );
        private static readonly InvokeAsyncDelegate<int> mMethodHandler8 = GetInvokeAsync<int>(
            GetMethodInfo((global::WampSharp.V2.Testament.Client.IWampTestamentServiceProxy instance) => instance.FlushTestamentsAsync())
        );
        private static readonly InvokeAsyncDelegate<int> mMethodHandler9 = GetInvokeAsync<int>(
            GetMethodInfo((global::WampSharp.V2.Testament.Client.IWampTestamentServiceProxy instance) => instance.FlushTestamentsAsync(default(string)))
        );

        public WampTestamentServiceProxy
        (IWampRealmProxy realmProxy,
         ICalleeProxyInterceptor interceptor)
            : base(realmProxy, interceptor)
        {
        }

        public void AddTestament(string topic, object[] args, global::System.Collections.Generic.IDictionary<string, object> kwargs)
        {
            mMethodHandler0(this, topic, args, kwargs);
        }

        public void AddTestament(string topic, object[] args, global::System.Collections.Generic.IDictionary<string, object> kwargs, global::WampSharp.V2.Core.Contracts.PublishOptions publish_options)
        {
            mMethodHandler1(this, topic, args, kwargs, publish_options);
        }

        public void AddTestament(string topic, object[] args, global::System.Collections.Generic.IDictionary<string, object> kwargs, global::WampSharp.V2.Core.Contracts.PublishOptions publish_options, string scope)
        {
            mMethodHandler2(this, topic, args, kwargs, publish_options, scope);
        }

        public int FlushTestaments()
        {
            return mMethodHandler3(this);
        }

        public int FlushTestaments(string scope)
        {
            return mMethodHandler4(this, scope);
        }

        public Task AddTestamentAsync(string topic, object[] args, global::System.Collections.Generic.IDictionary<string, object> kwargs)
        {
            return mMethodHandler5(this, global::System.Threading.CancellationToken.None, topic, args, kwargs);
        }

        public Task AddTestamentAsync(string topic, object[] args, global::System.Collections.Generic.IDictionary<string, object> kwargs, global::WampSharp.V2.Core.Contracts.PublishOptions publish_options)
        {
            return mMethodHandler6(this, global::System.Threading.CancellationToken.None, topic, args, kwargs, publish_options);
        }

        public Task AddTestamentAsync(string topic, object[] args, global::System.Collections.Generic.IDictionary<string, object> kwargs, global::WampSharp.V2.Core.Contracts.PublishOptions publish_options, string scope)
        {
            return mMethodHandler7(this, global::System.Threading.CancellationToken.None, topic, args, kwargs, publish_options, scope);
        }

        public Task<int> FlushTestamentsAsync()
        {
            return mMethodHandler8(this, global::System.Threading.CancellationToken.None);
        }

        public Task<int> FlushTestamentsAsync(string scope)
        {
            return mMethodHandler9(this, global::System.Threading.CancellationToken.None, scope);
        }
    }
}