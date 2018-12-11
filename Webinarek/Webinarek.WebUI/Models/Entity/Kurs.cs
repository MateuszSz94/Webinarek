using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Webinarek.Models.Entity
{
	public class Kurs
	{

		[Column(@"id")]
		public virtual decimal ID { get; set; }

		[Column(@"nazwa")]
		public virtual string Name { get; set; }

		[Column(@"kategoria")]
		public virtual string Category { get; set; }

		[Column(@"opis")]
		public virtual string Description { get; set; }

        public virtual List<Lista_webinarow_w_kursies> Webinars { get; set; }

    }
}