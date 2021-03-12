using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.UI.Interfaces
{
    public interface IBookUI
    {
        List<Book> GetAllBooks();
        public void CreateBook(Book newBook);
    }
}
