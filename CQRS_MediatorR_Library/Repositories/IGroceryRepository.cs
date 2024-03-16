using CQRS_MediatorR_Library.Models;

namespace CQRS_MediatorR_Library.Repositories;

public interface IGroceryRepository
{
    Task<List<GroceryModel>> GetAllAsync();
    Task<GroceryModel> GetByIdAsync(int id);
    Task<GroceryModel> AddAsync(GroceryModel entity);
    Task UpdateAsync(GroceryModel entity);
    Task DeleteAsync(int id);

}