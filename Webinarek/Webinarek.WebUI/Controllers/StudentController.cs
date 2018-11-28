using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webinarek.Models;
using Webinarek.Models.Entity;

namespace Webinarek.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
			try

			{
				List<Student> existingStudents = new List<Student>();
				using (var context = ApplicationDbContext.Create())
				{
					existingStudents = context.Students.ToList();
				}
				return View(existingStudents);
			}
			catch (Exception e)
			{
				return View("Error");
			}
		}

		[HttpGet]
		public ActionResult AddEdit(int id)
		{
			try
			{
				var Students = new StudentViewModel();
				if (id > 0)
				{
					using (var context = ApplicationDbContext.Create())
					{
						var tmpStudents = context.Students.FirstOrDefault(x => x.ID == id);
						if (tmpStudents == null)

							throw new ArgumentException ($@"Webina with id {id} no found");
						Students = new StudentViewModel
						{
							
							FirstName = tmpStudents.FirstName,
							Name =tmpStudents.Name,
							Agreement = tmpStudents.Agreement,
							SkinID = tmpStudents.SkinID

							//Description = tmpKurs.Description
						};
					}
				}
				return View(Students);
			}
			catch (Exception e)
			{
				return View("Error");
			}
		}


		[HttpGet]
		public ActionResult Display(int id)
		{
			try
			{
				StudentViewModel student = new StudentViewModel();
				using (var context = ApplicationDbContext.Create())
				{
					var dbStudnet = context.Students.FirstOrDefault(x => x.ID == id);
					if (dbStudnet == null)
						throw new ArgumentException($@"Webina with id {id} no found");

					student.FirstName = dbStudnet.FirstName;
					student.Name = dbStudnet.Name;
					student.SkinID = dbStudnet.SkinID;
					student.Agreement = dbStudnet.Agreement;
					
			
					



				}
				return View(student);
			}
			catch (Exception e)
			{
				return View("Error");
			}
		}
	}
}