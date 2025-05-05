using Entity.Data_Access;
using Entity.Models;
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

