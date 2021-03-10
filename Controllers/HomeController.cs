using BYUAmazon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BYUAmazon.Models.ViewModels;

namespace BYUAmazon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBookRepository _repository;
        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int pageNum = 1)
        {

            //pass database information about books to info page
            return View(new BookListViewModel
            {
                //Pass database as well as number of pages needed to dynamically create html page
                Books = _repository.Books
                    .Where(p => category == null || p.category == category)
                    .OrderBy(p => p.BookID)
                    .Skip((pageNum - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = PageSize,
                    //dynamically create the pages according to category if category is present
                    TotalNumItems = category == null ? _repository.Books.Count() :
                        _repository.Books.Where(x => x.category == category).Count()
                },
                Category = category
            });
                
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
