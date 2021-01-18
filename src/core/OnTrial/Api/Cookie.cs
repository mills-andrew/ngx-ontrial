using Newtonsoft.Json;

namespace OnTrial.Api
{
    public class Cookie
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("domain", NullValueHandling = NullValueHandling.Ignore)]
        public string Domain { get; set; }

        [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
        public string Path { get; set; }

        [JsonProperty("secure")]
        public virtual bool Secure => false;

        [JsonProperty("httpOnly")]
        public virtual bool IsHttpOnly => false;

        [JsonProperty("expiry", NullValueHandling = NullValueHandling.Ignore)]
        public long? Expiry { get; set; }

        public Cookie(string pName, string pValue)
        {
            this.Name = pName;
            this.Value = pValue;
        }
    }
}
