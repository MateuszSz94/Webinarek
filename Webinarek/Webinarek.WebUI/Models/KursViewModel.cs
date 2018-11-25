using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Webinarek.Models
{
	public class KursViewModel
	{
		[DisplayName("Nazwa")]
		public string Nazwa { get; set; }

		[DisplayName("Kategoria")]
		public string Kategoria { get; set; }

		[DisplayName("Opis")]
		public string Opis { get; set; }

		[DisplayName("Lista webinarów  w kursie")]
		public string ListaWebinarowWKursie { get; set; }
	}
}