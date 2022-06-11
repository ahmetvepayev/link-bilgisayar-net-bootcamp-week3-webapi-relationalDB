using Week3.DataAccess.Abstract;
using Week3.Entities.Concrete;

namespace Week3.DataAccess.Concrete;

public class ProductFeatureDal : EntityEfCoreRepositoryBase<ProductFeature>, IProductFeatureDal
{
    public ProductFeatureDal(AppDbContext context)
    {
        _context = context;
    }
}