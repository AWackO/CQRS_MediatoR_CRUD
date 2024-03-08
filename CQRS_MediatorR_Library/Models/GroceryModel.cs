
using System.Text.Json.Serialization;

namespace CQRS_MediatorR_Library.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Types
    {
        Fruit,
        Vegetable,
        Meat,
        Drink,
    }

    public class GroceryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Types ProductType { get; set; }
    }
}
