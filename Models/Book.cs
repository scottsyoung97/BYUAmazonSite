using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BYUAmazon.Models
{
    public class Book
    {
        //Create Primary Key for Book
        [Key]
        [Required]
        public int BookID { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string authorFirst { get; set; }
        public string authorMiddle { get; set; }
        [Required]
        public string authorLast { get; set; }
        [Required]
        public string publisher { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        [RegularExpression(@"^\d{3}-\d{10}$")]
        public string classification { get; set; }
        [Required]
        public string category { get; set; }
        [Required]
        public double price { get; set; }

    }
}
