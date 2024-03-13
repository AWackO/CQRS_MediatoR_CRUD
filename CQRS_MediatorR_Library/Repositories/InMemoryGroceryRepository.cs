using CQRS_MediatorR_Library.Models;

namespace CQRS_MediatorR_Library.Repositories;

public class InMemoryGroceryRepository : IGroceryRepository<GroceryModel>
{
    private readonly List<GroceryModel> _shoppingCart;

    public InMemoryGroceryRepository()
    {
        _shoppingCart = new List<GroceryModel>
        {
            new GroceryModel { Id = 1, Name = "Apple", ProductType = Types.Fruit },
            new GroceryModel { Id = 2, Name = "Cucumber", ProductType = Types.Vegetable },
            new GroceryModel { Id = 3, Name = "Coca Cola", ProductType = Types.Drink }
        };
    }

    public Task<List<GroceryModel>> GetAllAsync()
    {
        return Task.FromResult(_shoppingCart);
    }

    public Task<GroceryModel> GetByIdAsync(object id)
    {
        var itemId = (int)id;
        var grocery = _shoppingCart.FirstOrDefault(item => item.Id == itemId);
        return Task.FromResult(grocery);
    }

    public Task<GroceryModel> AddAsync(GroceryModel entity)
    {
        entity.Id = _shoppingCart.Any() ? _shoppingCart.Max(x => x.Id) + 1 : 1;
        _shoppingCart.Add(entity);
        return Task.FromResult(entity);
    }

    public Task UpdateAsync(GroceryModel entity)
    {
        var existingItem = _shoppingCart.FirstOrDefault(item => item.Id == entity.Id);

        if (existingItem != null)
        {
            existingItem.Name = entity.Name;
            existingItem.ProductType = entity.ProductType;
        }
        else
        {
            throw new KeyNotFoundException($"Grocery item with id {entity.Id} not found.");
        }

        return Task.CompletedTask;
    }

    public Task DeleteAsync(GroceryModel entity)
    {
        var itemToRemove = _shoppingCart.FirstOrDefault(item => item.Id == entity.Id);

        if (itemToRemove != null)
        {
            _shoppingCart.Remove(itemToRemove);
        }
        else
        {
            throw new KeyNotFoundException($"Grocery item with id {entity.Id} not found.");
        }

        return Task.CompletedTask;
    }
}
