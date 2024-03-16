namespace CQRS_MediatorR_Library.Models;

public class ShoppingBag
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<GroceryModel> GroceryModels { get; set; } = new();
}
