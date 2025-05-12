using Entity.Data.Entity;
using Entity.Data.Entity.DataAccess;
using Entity.Repository.Infrastructure;
using Entity.Repository.Interface;
namespace Entity.Repository.Repositories;

public interface IDistrictRepository : IRepository<District>
{
}
public class DistrictRepository : RepositoryBase<District>, IDistrictRepository
    {

	public DistrictRepository(EntityDbContext entityDbContext)
		: base(entityDbContext)
	{
	}
}
