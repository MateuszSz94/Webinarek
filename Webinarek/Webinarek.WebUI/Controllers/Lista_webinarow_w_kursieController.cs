using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webinarek.Models;
using Webinarek.Models.Entity;

namespace Webinarek.Controllers
{
    public class Lista_webinarow_w_kursieController : Controller
    {
		// GET: Lista_webinarow_w_kursie
		public ActionResult Index()
		{
			try
			{
				List<Lista_webinarow_w_kursie> existingLista_webinarow_w_kursies = new List<Lista_webinarow_w_kursie>();
				using (var context = ApplicationDbContext.Create())
				{
					existingLista_webinarow_w_kursies = context.Lista_webinarow_w_kursies.ToList();
				}
				return View(existingLista_webinarow_w_kursies);
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
				var Lista_webinarow_w_kursie = new Lista_webinarow_w_kursieViewModel();
				if (id > 0)
				{
					using (var context = ApplicationDbContext.Create())
					{
						var tmpLista_webinarow_w_kursie = context.Lista_webinarow_w_kursies.FirstOrDefault(x => x.ID == id);
						if (tmpLista_webinarow_w_kursie == null)
							throw new ArgumentException($@"Webina with id {id} no found");
						Lista_webinarow_w_kursie = new Lista_webinarow_w_kursieViewModel
						{

							KursID = tmpLista_webinarow_w_kursie.KursID,
							NumerLekcji = tmpLista_webinarow_w_kursie.NumerLekcji,
						    WebinarID = tmpLista_webinarow_w_kursie.WebinarID

					
						};
					}
				}
				return View(Lista_webinarow_w_kursie);
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
				Lista_webinarow_w_kursieViewModel Lista_webinarow_w_kursie = new Lista_webinarow_w_kursieViewModel();
				using (var context = ApplicationDbContext.Create())
				{
					var dbLista_webinarow_w_kursie = context.Lista_webinarow_w_kursies.FirstOrDefault(x => x.ID == id);
					if (dbLista_webinarow_w_kursie == null)
						throw new ArgumentException($@"Webina with id {id} no found");
					Lista_webinarow_w_kursie.WebinarID = dbLista_webinarow_w_kursie.WebinarID;
					Lista_webinarow_w_kursie.NumerLekcji = dbLista_webinarow_w_kursie.NumerLekcji;
					Lista_webinarow_w_kursie.KursID = dbLista_webinarow_w_kursie.KursID;

					
				}
				return View(Lista_webinarow_w_kursie);
			}
			catch (Exception e)
			{
				return View("Error");
			}
		}
	}
}