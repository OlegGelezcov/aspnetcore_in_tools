using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcFromScratch.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult SaveUser()
            => View(new UserBindingModel());

        [HttpPost]
        public IActionResult SaveUser(UserBindingModel model) {
            if(false == ModelState.IsValid) {
                return View(model);
            }
            return RedirectToAction("Success");
        }

        public IActionResult Success()
            => View();
    }
}