using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Webinarek.Models
{
	public class Student_ListsViewModels
	{
		[DisplayName("Czas dostępu do kursu")]
		public DateTime CourseTime { get; set; }

		[DisplayName("Kurs")]
		public decimal CourseID  { get; set; }

		[DisplayName("Kursant")]
		public decimal StudentID { get; set; }
	}
}