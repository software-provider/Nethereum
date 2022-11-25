using System.Threading.Tasks;
using Nethereum.Geth.RPC.Debug.DTOs;
using Nethereum.JsonRpc.Client;
using Newtonsoft.Json.Linq;

namespace Nethereum.Geth.RPC.Debug
{
    /// <Summary>
    ///     The traceBlock method will return a full stack trace of all invoked opcodes of all transaction that were included
    ///     included in this block. Note, the parent of this block must be present or it will fail.
    /// </Summary>
    public class DebugTraceBlock : RpcRequestResponseHandler<JArray>, IDebugTraceBlock
    {
        public DebugTraceBlock(IClient client) : base(client, ApiMethods.debug_traceBlock.ToString())
        {
        }

        public RpcRequest BuildRequest(string blockRlpHex, TraceTransactionOptions options, object id = null)
        {
            return base.BuildRequest(id, blockRlpHex, options);
        }

        public Task<JArray> SendRequestAsync(string blockRlpHex, TraceTransactionOptions options, object id = null)
        {
            return base.SendRequestAsync(id, blockRlpHex, options);
        }
    }
}