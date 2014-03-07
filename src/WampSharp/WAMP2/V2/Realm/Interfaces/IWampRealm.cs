﻿using WampSharp.V2.Core.Contracts;
using WampSharp.V2.PubSub;
using WampSharp.V2.Rpc;

namespace WampSharp.V2.Realm
{
    // TODO: Realms should be message type (TMessage) free.
    public interface IWampRealm<TMessage> where TMessage : class
    {
        string Name { get; }

        IWampRpcOperationCatalog<TMessage> RpcCatalog { get; }

        IWampTopicContainer TopicContainer { get; }

        // TODO: Internal mechanism, should not be here.
        IWampServer<TMessage> Server { get; }
    }
}