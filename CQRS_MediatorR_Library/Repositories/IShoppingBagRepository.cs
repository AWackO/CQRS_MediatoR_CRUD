using AutoMapper;
using CQRS_MediatorR_Library.DbData;
using CQRS_MediatorR_Library.DTOs;
using CQRS_MediatorR_Library.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_MediatorR_Library.Repositories;

public class ShoppingBagRepository : IShoppingBagRepository
{
    private readonly DataContext _data;
    private readonly IMapper _mapper;
    public ShoppingBagRepository(DataContext data, IMapper mapper)
    {
        _data = data;
        _mapper = mapper;
    }

    public async Task<List<ShoppingBag>> GetAllAsync()
    {
        return await _data.ShoppingBags
            .Include(sb => sb.Groceries)
            .ToListAsync();
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
            .Include(sb => sb.Groceries)
            .FirstOrDefaultAsync(sb => sb.Id == id);
    }

    public async Task<List<ShoppingBagDTO>> GetShoppingBagWith2OrMoreMeatsOnly(Types productType, int minItemCount)
    {
        var shoppingBags = await _data.ShoppingBags
                .Include(sb => sb.Groceries)
                .Where(sb => sb.Groceries.Count(g => g.ProductType == productType) >= minItemCount)
                .Select(sb => ShoppingBag.FromGroceries(sb.Id, sb.Name, sb.Groceries))
                .ToListAsync();

        return _mapper.Map<List<ShoppingBagDTO>>(shoppingBags);
    }
}
