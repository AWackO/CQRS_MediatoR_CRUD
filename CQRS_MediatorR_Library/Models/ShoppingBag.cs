using System.Text.Json.Serialization;

namespace CQRS_MediatorR_Library.Models;

public class ShoppingBag
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Sizes
    {
        S,
        M,
        L
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public Sizes? Size { get; set; }
    public List<GroceryModel>? Groceries { get; set; }
}
