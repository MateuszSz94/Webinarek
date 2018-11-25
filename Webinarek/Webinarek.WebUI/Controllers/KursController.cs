using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webinarek.Models;
using Webinarek.Models.Entity;

namespace Webinarek.Controllers
{
    public class KursController : Controller
    {
		public ActionResult Index()
		{
			try
			{
				List<Kurs> existingKurss = new List<Kurs>();
				using (var context = ApplicationDbContext.Create())
				{
					existingKurss = context.Kurs.ToList();
				}
				return View(existingKurss);
			}
			catch (Exception e)
			{
				return View("Error");
			}
		}

		[HttpGet]
		public ActionResult AddEdit(int id)
		{
			try
			{
				var Kurs = new KursViewModel();
				if (id > 0)
				{
					using (var context = ApplicationDbContext.Create())
					{
						var tmpKurs = context.Kurs.FirstOrDefault(x => x.ID == id);
						if (tmpKurs == null)
							throw new ArgumentException($@"Webina with id {id} no found");
						Kurs = new KursViewModel
						{
							Kategoria = tmpKurs.Kategoria,
							Nazwa = tmpKurs.Nazwa,
							//ListaWebinarowWKursie = tmpKurs.ListaWebinarowWKursieID,
							Opis =  tmpKurs.Opis

							

						};
					}
				}
				return View(Kurs);
			}
			catch (Exception e)
			{
				return View("Error");
			}
		}


		[HttpGet]
		public ActionResult Display(int id)
		{
			try
			{
				KursViewModel Kurs = new KursViewModel();
				using (var context = ApplicationDbContext.Create())
				{
					var dbKurs = context.Kurs.FirstOrDefault(x => x.ID == id);
					if (dbKurs == null)
						throw new ArgumentException($@"Webina with id {id} no found");

					Kurs.Nazwa = dbKurs.Nazwa;
					Kurs.Opis = dbKurs.Opis;
					//Kurs.ListaWebinarowWKursie = dbKurs.ListaWebinarowWKursieID;
					Kurs.Kategoria = dbKurs.Kategoria;



				}
				return View(Kurs);
			}
			catch (Exception e)
			{
				return View("Error");
			}
		}
	}
}