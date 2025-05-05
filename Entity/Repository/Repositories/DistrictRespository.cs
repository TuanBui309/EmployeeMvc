using Entity.Data_Access;
using Entity.Models;
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
