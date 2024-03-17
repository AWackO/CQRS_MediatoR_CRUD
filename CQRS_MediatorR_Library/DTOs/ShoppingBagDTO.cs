namespace CQRS_MediatorR_Library.DTOs;

public class ShoppingBagDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<GroceryDTO> Groceries { get; set; }
}
