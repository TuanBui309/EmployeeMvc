using Entity.Data.Entity;
using Entity.Data.Entity.DataAccess;
using Entity.Repository.Infrastructure;
using Entity.Repository.Interface;

namespace Entity.Repository.Repositories;

public interface ICityRepository : IRepository<City>
{
}

public class CityRepository : RepositoryBase<City>, ICityRepository
{
    public CityRepository(EntityDbContext entityDbContext)
        : base(entityDbContext)
    {
    }
}

