using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Api.Models;

namespace HelloWorld.Api.Controllers
{ 
    public class HomeController : Controller
    {
        private HelloWorldRepository repo = HelloWorldRepository.Current;

        public ViewResult Index()
        {
            return View(repo.GetAll());
        }
        public ActionResult Add(Models.HelloWorld item)
        {
            if(ModelState.IsValid)
            {
                repo.Add(item);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Remove(int id)
        {
            repo.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Update(Models.HelloWorld item)
        {
            if(ModelState.IsValid && repo.Update(item))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }
    }
}