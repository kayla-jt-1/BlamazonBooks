using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlamazonBooks.Models
{
    public class EFBlamazonBooksRepository : IBlamazonBooksRepository
    {
        private BookstoreContext context { get; set; }

        public EFBlamazonBooksRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
