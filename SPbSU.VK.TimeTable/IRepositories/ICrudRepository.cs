using SPbSU.VK.TimeTable.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SPbSU.VK.TimeTable.IRepositories
{
	public interface ICrudRepository<TEntity> 
		where TEntity : BaseModel
	{
		Task CreateAsync(TEntity entity);
		Task UpdateAsync(TEntity entity);
		Task DeleteAsync(long id);
		Task<TEntity> GetAsync(long id);
		IReadOnlyCollection<TEntity> FindAll(Expression<Func<TEntity, bool>> expression);
	}
}
