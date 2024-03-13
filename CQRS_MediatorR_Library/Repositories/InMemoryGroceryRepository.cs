using CQRS_MediatorR_Library.DataAccess;
using CQRS_MediatorR_Library.Models;

namespace CQRS_MediatorR_Library.Repositories;

public class InMemoryGroceryRepository : IInMemoryRepository<GroceryModel>
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

    public List<GroceryModel> GetAll()
    {
        return _shoppingCart;
    }

    public GroceryModel Add(GroceryModel entity)
    {
        entity.Id = _shoppingCart.Any() ? _shoppingCart.Max(x => x.Id) + 1 : 1;
        _shoppingCart.Add(entity);
        return entity;
    }

    public GroceryModel GetById(object id)
    {
        var itemId = (int)id;
        var grocery = _shoppingCart.FirstOrDefault(item => item.Id == itemId);
        return grocery;
    }

    public GroceryModel Update(GroceryModel entity)
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

        return existingItem;
    }

    public GroceryModel Delete(object id)
    {
        var itemToRemove = _shoppingCart.FirstOrDefault(item => item.Id == (int)id);

        if (itemToRemove != null)
        {
            _shoppingCart.Remove(itemToRemove);
        }
        else
        {
            throw new KeyNotFoundException($"Grocery item with id {id} not found.");
        }

        return itemToRemove;
    }
}
