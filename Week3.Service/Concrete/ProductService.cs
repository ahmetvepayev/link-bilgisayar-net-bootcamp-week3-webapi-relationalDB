using Week3.DataAccess.Abstract;
using Week3.DataAccess.Abstract.UnitOfWork;
using Week3.Entities.Concrete;
using Week3.Service.Abstract;

namespace Week3.Service.Concrete;

public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;
    private readonly IUnitOfWork _unitOfWork;

    public ProductManager(IProductDal productDal, IUnitOfWork unitOfWork)
    {
        _productDal = productDal;
        _unitOfWork = unitOfWork;
    }

    public bool Add(Product entity)
    {
        _productDal.Add(entity);
        _unitOfWork.Commit();

        return true;
    }

    public bool Delete(int id)
    {
        var deletedProduct = _productDal.GetById(id);
        _productDal.Delete(deletedProduct);
        _unitOfWork.Commit();

        return true;
    }

    public List<Product> GetAll()
    {
        return _productDal.GetAll();
    }

    public Product GetById(int id)
    {
        return _productDal.GetById(id);
    }

    public bool Update(Product entity)
    {
        _productDal.Update(entity);
        _unitOfWork.Commit();

        return true;
    }

    public List<ProductFullModel> GetFullModels()
    {
        return _productDal.GetFullModels();
    }
}