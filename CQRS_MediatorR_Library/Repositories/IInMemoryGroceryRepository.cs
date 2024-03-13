namespace CQRS_MediatorR_Library.DataAccess;

public interface IInMemoryRepository<TEntity> where TEntity : class
{
    List<TEntity> GetAll();
    TEntity Add(TEntity entity);
    TEntity GetById(object id);
    TEntity Update(TEntity entity);
    TEntity Delete(object id);
}
