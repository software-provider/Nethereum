﻿using System.Numerics;
using Nethereum.Hex.HexConvertors.Extensions;
using Xunit;

namespace Nethereum.Util.UnitTests
{
    public class ContractUtilTests
    {
        [Fact]
        public void ShouldCalculateContractAddress()
        {
            var adresss = "0x12890d2cce102216644c59daE5baed380d84830c";
            var nonce = 0;
            var expected = "0x243e72b69141f6af525a9a5fd939668ee9f2b354";
            var contractAddress = ContractUtils.CalculateContractAddress(adresss, new BigInteger(nonce));
            Assert.True(expected.IsTheSameAddress(contractAddress));
        }

        [Theory]
        [InlineData("0x0000000000000000000000000000000000000000", "0x0000000000000000000000000000000000000000000000000000000000000000", "0x00", "0x4D1A2e2bB4F88F0250f26Ffff098B0b30B26BF38")]
        [InlineData("0xdeadbeef00000000000000000000000000000000", "0x0000000000000000000000000000000000000000000000000000000000000000", "0x00", "0xB928f69Bb1D91Cd65274e3c79d8986362984fDA3")]
        [InlineData("0xdeadbeef00000000000000000000000000000000", "0x000000000000000000000000feed000000000000000000000000000000000000", "0x00", "0xD04116cDd17beBE565EB2422F2497E06cC1C9833")]
        [InlineData("0x0000000000000000000000000000000000000000", "0x0000000000000000000000000000000000000000000000000000000000000000", "0xdeadbeef", "0x70f2b2914A2a4b783FaEFb75f459A580616Fcb5e")]
        [InlineData("0x00000000000000000000000000000000deadbeef", "0x00000000000000000000000000000000000000000000000000000000cafebabe", "0xdeadbeef", "0x60f3f640a8508fC6a86d45DF051962668E1e8AC7")]
        [InlineData("0x00000000000000000000000000000000deadbeef", "0x00000000000000000000000000000000000000000000000000000000cafebabe", "0xdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeefdeadbeef", "0x1d8bfDC5D46DC4f61D6b6115972536eBE6A8854C")]
        [InlineData("0x0000000000000000000000000000000000000000", "0x0000000000000000000000000000000000000000000000000000000000000000", "0x", "0xE33C0C7F7df4809055C3ebA6c09CFe4BaF1BD9e0")]
        [InlineData("0x0000000000000000000000000000000000000000", "0x0000000000000000000000000000000000000000000000000000000000000000", "0x10", "0x009e70d175875dc30988ee96ea16d3eadbd36df8")]
        public void ShouldCalculateCreate2Address(string address, string salt, string byteCode, string expected)
        {
            var contractAddress = ContractUtils.CalculateCreate2Address(address, salt, byteCode);
            Assert.True(expected.IsTheSameAddress(contractAddress));
        }
    }
}