using System;
using System.Threading.Tasks;
using Nethereum.Geth.RPC.Debug;
using Nethereum.JsonRpc.Client;
using Nethereum.RPC.Tests.Testers;
using Newtonsoft.Json.Linq;
using Xunit; 
 // ReSharper disable ConsiderUsingConfigureAwait  
 // ReSharper disable AsyncConverter.ConfigureAwaitHighlighting

namespace Nethereum.Geth.Tests.Testers
{
    public class DebugGcStatsTester : RPCRequestTester<JObject>, IRPCRequestTester
    {
        public override async Task<JObject> ExecuteAsync(IClient client)
        {
            var debugGcStats = new DebugGcStats(client);
            return await debugGcStats.SendRequestAsync().ConfigureAwait(false);
        }

        public override Type GetRequestType()
        {
            return typeof(DebugGcStats);
        }

        [Fact]
        public async void ShouldReturnTheGcStatsAsJObject()
        {
            var result = await ExecuteAsync().ConfigureAwait(false);
            Assert.NotNull(result);
        }
    }
}