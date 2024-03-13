namespace CQRS_MediatorR_Library.Repositories;

using CQRS_MediatorR_Library.DbData;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class GroceryRepository<TEntity> : IGroceryRepository<TEntity> where TEntity : class
{
    private readonly DataContext _data;

    public GroceryRepository(DataContext data)
    {
        _data = data;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _data.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(object id)
    {
        return await _data.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _data.Set<TEntity>().AddAsync(entity);
        await _data.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _data.Set<TEntity>().Update(entity);
        await _data.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _data.Set<TEntity>().Remove(entity);
        await _data.SaveChangesAsync();
    }
}

