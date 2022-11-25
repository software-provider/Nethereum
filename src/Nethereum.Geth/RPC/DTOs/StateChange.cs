using System.Runtime.Serialization;
using Nethereum.Hex.HexTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nethereum.Geth.RPC.DTOs
{

    public class StateChange

    {
        /// <summary>
        /// Fake balance to set for the account before executing the call.
        /// </summary>
        [JsonProperty(PropertyName = "balance")]
        public HexBigInteger Balance { get; set; }
        /// <summary>
        /// Fake nonce to set for the account before executing the call.
        /// </summary>
        [JsonProperty(PropertyName = "nonce")]
        public HexBigInteger Nonce { get; set; }
        /// <summary>
        /// Fake EVM bytecode to inject into the account before executing the call.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Fake key-value mapping to override all slots in the account storage before executing the call.
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public JObject State { get; set; }

        /// <summary>
        /// Fake key-value mapping to override individual slots in the account storage before executing the call.
        /// </summary>
        [JsonProperty(PropertyName = "stateDiff")]
        public JObject StateDiff { get; set; }
    }
}