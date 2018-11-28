using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Webinarek.Models
{
	public class SkinViewModel
	{
		[DisplayName("Skorka dla chłopców")]
		public decimal Male { get; set; }

		[DisplayName("Skorka dla dziewczynek")]
		public decimal Female { get; set; }

		
	}
}