using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BYUAmazon.Infrastructure;
using BYUAmazon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BYUAmazon.Pages
{
    public class BuyModel : PageModel
    {
        private IBookRepository repository;

        public BuyModel (IBookRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost (long bookId, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(p => p.BookID == bookId);

            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(book, 1);

            //HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl => 
                cl.Book.BookID == bookId).Book);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
