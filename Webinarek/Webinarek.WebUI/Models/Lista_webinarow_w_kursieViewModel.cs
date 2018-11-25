using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Webinarek.Models
{
	public class Lista_webinarow_w_kursieViewModel
	{
		[DisplayName("Numer lekcji")]
		public decimal NumerLekcji { get; set; }

		[DisplayName("Webinar ID")]
		public decimal WebinarID { get; set; }

		[DisplayName("Kurs ID")]
		public decimal KursID { get; set; }

	}
}