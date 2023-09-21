using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KurumsalWebSitesiProjesi.Controllers
{
    public class PersonelController : Controller
    {
        PersonelManager personelManager = new PersonelManager(new EfPersonelDal());
        public IActionResult Index()
        {
            var value = personelManager.TGetList();
            return View(value);
        }

        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        
        public IActionResult Add(Personel personel)
        {
            if (ModelState.IsValid)
            {
                personelManager.TAdd(personel);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
