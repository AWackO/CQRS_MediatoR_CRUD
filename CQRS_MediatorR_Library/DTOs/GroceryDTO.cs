using CQRS_MediatorR_Library.Models;

namespace CQRS_MediatorR_Library.DTOs;

public class GroceryDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Types ProductType { get; set; }
}
