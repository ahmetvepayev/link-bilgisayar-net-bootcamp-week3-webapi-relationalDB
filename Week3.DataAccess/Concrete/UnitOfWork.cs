using Microsoft.EntityFrameworkCore.Storage;
using Week3.DataAccess.Abstract.UnitOfWork;

namespace Week3.DataAccess.Concrete.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public IDbContextTransaction BeginTransaction()
    {
        return _context.Database.BeginTransaction();
    }
}