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
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        public IActionResult Index()
        {
            var value = serviceManager.TGetList();
            return View(value);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Add(Service service)
        {
            if (ModelState.IsValid)
            {
                serviceManager.TAdd(service);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            var valueId = serviceManager.TGetById(id);
            return View(valueId);
        }

        [HttpPost]

        public IActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                serviceManager.TUpdate(service);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var valueId = serviceManager.TGetById(id);
            serviceManager.TDelete(valueId);
            return RedirectToAction("Index");

        }
    }
}
