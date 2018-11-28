using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webinarek.Models;
using Webinarek.Models.Entity;

namespace Webinarek.Controllers
{
    public class SkinController : Controller
    {
        // GET: Skin
        public ActionResult Index()
        {
			try
			{
				List<Skin> existingSkins = new List<Skin>();
				using (var context = ApplicationDbContext.Create())
				{
					existingSkins = context.Skins.ToList();
				}
				return View(existingSkins);
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
				var Skins = new SkinViewModel();
				if (id > 0)
				{
					using (var context = ApplicationDbContext.Create())
					{
						var tmpSkins = context.Skins.FirstOrDefault(x => x.ID == id);
						if (tmpSkins == null)

							throw new ArgumentException($@"Webina with id {id} no found");
						Skins = new SkinViewModel
						{
							Male = tmpSkins.Male,
							Female = tmpSkins.Female
							//Description = tmpKurs.Description
						};
					}
				}
				return View(Skins);
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
				SkinViewModel skin = new SkinViewModel();
				using (var context = ApplicationDbContext.Create())
				{
					var dbSkin = context.Skins.FirstOrDefault(x => x.ID == id);
					if (dbSkin == null)
						throw new ArgumentException($@"Webina with id {id} no found");
					skin.Male = dbSkin.Male;
					skin.Female = dbSkin.Female;
				
				
				}
				return View(skin);
			}
			catch (Exception e)
			{
				return View("Error");
			}
		}
	}
}