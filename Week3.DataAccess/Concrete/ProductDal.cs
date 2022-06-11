using Week3.DataAccess.Abstract;
using Week3.Entities.Concrete;

namespace Week3.DataAccess.Concrete;

public class ProductDal : EntityEfCoreRepositoryBase<Product>, IProductDal
{
    public ProductDal(AppDbContext context)
    {
        _context = context;
    }
}