﻿using System;
using System.Threading.Tasks;
using Nethereum.Signer;
using Nethereum.Siwe.Core;
using Nethereum.Util;
using Xunit;

namespace Nethereum.Siwe.UnitTests
{
    public class ServiceTests
    {
        [Fact]
        public async Task ShouldBuildANewMessageWithANewNonceAndValidateAfterSigning()
        {
            var domain = "login.xyz";
            var address = "0x12890d2cce102216644c59daE5baed380d84830c".ConvertToEthereumChecksumAddress();
            var statement = "Sign-In With Ethereum Example Statement";
            var uri = "https://login.xyz";
            var chainId = "1";
            var siweMessage = new SiweMessage();
            siweMessage.Domain = domain;
            siweMessage.Address = address;
            siweMessage.Statement = statement;
            siweMessage.Uri = uri;
            siweMessage.ChainId = chainId;
            siweMessage.SetExpirationTime(DateTime.Now.ToUniversalTime().AddHours(1));
            var service = new SiweMessageService(new InMemorySessionNonceStorage());
            var message = service.BuildMessageToSign(siweMessage);
            var messageSigner = new EthereumMessageSigner();
            var signature = messageSigner.EncodeUTF8AndSign(message,
                new EthECKey("0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7"));
  
            Assert.True(service.HasMessageDateStartedAndNotExpired(siweMessage));
            Assert.True(service.IsMessageTheSameAsSessionStored(siweMessage));
            Assert.True(await service.IsMessageSignatureValid(siweMessage, signature).ConfigureAwait(false));
            Assert.True(await service.IsValidMessage(siweMessage, signature).ConfigureAwait(false));
        }

        [Fact]
        public async Task ShouldBuildANewMessageWithANewNonceAndValidateAfterSigning_UsingInMemoryNonceManagement()
        {
            var domain = "login.xyz";
            var address = "0x12890d2cce102216644c59daE5baed380d84830c".ConvertToEthereumChecksumAddress();
            var statement = "Sign-In With Ethereum Example Statement";
            var uri = "https://login.xyz";
            var chainId = "1";
            var siweMessage = new SiweMessage();
            siweMessage.Domain = domain;
            siweMessage.Address = address;
            siweMessage.Statement = statement;
            siweMessage.Uri = uri;
            siweMessage.ChainId = chainId;
            siweMessage.SetExpirationTime(DateTime.Now.ToUniversalTime().AddHours(1));
            var service = new SiweMessageService(new InMemorySessionNonceStorage());
            var message = service.BuildMessageToSign(siweMessage);
            var messageSigner = new EthereumMessageSigner();
            var signature = messageSigner.EncodeUTF8AndSign(message,
                new EthECKey("0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7"));
            
            Assert.True(service.HasMessageDateStartedAndNotExpired(siweMessage));
            Assert.True(service.IsMessageTheSameAsSessionStored(siweMessage));
            Assert.True(await service.IsMessageSignatureValid(siweMessage, signature).ConfigureAwait(false));
            Assert.True(await service.IsValidMessage(siweMessage, signature).ConfigureAwait(false));
        }

    }
}