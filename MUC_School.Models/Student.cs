using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace MUC_School.Models
{
	public class Student
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Age { get; set; }
		public double Rollnumber { get; set; }
		public string? ImageUrl { get; set; }

		[ValidateNever]
		public ClassName ClassName { get; set; }
		[ForeignKey("ClassName")]
		public int ClassNameId { get; set; }

		[ValidateNever]
		public Teacher Teacher { get; set; }
		[ForeignKey("Teacher")]
		public int TeacherId { get; set; } 

	}
}
