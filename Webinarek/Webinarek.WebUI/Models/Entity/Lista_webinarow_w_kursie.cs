using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Webinarek.Models.Entity
{
	public class Lista_webinarow_w_kursie
	{

		[Column(@"id")]
		public virtual decimal ID { get; set; }

		[Column(@"nr_lekcji")]
		public virtual decimal NumerLekcji { get; set; }

		[Column(@"Webinar_id")]
		public virtual decimal WebinarID { get; set; }

		[Column(@"Kurs_id")]
		public virtual decimal KursID { get; set; }
	}
}