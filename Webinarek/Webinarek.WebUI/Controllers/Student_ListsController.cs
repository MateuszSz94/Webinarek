using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webinarek.Models;
using Webinarek.Models.Entity;

namespace Webinarek.Controllers
{
    public class Student_ListsController : Controller
    {
        // GET: Student_Lists
        public ActionResult Index()
        {
			try
			{
				List<Student_Lists> existingStudent_Lists = new List<Student_Lists>();
				using (var context = ApplicationDbContext.Create())
				{
					existingStudent_Lists = context.Student_Lists.ToList();
				}
				return View(existingStudent_Lists);
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
				var StudentLists = new Student_ListsViewModels();
				if (id > 0)
				{
					using (var context = ApplicationDbContext.Create())
					{
						var tmpStudentLists = context.Student_Lists.FirstOrDefault(x => x.ID == id);
						if (tmpStudentLists == null)

							throw new ArgumentException($@"Webina with id {id} no found");
						StudentLists = new Student_ListsViewModels
						{
							CourseTime = tmpStudentLists.CourseTime,
							StudentID = tmpStudentLists.StudentID,
							CourseID = tmpStudentLists.CourseID
							//Description = tmpKurs.Description
						};
					}
				}
				return View(StudentLists);
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
				Student_ListsViewModels student_List = new Student_ListsViewModels();
				using (var context = ApplicationDbContext.Create())
				{
					var dbStudent_List = context.Student_Lists.FirstOrDefault(x => x.ID == id);
					if (dbStudent_List == null)
						throw new ArgumentException($@"Webina with id {id} no found");


					student_List.StudentID = dbStudent_List.StudentID;
					student_List.CourseTime = dbStudent_List.CourseTime;
					student_List.StudentID = dbStudent_List.StudentID;


				}
				return View(student_List);
			}
			catch (Exception e)
			{
				return View("Error");
			}
		}


	}
}