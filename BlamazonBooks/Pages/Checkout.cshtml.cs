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
        public string ReturnUrl { get; set; }
        public void OnGet()
        {
            // the URL to get back to where we were
            ReturnUrl = ReturnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl});
;       }
    }
}
