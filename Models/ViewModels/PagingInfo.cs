using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BYUAmazon.Models.ViewModels
{
    public class PagingInfo
    {
        //Set variables to keep track of pages and how many are needed
        public int TotalNumItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        //Determine how many pages will be displayed

        public int TotalPages => (int)(Math.Ceiling((decimal) TotalNumItems / ItemsPerPage));
    }
}
