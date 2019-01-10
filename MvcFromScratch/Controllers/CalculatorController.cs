using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcFromScratch.Model;

namespace MvcFromScratch.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Square(int value) {
            int result = value * value;
            var viewModel = new ResultViewModel(result);
            return View(viewModel);
        }

        public IActionResult ConvertCurrency(string currencyIn, string currencyOut, int qty ) {
            return Content($"from {currencyIn} to {currencyOut} count: {qty}");
        }
    }
}