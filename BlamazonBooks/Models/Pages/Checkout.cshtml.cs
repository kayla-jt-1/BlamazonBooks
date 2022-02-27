using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlamazonBooks.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlamazonBooks.Models.Pages
{
    public class CheckoutModel : PageModel
    {
        // pull in data
        private IBlamazonBooksRepository repo { get; set; }
        
        // constructor loads the data
        public CheckoutModel (IBlamazonBooksRepository temp)
        {
            repo = temp;
        }
        public Basket basket { get; set; }
        public void OnGet()
        {
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }
        public IActionResult OnPost(int bookId)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            // if basket already exists, load the data. If not, create a new basket
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(b, 1);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage();
;       }
    }
}
