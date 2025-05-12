using Entity.Data.Entity;
using Entity.Data.Entity.DataAccess;
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
