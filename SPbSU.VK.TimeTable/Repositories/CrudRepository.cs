using SPbSU.VK.TimeTable.IRepositories;
using SPbSU.VK.TimeTable.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace SPbSU.VK.TimeTable.Repositories
{
	public class CrudRepository<TEntity> : ICrudRepository<TEntity>
		where TEntity : BaseModel
	{
		private readonly VkTimeTableContext context;

		public CrudRepository(VkTimeTableContext context)
		{
			this.context = context;
		}

		public async Task CreateAsync(TEntity entity)
		{
			await context.AddAsync(entity);
			await context.SaveChangesAsync();
		}

		public async Task DeleteAsync(long id)
		{
			await context.Set<TEntity>().Where(e => e.Id == id).DeleteAsync();
			await context.SaveChangesAsync();
		}

		public IReadOnlyCollection<TEntity> FindAll(Expression<Func<TEntity, bool>> expression)
		{
			return context.Query<TEntity>().Where(expression).ToArray();
		}

		public Task<TEntity> GetAsync(long id)
		{
			return context.Set<TEntity>().FindAsync(id);
		}

		public async Task UpdateAsync(TEntity entity)
		{
			context.Set<TEntity>().Update(entity);
			await context.SaveChangesAsync();
		}
	}
}
