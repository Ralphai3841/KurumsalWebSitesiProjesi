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
    public class AdminController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        public IActionResult Index()
        {
            var values = adminManager.TGetList();
            return View(values);
        }

        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Add(Admin admin)
        {
            adminManager.TAdd(admin);
            return RedirectToAction("Index");

        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            var valueId = adminManager.TGetById(id);
            return View(valueId);
        }

        [HttpPost]

        public IActionResult Edit(Admin admin)
        {
            adminManager.TUpdate(admin);
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var valueId = adminManager.TGetById(id);
            adminManager.TDelete(valueId);
            return RedirectToAction("Index");
        }
    }
}
