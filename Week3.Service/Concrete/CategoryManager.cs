using Week3.DataAccess.Abstract;
using Week3.DataAccess.Abstract.UnitOfWork;
using Week3.Entities.Concrete;
using Week3.Service.Abstract;

namespace Week3.Service.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryManager(ICategoryDal categoryDal, IUnitOfWork unitOfWork)
    {
        _categoryDal = categoryDal;
        _unitOfWork = unitOfWork;
    }

    public bool Add(Category entity)
    {
        _categoryDal.Add(entity);
        _unitOfWork.Commit();

        return true;
    }

    public bool Delete(int id)
    {
        var deletedCategory = _categoryDal.GetById(id);
        _categoryDal.Delete(deletedCategory);
        _unitOfWork.Commit();

        return true;
    }

    public List<Category> GetAll()
    {
        return _categoryDal.GetAll();
    }

    public Category GetById(int id)
    {
        return _categoryDal.GetById(id);
    }

    public bool Update(Category entity)
    {
        _categoryDal.Update(entity);
        _unitOfWork.Commit();

        return true;
    }
}