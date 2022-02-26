using BlamazonBooks.Models;
using BlamazonBooks.Models.ViewModels;
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
        public IActionResult Index(string category, int pageNum = 1)
        {
            int pageSize = 5;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(t => t.Category == category || category == null)
                .OrderBy(t => t.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks =
                        (category == null
                            ? repo.Books.Count()
                            : repo.Books.Where(x => x.Category == category).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
