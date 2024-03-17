using System.Text.Json.Serialization;

namespace CQRS_MediatorR_Library.Models;

public class ShoppingBag
{
    public static ShoppingBag FromGroceries(int id, string name, List<GroceryModel> groceries)
    {
        return new ShoppingBag
        {
            Id = id,
            Name = name,
            Groceries = groceries.OrderBy(g => g.Name).ToList()
        };
    }

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
