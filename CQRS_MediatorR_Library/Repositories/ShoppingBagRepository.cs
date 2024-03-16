using CQRS_MediatorR_Library.Models;

namespace CQRS_MediatorR_Library.Repositories;

public interface IShoppingBagRepository
{
    Task<List<ShoppingBag>> GetAllAsync();
    Task<ShoppingBag> AddAsync(ShoppingBag shoppingBag);

    Task<ShoppingBag> GetByIdAsync(int id);
}