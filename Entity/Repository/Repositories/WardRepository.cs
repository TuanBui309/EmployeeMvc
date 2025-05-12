using Entity.Data.Entity;
using Entity.Data.Entity.DataAccess;
using Entity.Repository.Infrastructure;
using Entity.Repository.Interface;
namespace Entity.Repository.Repositories;

public interface IWardRepository : IRepository<Ward>
{
}

public class WardRepository : RepositoryBase<Ward>, IWardRepository
{

    public WardRepository(EntityDbContext entityDbContext) : base(entityDbContext)
    {
    }
}
