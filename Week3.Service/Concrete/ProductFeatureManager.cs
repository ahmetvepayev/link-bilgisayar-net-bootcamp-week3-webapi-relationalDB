using Week3.DataAccess.Abstract;
using Week3.DataAccess.Abstract.UnitOfWork;
using Week3.Entities.Concrete;
using Week3.Service.Abstract;

namespace Week3.Service.Concrete;

public class ProductFeatureManager : IProductFeatureService
{
    private readonly IProductFeatureDal _productFeatureDal;
    private readonly IUnitOfWork _unitOfWork;

    public ProductFeatureManager(IProductFeatureDal productFeatureDal, IUnitOfWork unitOfWork)
    {
        _productFeatureDal = productFeatureDal;
        _unitOfWork = unitOfWork;
    }

    public bool Add(ProductFeature entity)
    {
        _productFeatureDal.Add(entity);
        _unitOfWork.Commit();

        return true;
    }

    public bool Delete(int id)
    {
        var deletedProductFeature = _productFeatureDal.GetById(id);
        _productFeatureDal.Delete(deletedProductFeature);
        _unitOfWork.Commit();

        return true;
    }

    public List<ProductFeature> GetAll()
    {
        return _productFeatureDal.GetAll();
    }

    public ProductFeature GetById(int id)
    {
        return _productFeatureDal.GetById(id);
    }

    public bool Update(ProductFeature entity)
    {
        _productFeatureDal.Update(entity);
        _unitOfWork.Commit();

        return true;
    }
}