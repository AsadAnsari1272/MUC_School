using System.Linq.Expressions;

namespace MUC_School.DataAccess.Services.Interface
{
	public interface IRepository<T> where T : class
	{
		void Add(T entity);
		void Edit(T entity);
		void Delete(int id);
		IEnumerable<T> GetAll(string? InnerEntity = null);
		T GetById(int id);
		T Get(Expression<Func<T, bool>> expression, string? InnerEntity = null);
	}
}
