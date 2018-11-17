using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webinarek.Models;

namespace Webinarek.Controllers
{
    public class WebinarController : Controller
    {
        // GET: Webinar
        public ActionResult Index()
        {
            try
            {
                List<Webinar> existingWebinars = new List<Webinar>();
                using (var context = ApplicationDbContext.Create())
                {
                    existingWebinars = context.Webinars.ToList();
                }
                return View(existingWebinars);
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
                var webinar = new Webinar();
                if (id > 0)
                {
                    using (var context = ApplicationDbContext.Create())
                    {
                        var tmpWebinar = context.Webinars.FirstOrDefault(x => x.Id == id);
                        if (context == null)
                            throw new ArgumentException($@"Webina with id {id} no found");
                        webinar = tmpWebinar;
                    }
                }
                return View(webinar);
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }
    }
}