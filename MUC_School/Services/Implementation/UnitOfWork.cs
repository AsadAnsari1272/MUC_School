using MUC_School.DataAccess.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUC_School.DataAccess.Services.Implementation
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
			_context = context;
			StudentRepo = new StudentRepo(context);
			ClassNameRepo = new ClassNameRepo(context);
			TeacherRepo = new TeacherRepo(context);
        }
        public IStudentRepo StudentRepo { get; private set; }

		public IClassNameRepo ClassNameRepo { get; private set; }

		public ITeacherRepo TeacherRepo { get; private set; }

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
