using Cinematron.DAL.Contracts;
using Cinematron.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cinematron.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearchService _searchSerivce;
        public HomeController(ILogger<HomeController> logger, ISearchService searchSerivce)
        {
            _searchSerivce = searchSerivce;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [Route("[Action]")]
        public IActionResult Movies()
        {
            return View();
        }
        [Route("[Action]")]
        public IActionResult Series()
        {
            return View();
        }
        [Route("[Action]")]
        [HttpPost]
        public IActionResult Search(string query)
        { 
            var watchables = _searchSerivce.Search(query.Trim());
            return View(watchables);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
