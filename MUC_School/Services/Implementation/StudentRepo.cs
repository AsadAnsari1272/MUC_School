using MUC_School.DataAccess.Services.Interface;
using MUC_School.Models;

namespace MUC_School.DataAccess.Services.Implementation
{
	public class StudentRepo : Repository<Student>, IStudentRepo
	{
		private readonly ApplicationDbContext _context;
		public StudentRepo(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}
	}
}
