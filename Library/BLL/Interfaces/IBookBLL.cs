using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.BLL.Interfaces
{
    public interface IBookBLL
    {
        List<Book> GetAllBooks();
        void CreateBook(Book newBook);
    }
}
