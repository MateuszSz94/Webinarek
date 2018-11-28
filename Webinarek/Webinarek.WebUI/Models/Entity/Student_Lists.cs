using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Webinarek.Models.Entity
{
	public class Student_Lists
	{
		[Column(@"id")]
		public virtual decimal ID {get; set;}

		[Column(@"czas_dostepu_do_kursu")]
		public virtual DateTime CourseTime { get; set; }

		[Column(@"Kurs_id")]
		public virtual decimal CourseID { get; set; }

		[Column(@"Kursant_id ")]
		public virtual decimal StudentID { get; set; }



	}
}