using Microsoft.EntityFrameworkCore;
using Week3.DataAccess.Concrete;
using Week3.Entities.Abstract;

namespace Week3.DataAccess.Abstract;

public abstract class EntityEfCoreRepositoryBase<TEntity> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
{
    protected AppDbContext _context;

    public virtual List<TEntity> GetAll()
    {
        return _context.Set<TEntity>().AsNoTracking().ToList();
    }

    public virtual void Add(TEntity entity)
    {
        var addedEntity = _context.Entry(entity);
        addedEntity.State = EntityState.Added;
    }

    public virtual void Update(TEntity entity)
    {
        var updatedEntity = _context.Entry(entity);
        updatedEntity.State = EntityState.Modified;
    }

    public virtual void Delete(TEntity entity)
    {
        var deletedEntity = _context.Entry(entity);
        deletedEntity.State = EntityState.Deleted;
    }
}