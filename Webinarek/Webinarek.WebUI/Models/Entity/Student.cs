using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Webinarek.Models.Entity
{
	public class Student
	{
		[Column(@"id")]
		public virtual decimal ID { get; set; }

		[Column(@"imie")]
		public virtual string FirstName { get; set; }

		[Column(@"nazwisko")]
		public virtual string Name { get; set; }

		[Column(@"zgoda_przetwarzanie_danych")]
		public virtual string Agreement { get; set; }

		[Column(@"Skorka_id")]
		public virtual decimal SkinID { get; set; }
	}
}