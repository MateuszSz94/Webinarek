using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Webinarek.Models.Entity
{
	public class Skin
	{
		[Column(@"id")]
		public virtual decimal ID { get; set; }

		[Column(@"skorka_1")]
		public virtual decimal Male { get; set; }


		[Column(@"skorka_2")]
		public virtual decimal Female { get; set; }

	}
}