using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class IssuedBooksViewModel
    {
        public List<IssuedBookViewModel> IssuedBooks = new List<IssuedBookViewModel>();
    }
    public class IssuedBookViewModel
    {
        public int IssuedBookId { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public string BookTitle { get; set; }
    }
}
