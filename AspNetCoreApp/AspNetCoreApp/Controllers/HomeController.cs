using AspNetCoreApp.Data;
using AspNetCoreApp.DomainObjects;
using AspNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private const int ItemsPerPage = 3;
        private readonly IRepository<Cat> cats;

        public HomeController(IRepository<Cat> cats)
        {
            this.cats = cats;
        }

        public ViewResult Index(int page = 1)
        {
            var result = new CatListViewModel()
            {
                Cats = this.cats
                    .All()
                    .Select(c => new CatModel() { Id = c.Id, Name = c.Name })
                    .Skip((page - 1) * ItemsPerPage)
                    .Take(ItemsPerPage),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = ItemsPerPage,
                    TotalItems = cats.All().Count()
                }
            };

            return View(result);
        }
    }
}
