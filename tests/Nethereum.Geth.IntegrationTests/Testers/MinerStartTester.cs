using System;
using System.Threading.Tasks;
using Nethereum.Geth.RPC.Miner;
using Nethereum.JsonRpc.Client;
using Nethereum.RPC.Tests.Testers;
using Xunit; 
 // ReSharper disable ConsiderUsingConfigureAwait  
 // ReSharper disable AsyncConverter.ConfigureAwaitHighlighting

namespace Nethereum.Geth.Tests.Testers
{
    public class MinerStartTester : RPCRequestTester<bool>, IRPCRequestTester
    {
        public override async Task<bool> ExecuteAsync(IClient client)
        {
            var minerStart = new MinerStart(client);
            return await minerStart.SendRequestAsync().ConfigureAwait(false);
        }

        public override Type GetRequestType()
        {
            return typeof(MinerStart);
        }

        [Fact]
        public async void ShouldStartMiner()
        {
            var result = await ExecuteAsync().ConfigureAwait(false);
            Assert.True(result);
        }
    }
}