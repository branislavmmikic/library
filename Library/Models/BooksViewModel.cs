using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BooksViewModel
    {
        public List<BookViewModel> Books { get; set; } = new List<BookViewModel>();
        public string Error { get; set; }
        public bool IsError => !string.IsNullOrEmpty(Error);
    }
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
        public bool Clickable { get; set; }
    }
}
