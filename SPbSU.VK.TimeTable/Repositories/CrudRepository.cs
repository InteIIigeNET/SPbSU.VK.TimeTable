using Microsoft.EntityFrameworkCore;
using SPbSU.VK.TimeTable.IRepositories;
using SPbSU.VK.TimeTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace SPbSU.VK.TimeTable.Repositories
{
	public abstract class CrudRepository<TEntity> : ICrudRepository<TEntity>
		where TEntity : BaseModel
	{
		protected readonly VkTimeTableContext context;

		public CrudRepository(VkTimeTableContext context)
		{
			this.context = context;
		}

		public async Task<TEntity> CreateAsync(TEntity entity)
		{
			var addedEntry = await context.AddAsync(entity);
			await context.SaveChangesAsync();
			return addedEntry.Entity;
		}

		public async Task<bool> DeleteAsync(long id)
		{
			return await context.Set<TEntity>().Where(e => e.Id == id).DeleteAsync() == 1;
		}

		public IReadOnlyCollection<TEntity> FindAll(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			var query = context.Query<TEntity>().Where(expression);

			foreach (var includeParam in includeProperties)
			{
				query = query.Include(includeParam);
			}

			return query.ToArray();
		}

		public Task<TEntity> GetAsync(long id)
		{
			return context.Set<TEntity>().FindAsync(id);
		}

		public async Task<bool> UpdateAsync(long id, Expression<Func<TEntity, TEntity>> expression)
		{
			return await context.Set<TEntity>()
				.Where(e => e.Id == id)
				.UpdateAsync(expression) == 1;
		}
	}
}
