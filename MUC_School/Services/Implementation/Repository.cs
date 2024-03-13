using Microsoft.EntityFrameworkCore;
using MUC_School.DataAccess.Services.Interface;
using System.Linq.Expressions;

namespace MUC_School.DataAccess.Services.Implementation
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _context;
		internal DbSet<T> _dbset;
		public Repository(ApplicationDbContext context)
		{
			_context = context;
			_dbset = _context.Set<T>();
		}
		public void Add(T entity)
		{
			_dbset.Add(entity);
		}

		public void Delete(int id)
		{
			var udfromdb = _dbset.Find(id);
			_dbset.Remove(udfromdb);
		}

		public void Edit(T entity)
		{
			_dbset.Update(entity);
		}

		public T Get(Expression<Func<T, bool>> expression, string? InnerEntity = null)
		{
			IQueryable<T> query = _dbset;

			if (!string.IsNullOrEmpty(InnerEntity))
			{
				foreach (var user in InnerEntity.Split(new char[] { ',', '-' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(user);
				}
			}
			return query.SingleOrDefault(expression);
		}

		public IEnumerable<T> GetAll(string? InnerEntity = null)
		{
			IQueryable<T> query = _dbset;

			if (!string.IsNullOrEmpty(InnerEntity))
			{
				foreach (var user in InnerEntity.Split(new char[] { ',', '-' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(user);
				}
			}
			return query.ToList();
		}

		public T GetById(int id)
		{
			return _dbset.Find(id);
		}
	}
}
