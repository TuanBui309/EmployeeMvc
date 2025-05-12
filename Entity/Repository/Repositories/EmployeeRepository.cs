using Entity.Data.Entity;
using Entity.Data.Entity.DataAccess;
using Entity.Repository.Infrastructure;
using Entity.Repository.Interface;
namespace Entity.Repository.Repositories;

public interface IEmployeeRepository : IRepository<Employee>
{
}
public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{

	public EmployeeRepository(EntityDbContext entityDbContext) : base(entityDbContext)
	{
	}
}
