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
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 5;
            var blah = repo.Books
                .OrderBy(t => t.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize);
            return View(blah);
        }
    }
}
