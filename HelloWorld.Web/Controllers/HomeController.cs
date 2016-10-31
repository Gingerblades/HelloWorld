using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: HelloWorld
        public string Index()
        {
            return "Hello world!";
        }
    }
}