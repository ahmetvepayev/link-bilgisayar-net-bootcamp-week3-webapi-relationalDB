using Week3.Entities.Concrete;

namespace Week3.DataAccess.Abstract;

public interface IProductDal : IEntityRepository<Product>
{
    List<ProductFullModel> GetFullModels();
}