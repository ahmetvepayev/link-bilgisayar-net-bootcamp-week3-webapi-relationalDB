using Week3.Entities.Abstract;

namespace Week3.Service.Abstract;

public interface IEntityService<TEntity>
    where TEntity : class, IEntity, new()
{
    List<TEntity> GetAll();
    TEntity GetById(int id);
    bool Add(TEntity entity);
    bool Update(TEntity entity);
    bool Delete(int id);
}