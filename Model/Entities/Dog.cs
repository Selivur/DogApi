using Newtonsoft.Json;

namespace DogApi.Model.Entities
{
    public class Dog
    {
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("color")]
        public string? Color { get; set; }
        [JsonProperty("tail_length")]
        public int? TailLength { get; set; }
        [JsonProperty("weight")]
        public int? Weight { get; set; }
    }
}
