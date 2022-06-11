using Week3.DataAccess.Abstract;
using Week3.Entities.Concrete;

namespace Week3.DataAccess.Concrete;

public class CategoryDal : EntityEfCoreRepositoryBase<Category>, ICategoryDal
{
    public CategoryDal(AppDbContext context)
    {
        _context = context;
    }

    public override Category GetById(int id)
    {
        return _context.Categories.Find(id);
    }
}