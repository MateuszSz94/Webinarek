using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webinarek.Models;
using Webinarek.Models.Entity;
using System.IO;

namespace Webinarek.Controllers
{
    public class WebinarController : Controller
    {
        // GET: Webinar
        [Authorize]
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

        [Authorize]
        public ActionResult WebinarsForKurs(int id)
        {
            try
            {
                List<Webinar> existingWebinars = new List<Webinar>();
                using (var context = ApplicationDbContext.Create())
                {
                    existingWebinars = context.Webinars.Where(x => x.Kurses.Select(a => a.KursID).Contains(id)).ToList();
                }
                return PartialView(existingWebinars);
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
                            Id = (int)tmpWebinar.Id,
                            Title = tmpWebinar.Title,
                            Description = tmpWebinar.Description,
                            Duration = tmpWebinar.Duration,
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
        [HttpPost]
        public ActionResult AddEdit(WebinarViewModel model)
        {
            try
            {
                if (model != null)
                {
                    using (var context = ApplicationDbContext.Create())
                    {
                        if (model.Id == 0)
                        {
                            var newWebinar = new Webinar
                            {
                                MimeType = model.MimeType,
                                Title = model.Title,
                                FileName = model.FileName,
                                Description = model.Description,
                                Duration = model.Duration
                            };
                            context.Webinars.Add(newWebinar);
                            context.SaveChangesAsync();
                        }
                        else
                        {
                            var webinar = context.Webinars.First(x => x.Id == model.Id);
                            webinar.Title = model.Title;
                            webinar.Description = model.Description;
                            webinar.Duration = model.Duration;
                            if (!string.IsNullOrEmpty(model.FileName) && !string.IsNullOrEmpty(model.MimeType))
                            {
                                if (!string.IsNullOrEmpty(webinar.FileName) && !string.IsNullOrEmpty(webinar.MimeType))
                                {
                                    string root = Server.MapPath("~/App_Data");
                                    var fullPath = Path.Combine(root, $"{webinar.FileName}.{webinar.MimeType}");
                                    if (System.IO.File.Exists(fullPath))
                                        System.IO.File.Delete(fullPath);
                                }
                                webinar.FileName = model.FileName;
                                webinar.MimeType = model.MimeType;
                            }
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
                WebinarViewModel webinar = new WebinarViewModel();
                using (var context = ApplicationDbContext.Create())
                {
                    var dbWebinar = context.Webinars.FirstOrDefault(x => x.Id == id);
                    if (dbWebinar == null)
                        throw new ArgumentException($@"Webina with id {id} no found");
                    webinar.Description = dbWebinar.Description;
                    webinar.Duration = dbWebinar.Duration;
                    webinar.Title = dbWebinar.Title;
                    webinar.FileName = dbWebinar.FileName;
                    webinar.MimeType = dbWebinar.MimeType;

                }
                return View(webinar);
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }
        [HttpPost]
        public JsonResult AddVideoFile(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string root = Server.MapPath("~/App_Data");
                var videoGuid = Guid.NewGuid().ToString().Replace("_", "").Substring(0, 10);
                var dateString = DateTime.Now.ToString("yyyyMMdd");
                var mimeType = @"mp4";
                var fileName = $"{dateString}_{videoGuid}";

                file.SaveAs(Path.Combine(root, $"{fileName}.{mimeType}"));
                var videoData = new VideoData
                {
                    FileName = fileName,
                    MimeType = mimeType
                };
                return Json(videoData);
            }
            return null;
        }
    }
}