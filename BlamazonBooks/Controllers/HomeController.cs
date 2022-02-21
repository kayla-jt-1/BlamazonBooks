using BlamazonBooks.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlamazonBooks.Controllers
{
    
    public class HomeController : Controller
    {
        private IBlamazonBooksRepository repo;
        public HomeController (IBlamazonBooksRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index()
        {
            var blah = repo.Books.ToList();
            return View(blah);
        }
    }
}
