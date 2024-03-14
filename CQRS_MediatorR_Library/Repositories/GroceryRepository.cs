using CQRS_MediatorR_Library.DbData;
using CQRS_MediatorR_Library.Models;
using CQRS_MediatorR_Library.Repositories;
using Microsoft.EntityFrameworkCore;

public class GroceryRepository : IGroceryRepository
{
    private readonly DataContext _data;

    public GroceryRepository(DataContext data)
    {
        _data = data;
    }

    public async Task<List<GroceryModel>> GetAllAsync()
    {
        return await _data.Groceries.ToListAsync();
    }

    public async Task<GroceryModel> GetByIdAsync(int id)
    {
        return await _data.Groceries.FindAsync(id);
    }

    public async Task<GroceryModel> AddAsync(GroceryModel entity)
    {
        _data.Groceries.Add(entity);
        await _data.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(GroceryModel entity)
    {
        _data.Entry(entity).State = EntityState.Modified;
        await _data.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _data.Groceries.FindAsync(id);
        if (entity != null)
        {
            _data.Groceries.Remove(entity);
            await _data.SaveChangesAsync();
        }
    }
}