﻿using System;
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
		public virtual string Nazwa { get; set; }

		[Column(@"kategoria")]
		public virtual string Kategoria { get; set; }

		[Column(@"opis")]
		public virtual string Opis { get; set; }

	}
}