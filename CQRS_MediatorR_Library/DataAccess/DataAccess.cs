using CQRS_MediatorR_Library.Models;

namespace CQRS_MediatorR_Library.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private List<GroceryModel> shoppingCart = new();

        public DataAccess()
        {
            shoppingCart.Add(new GroceryModel { Id = 1, Name = "Apple", ProductType = Types.Fruit });
            shoppingCart.Add(new GroceryModel { Id = 2, Name = "Cucumber", ProductType = Types.Vegetable });
            shoppingCart.Add(new GroceryModel { Id = 3, Name = "Coca Cola", ProductType = Types.Drink });
        }

        public List<GroceryModel> GetGroceries()
        {
            return shoppingCart;
        }

        public GroceryModel InsertGrocery(string name, Types type)
        {
            GroceryModel item = new() { Name = name, ProductType = type };
            item.Id = shoppingCart.Max(x => x.Id) + 1;
            shoppingCart.Add(item);
            return item;
        }

        public GroceryModel UpdateGrocery(int id, string newName, Types newProductType)
        {
            GroceryModel foundItem = shoppingCart.FirstOrDefault(item => item.Id == id);
            if (foundItem != null)
            {
                foundItem.Name = newName;
                foundItem.ProductType = newProductType;

                return foundItem;
            }
            else
            {
                throw new ArgumentException("Grocery item not found");
            }
        }

        public GroceryModel DeleteGrocery(int id)
        {
            GroceryModel itemToRemove = shoppingCart.FirstOrDefault(item => item.Id == id);
            if (itemToRemove != null)
            {
                shoppingCart.Remove(itemToRemove);
                return itemToRemove;
            }
            else
            {
                throw new ArgumentException("Grocery item not found");
            }
        }

    }
}


