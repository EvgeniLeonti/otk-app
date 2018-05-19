using Newtonsoft.Json;

namespace otk
{
    public class UserItem
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "challenge1")]
        public string Challenge1 { get; set; }

        [JsonProperty(PropertyName = "challenge2")]
        public string Challenge2 { get; set; }

        [JsonProperty(PropertyName = "challenge3")]
        public string Challenge3 { get; set; }
    }
}

