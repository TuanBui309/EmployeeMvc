using Entity.Data_Access;
using Entity.Models;
using Entity.Repository.Infrastructure;
using Entity.Repository.Interface;
namespace Entity.Repository.Repositories;

public interface INationRepository : IRepository<Nation>
{
}

public class NationRepository : RepositoryBase<Nation>, INationRepository
{

	public NationRepository(EntityDbContext entityDbContext) 
		: base(entityDbContext)
	{
	}
}
