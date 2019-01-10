using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFromScratch {
    public class CurrencyController : Controller {

        public IActionResult Index() {
            var url = Url.Action("View", "Currency", new { code = "USD" });
            return Content($"The URL is {url}");
        }

        public IActionResult View(string code)
            => Content($"View: {code}");
    }
}
