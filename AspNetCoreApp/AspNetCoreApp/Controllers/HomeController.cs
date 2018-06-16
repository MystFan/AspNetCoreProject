using AspNetCoreApp.Data;
using AspNetCoreApp.DomainObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IRepository<Cat> cats)
        {
        }

        public ViewResult Index()
        {
            return View();
        }
    }
}
