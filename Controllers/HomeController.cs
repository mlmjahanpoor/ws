using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string Name,string Family)
        {
            var files = Request.Form.Files.Count;
            List<IFormFile> images = new List<IFormFile>();

            for (int i = 0; i < files; i++)
            {
                images.Add(Request.Form.Files[i]);
            }
            return Json(Name+" "+Family+"->"+files);
        }
    }
}
