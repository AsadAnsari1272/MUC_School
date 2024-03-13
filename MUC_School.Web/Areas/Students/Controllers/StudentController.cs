using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MUC_School.DataAccess.Services.Interface;
using MUC_School.Models;
using NuGet.Packaging;

namespace MUC_School.Web.Areas.Students.Controllers
{
	public class StudentController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;

		#region Constructor
		public StudentController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
			_webHostEnvironment = webHostEnvironment;
        }
		#endregion

		#region StudentList
		public IActionResult ListOfStudent()
		{
			var StudentList = _unitOfWork.StudentRepo.GetAll("ClassName-Teacher");
			return View(StudentList);
		}
		#endregion

		#region StudentForm
		public IActionResult StudentForm(int? id)
		{
			IEnumerable<ClassName> classname = _unitOfWork.ClassNameRepo.GetAll();
			IEnumerable<SelectListItem> Classes = classname.Select(c => new SelectListItem { Text = c.Standard.ToString(), Value = c.Id.ToString() });
			ViewBag.ClassStandard = Classes;

			IEnumerable<Teacher> teacher = _unitOfWork.TeacherRepo.GetAll();
			IEnumerable<SelectListItem> teacherList = teacher.Select(s => new SelectListItem { Text = s.TeacherName, Value = s.Id.ToString() });
			ViewBag.TeacherLists = teacherList;

			if (id == null || id == 0)
			{
				return View(new Student());
			}
			var IdfromDb = _unitOfWork.StudentRepo.Get(s => s.Id == id);

			if(IdfromDb == null) return NotFound();
			return View(IdfromDb);
		}
		#endregion

		#region StudentForm
		[HttpPost]
		public IActionResult StudentForm(Student student, IFormFile file)
		{
			if (ModelState.IsValid)
			{
				if (file != null)
				{
					string ImageExtesion = Path.GetExtension(file.FileName);
					string FinalName = "Image" + Guid.NewGuid().ToString().Substring(0, 4) + ImageExtesion;


					string UrlPath = _webHostEnvironment.WebRootPath;

					if (!string.IsNullOrEmpty(student.ImageUrl))
					{
						var OldImgPath = UrlPath + student.ImageUrl;
						if (System.IO.File.Exists(OldImgPath))
						{
							System.IO.File.Delete(OldImgPath);
						}
					}
					string FinalPath = UrlPath + @"\Images\Student";

					using (FileStream fileStream = new FileStream(Path.Combine(FinalPath, FinalName), FileMode.Create))
					{
						file.CopyTo(fileStream);
					}

					student.ImageUrl = @"\Images\Student\" + FinalName;

				}

				if (student.Id == null || student.Id == 0)
				{
					_unitOfWork.StudentRepo.Add(student);
					_unitOfWork.Save();
					TempData["Successful"] = "Student Added Successfully";
				}
				else
				{
					_unitOfWork.StudentRepo.Edit(student);
					_unitOfWork.Save();
					TempData["Successful"] = "Student Updated Successfully";
				}

				return RedirectToAction("ListOfStudent");
			}
			return BadRequest(ModelState);

		}

        #endregion

        #region Delete
		public IActionResult Delete(int id)
		{
			if (id == null || id == 0) return NotFound();

			var IdFromDb = _unitOfWork.StudentRepo.Get(s => s.Id==id,"ClassName-Teacher");
			if (IdFromDb == null) return BadRequest();
            return View(IdFromDb);
		}
        #endregion

        #region DeleteConfirm
		public IActionResult DeleteConfirm(int id)
		{
			if(id == null || id == 0) return NotFound();
			var IdFromDb = _unitOfWork.StudentRepo.GetById(id);

			if (!string.IsNullOrEmpty(IdFromDb.ImageUrl))
			{
				var RootPath = _webHostEnvironment.WebRootPath;
				string OldPath = RootPath + IdFromDb.ImageUrl;
				if(System.IO.File.Exists(OldPath))
				{
					System.IO.File.Delete(OldPath);
				}
			}
            _unitOfWork.StudentRepo.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("ListOfStudent");
		}
        #endregion
    }
}
