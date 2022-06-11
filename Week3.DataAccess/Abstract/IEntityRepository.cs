using Week3.Entities.Abstract;

namespace Week3.DataAccess.Abstract;

public interface IEntityRepository<T>
    where T : class, IEntity, new()
{
    List<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}