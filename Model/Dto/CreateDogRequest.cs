using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DogApi.Model.Dto
{
    public class CreateDogRequest
    {
        [Required(ErrorMessage = "Name is required")]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Color is required")]
        [JsonPropertyName("color")]
        public string Color { get; set; }

        [Range(0, 100, ErrorMessage = "Tail height cannot be a negative number or greater than 100cm")]
        [Required(ErrorMessage = "TailLength is required")]
        [JsonPropertyName("tail_length")]
        public int TailLength { get; set; }
        [Required(ErrorMessage = "Weight is required")]
        [JsonPropertyName("weight")]
        public int Weight { get; set; }
    }
}
