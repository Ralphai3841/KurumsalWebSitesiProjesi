using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using KurumsalWebSitesiProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KurumsalWebSitesiProjesi.Controllers
{
    public class AboutController : Controller
    {
        Context context = new Context();
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        [HttpGet]
        public IActionResult Index(int id)
        {
            var value = aboutManager.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Index(About about, AboutViewModel aboutViewModel)
        {
            var aboutValue = context.Abouts.Find(about.AboutID);
            if (aboutViewModel.ImageUrl != null)
            {
                var extension = Path.GetExtension(aboutViewModel.ImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/About", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                aboutViewModel.ImageUrl.CopyTo(stream);
                about.ImageUrl = "/Images/About/" + newimagename;
                aboutManager.TUpdate(about);
                return RedirectToAction("Index");
            }
            else
            {
                aboutValue.Title = about.Title;
                aboutValue.Description = about.Description;
                aboutValue.Description2 = about.Description2;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }
    }
}
