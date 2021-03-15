using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class IssuedBook
    {
        [Key]
        public int IssuedBookId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public string UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
