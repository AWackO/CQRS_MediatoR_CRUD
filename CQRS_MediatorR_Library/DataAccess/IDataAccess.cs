using CQRS_MediatorR_Library.Models;

namespace CQRS_MediatorR_Library.DataAccess
{
    public interface IDataAccess
    {
        List<GroceryModel> GetGroceries();
        GroceryModel InsertGrocery(string name, Types type);
        GroceryModel UpdateGrocery(int id, string name, Types type);
        GroceryModel DeleteGrocery(int id);
    }
}