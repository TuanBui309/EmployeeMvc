using Entity.Data_Access;
using Entity.Models;
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
