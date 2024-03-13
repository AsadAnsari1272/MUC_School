namespace MUC_School.DataAccess.Services.Interface
{
	public interface IUnitOfWork 
	{
		public IStudentRepo StudentRepo { get;}
		public IClassNameRepo ClassNameRepo { get;}
		public ITeacherRepo TeacherRepo { get;}

		void Save();
	}
}
