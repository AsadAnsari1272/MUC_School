using MUC_School.DataAccess.Services.Interface;
using MUC_School.Models;

namespace MUC_School.DataAccess.Services.Implementation
{
	public class ClassNameRepo : Repository<ClassName>, IClassNameRepo
	{
		private readonly ApplicationDbContext _context;
		public ClassNameRepo(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}
	}
}
