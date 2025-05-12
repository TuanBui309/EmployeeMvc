using Entity.Data.Entity;
using Entity.Data.Entity.DataAccess;
using Entity.Repository.Infrastructure;
using Entity.Repository.Interface;

namespace Entity.Repository.Repositories;

public interface IDegreeRepository : IRepository<Degree>
{
}

public class DegreeRepository : RepositoryBase<Degree>, IDegreeRepository
{

    public DegreeRepository(EntityDbContext entityDbContext) : base(entityDbContext)
    {
    }

}
