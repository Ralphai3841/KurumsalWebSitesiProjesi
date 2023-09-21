using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KurumsalWebSitesiProjesi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        public IActionResult Index()
        {
            var value = contactManager.TGetList().OrderByDescending(x => x.ContactID).ToList();
            return View(value);
        }
        
        public IActionResult Detail(int id)
        {
            var value = contactManager.TGetContactById(id);
            return View(value);
        }

        public IActionResult Delete(int id)
        {
            var valueId = contactManager.TGetById(id);
            contactManager.TDelete(valueId);
            return RedirectToAction("Index");
        }
    }
}
