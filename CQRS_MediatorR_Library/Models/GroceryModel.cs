
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
        public string Name { get; set; } // Removed "required" keyword as it's not valid here
        public Types ProductType { get; set; }
        public int ShoppingBagId { get; set; }
        public ShoppingBag ShoppingBag { get; set; }
    }
}
