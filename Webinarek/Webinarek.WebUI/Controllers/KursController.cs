using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webinarek.Models;
using Webinarek.Models.Entity;

namespace Webinarek.Controllers
{
    [Authorize]
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
							Category = tmpKurs.Category,
							Name = tmpKurs.Name,
							//ListaWebinarowWKursie = tmpKurs.ListaWebinarowWKursieID,
							Description = tmpKurs.Description,
                            Id = (int)tmpKurs.ID
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

        [HttpPost]
        public ActionResult AddEdit(KursViewModel model)
        {
            try
            {
                if (model != null)
                {
                    using (var context = ApplicationDbContext.Create())
                    {
                        if (model.Id == 0)
                        {
                            var webinars = context.Webinars.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();
                            var newWebinar = new Kurs
                            {
                                ID = context.Kurs.Max(x => x.ID) + 1,
                                Category = model.Category,
                                Name = model.Name,
                                Description = model.Description,
                            };
                            var kursWebConnection = new Lista_webinarow_w_kursies
                            {
                                KursID = newWebinar.ID,
                                WebinarID = webinars,
                                NumerLekcji = 1,
                                ID = context.Lista_webinarow_w_kursies.Max(x => x.ID) + 1
                            };
                            context.Kurs.Add(newWebinar);
                            context.Lista_webinarow_w_kursies.Add(kursWebConnection);
                            context.SaveChanges();
                        }
                        else
                        {
                            var webinar = context.Kurs.First(x => x.ID == model.Id);
                            webinar.Name = model.Name;
                            webinar.Category = model.Category;
                            webinar.Description = model.Description;
                            context.SaveChanges();
                        }
                    }
                }
                return RedirectToAction("Index");
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

					Kurs.Name = dbKurs.Name;
					Kurs.Description = dbKurs.Description;
					//Kurs.ListaWebinarowWKursie = dbKurs.ListaWebinarowWKursieID;
					Kurs.Category = dbKurs.Category;
                    Kurs.Id = (int)dbKurs.ID;


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