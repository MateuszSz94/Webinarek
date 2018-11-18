using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webinarek.Models;
using Webinarek.Models.Entity;

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
                var webinar = new WebinarViewModel();
                if (id > 0)
                {
                    using (var context = ApplicationDbContext.Create())
                    {
                        var tmpWebinar = context.Webinars.FirstOrDefault(x => x.Id == id);
                        if (tmpWebinar == null)
                            throw new ArgumentException($@"Webina with id {id} no found");
                        webinar = new WebinarViewModel
                        {
                            Title = tmpWebinar.Title,
                            Description = tmpWebinar.Description,
                            Duration = tmpWebinar.Duration
                        };
                    }
                }
                return View(webinar);
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
                WebinarViewModel webinar = new WebinarViewModel();
                using (var context = ApplicationDbContext.Create())
                {
                    var dbWebinar = context.Webinars.FirstOrDefault(x => x.Id == id);
                    if (dbWebinar == null)
                        throw new ArgumentException($@"Webina with id {id} no found");
                    webinar.Description = dbWebinar.Description;
                    webinar.Duration = dbWebinar.Duration;
                    webinar.Title = dbWebinar.Title;
                    var videoData = new VideoData
                    {
                        FileName = dbWebinar.FileName,
                        MimeType = dbWebinar.MimeType
                    };
                    webinar.VideoData = videoData;
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