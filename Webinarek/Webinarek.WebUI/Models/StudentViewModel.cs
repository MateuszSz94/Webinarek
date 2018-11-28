using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Webinarek.Models
{
	public class StudentViewModel
	{
		[DisplayName("Imię")]
		public string FirstName { get; set; }

		[DisplayName("Nazwisko")]
		public string Name { get; set; }

		[DisplayName("Zgoda na przetwarzanie danych")]
		public string Agreement { get; set; }

		[DisplayName("Skórka")]
		public decimal SkinID { get; set; }
	}
}