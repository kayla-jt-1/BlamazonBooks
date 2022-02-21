using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlamazonBooks.Models
{
    public interface IBlamazonBooksRepository
    {
        IQueryable<Book> Books { get;}
    }
}
