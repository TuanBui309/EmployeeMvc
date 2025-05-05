using Entity.Data_Access;
using Entity.Models;
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
