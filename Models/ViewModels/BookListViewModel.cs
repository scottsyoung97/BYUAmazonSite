using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BYUAmazon.Models.ViewModels
{
    public class BookListViewModel
    {
        //create books enumerable to populate html
        public IEnumerable<Book> Books { get; set;}

        //create paging info to pass information about size of page

        public PagingInfo PagingInfo { get; set; }

    }
}
