using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BYUAmazon.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem (Book book, int qty)
        {
            CartLine line = Lines.Where(p => p.Book.BookID == book.BookID).FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveLine(Book book) =>
            Lines.RemoveAll(x => x.Book.BookID == book.BookID);

        public virtual void Clear() => Lines.Clear();
        public decimal ComputeTotalSum() => (decimal)Lines.Sum(e => e.Book.price * e.Quantity);
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }

    }
}
