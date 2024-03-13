using Microsoft.EntityFrameworkCore;
using MUC_School.Models;

namespace MUC_School
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
	{
		public DbSet<Student> Students {  get; set; }
		public DbSet<ClassName> ClassNames { get; set; }
		public DbSet<Teacher> Teachers { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Teacher>().HasData(
				 new Teacher { Id=1, TeacherName="Ali", TeacherId="13264521"},
				 new Teacher { Id=2, TeacherName="Abuzar", TeacherId="1345201"},
				 new Teacher { Id=3, TeacherName="Abdul", TeacherId="13464120"}
				);

			modelBuilder.Entity<ClassName>().HasData(
				new ClassName { Id=1, Standard="6th", Division = 'A'},
				new ClassName { Id=2, Standard="7th", Division = 'B'},
				new ClassName { Id=3, Standard="8th", Division = 'C'},
				new ClassName { Id=4, Standard="9th", Division = 'B'}
				);
		}
	}
}
