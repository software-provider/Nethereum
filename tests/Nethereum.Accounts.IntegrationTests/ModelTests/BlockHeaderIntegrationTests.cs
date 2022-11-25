﻿using System.Linq;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Hex.HexTypes;
using Nethereum.Model;
using Nethereum.RPC.ModelFactories;
using Nethereum.Signer;
using Nethereum.Util;
using Nethereum.XUnitEthereumClients;
using Xunit;

namespace Nethereum.Accounts.IntegrationTests
{
    //TODO:This needs to be moved to a custom testing library
    [Collection(EthereumClientIntegrationFixture.ETHEREUM_CLIENT_COLLECTION_DEFAULT)]
    public class BlockHeaderIntegrationTests
    {

        private readonly EthereumClientIntegrationFixture _ethereumClientIntegrationFixture;

        public BlockHeaderIntegrationTests(EthereumClientIntegrationFixture ethereumClientIntegrationFixture)
        {
            _ethereumClientIntegrationFixture = ethereumClientIntegrationFixture;
        }

        //[Fact]
        //public async void ShouldDecodeCliqueAuthor()
        //{
     
        //    var web3 = _ethereumClientIntegrationFixture.GetWeb3();
        //    var block =
        //        await web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(new HexBigInteger(1)).ConfigureAwait(false);
        //    var blockHeader = BlockHeaderRPCFactory.FromRPC(block, true);
        //    var account = new CliqueBlockHeaderRecovery().RecoverCliqueSigner(blockHeader, false);
        //    Assert.True(EthereumClientIntegrationFixture.AccountAddress.IsTheSameAddress(account));

        //}

        //[Fact]
        //public async void ShouldDecodeGoerliCliqueAuthor()
        //{

        //    var web3 = _ethereumClientIntegrationFixture.GetInfuraWeb3(InfuraNetwork.Goerli);
        //    var block =
        //        await web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(new HexBigInteger(5514521)).ConfigureAwait(false);
        //    var blockHeader = BlockHeaderRPCFactory.FromRPC(block, true);
        //    var account = new CliqueBlockHeaderRecovery().RecoverCliqueSigner(blockHeader, false);
        //    Assert.True("0x000000568b9b5a365eaa767d42e74ed88915c204".IsTheSameAddress(account));

        //}

        


        [Fact]
        public async void ShouldEncodeDecode()
        {
            var web3 = _ethereumClientIntegrationFixture.GetWeb3();
                var block =
                    await web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(new HexBigInteger(1)).ConfigureAwait(false);
            var blockHeader = BlockHeaderRPCFactory.FromRPC(block);

            var encoded = BlockHeaderEncoder.Current.Encode(blockHeader);
            var decoded = BlockHeaderEncoder.Current.Decode(encoded);

            Assert.Equal(blockHeader.StateRoot.ToHex(), decoded.StateRoot.ToHex());
            Assert.Equal(blockHeader.LogsBloom.ToHex(), decoded.LogsBloom.ToHex());
            Assert.Equal(blockHeader.MixHash.ToHex(), decoded.MixHash.ToHex());
            Assert.Equal(blockHeader.ReceiptHash.ToHex(), decoded.ReceiptHash.ToHex());
            Assert.Equal(blockHeader.Difficulty, decoded.Difficulty);
            Assert.Equal(blockHeader.BaseFee, decoded.BaseFee);
        }

    }
}