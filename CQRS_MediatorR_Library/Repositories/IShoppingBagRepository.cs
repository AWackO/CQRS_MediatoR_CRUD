using CQRS_MediatorR_Library.DbData;
using CQRS_MediatorR_Library.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_MediatorR_Library.Repositories;

public class ShoppingBagRepository : IShoppingBagRepository
{
    private readonly DataContext _data;

    public ShoppingBagRepository(DataContext data)
    {
        _data = data;
    }

    public async Task<List<ShoppingBag>> GetAllAsync()
    {
        return await _data.ShoppingBags.ToListAsync();
    }

    public async Task<ShoppingBag> AddAsync(ShoppingBag shoppingBag)
    {
        _data.ShoppingBags.Add(shoppingBag);
        await _data.SaveChangesAsync();
        return shoppingBag;
    }

    public async Task<ShoppingBag> GetByIdAsync(int id)
    {
        return await _data.ShoppingBags
            .Include(sb => sb.GroceryModels)
            .FirstOrDefaultAsync(sb => sb.Id == id);
    }
}
