using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Reservation
    {
        [JsonProperty("vendor")]
        public string Vendor { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }
    }
}
