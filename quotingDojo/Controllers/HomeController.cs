using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace quotingDojo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/quotes/")]
        public IActionResult Quotes()
        {
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM quotes ORDER BY created_at DESC");
            ViewBag.allquotes = AllQuotes;
            return View();
        }

        [HttpPost]
        [Route("/quotes/")]
        public IActionResult PostQuotes(string name, string quote)
        {
            DbConnector.Execute($"INSERT INTO quotes (name,quote) VALUES ('{name}', '{quote}')");
            return RedirectToAction("Quotes");
        }
    }
}
