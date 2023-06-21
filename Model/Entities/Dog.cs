using Newtonsoft.Json;

namespace DogApi.Model.Entities
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Color { get; set; }
        public int? TailLength { get; set; }
        public int? Weight { get; set; }
    }
}
