using System.Text.Json.Serialization;

namespace DogApi.Model.Dto
{
    public class GetQueriedDogsResponse
    {
        [JsonPropertyName("attribute")]
        public string? Atribute { get; set; }

        [JsonPropertyName("order")]
        public string? Order { get; set; }

        [JsonPropertyName("pageNumber")]
        public int? PageNumber { get; set; }

        [JsonPropertyName("pageSize")]
        public int? PageSize { get; set; }
    }
}
