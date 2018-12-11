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
		public string Name { get; set; }

		[DisplayName("Kategoria")]
		public string Category { get; set; }

		[DisplayName("Opis")]
		public string Description { get; set; }

		[DisplayName("Lista webinarów  w kursie")]
		public string ListaWebinarowWKursie { get; set; }

        public int Id { get; set; }
    }
}