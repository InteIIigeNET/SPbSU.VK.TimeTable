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
		Task<TEntity> CreateAsync(TEntity entity);
		Task<bool> UpdateAsync(long id, Expression<Func<TEntity, TEntity>> expression);
		Task<bool> DeleteAsync(long id);
		Task<TEntity> GetAsync(long id);
		IReadOnlyCollection<TEntity> FindAll(Expression<Func<TEntity, bool>> expression, 
			params Expression<Func<TEntity, object>>[] includeProperties);
	}
}
