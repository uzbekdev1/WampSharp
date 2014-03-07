using WampSharp.Core.Contracts;
using WampSharp.Core.Message;

namespace WampSharp.V2.Core.Contracts
{
    public interface IWampSessionServer<TMessage> where TMessage : class
    {
        [WampHandler(WampMessageType.v2Hello)]
        void Hello([WampProxyParameter]IWampSessionClient client, string realm, TMessage details);

        [WampHandler(WampMessageType.v2Authenticate)]
        void Authenticate([WampProxyParameter]IWampSessionClient client, string signature, TMessage extra);

        [WampHandler(WampMessageType.v2Welcome)]
        void Welcome([WampProxyParameter]IWampSessionClient client, long session, TMessage details);

        [WampHandler(WampMessageType.v2Goodbye)]
        void Goodbye([WampProxyParameter]IWampSessionClient client, string reason, TMessage details);

        [WampHandler(WampMessageType.v2Heartbeat)]
        void Heartbeat([WampProxyParameter]IWampSessionClient client, int incomingSeq, int outgoingSeq);

        [WampHandler(WampMessageType.v2Heartbeat)]
        void Heartbeat([WampProxyParameter]IWampSessionClient client, int incomingSeq, int outgoingSeq, string discard);

        // Note: Not a WAMP message
        void OnNewClient(IWampClient<TMessage> client);
    }
}