using Newtonsoft.Json;

namespace TestAPI
{
    public class Car
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("make")]
        public string Make { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
    }
}
