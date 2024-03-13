using MUC_School.DataAccess.Services.Interface;
using MUC_School.Models;

namespace MUC_School.DataAccess.Services.Implementation
{
	public class TeacherRepo : Repository<Teacher>, ITeacherRepo
	{
		private readonly ApplicationDbContext _context;
		public TeacherRepo(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}
	}
}
