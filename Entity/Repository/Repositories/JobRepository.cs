using Entity.Data.Entity;
using Entity.Data.Entity.DataAccess;
using Entity.Repository.Infrastructure;
using Entity.Repository.Interface;
namespace Entity.Repository.Repositories;
	public interface IJobRepository : IRepository<Job>
	{
	}

	public class JobRepository : RepositoryBase<Job>, IJobRepository
	{

		public JobRepository(EntityDbContext entityDbContext) : base(entityDbContext)
		{
		}
	}
