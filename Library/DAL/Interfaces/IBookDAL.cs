using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface IBookDAL
    {
        List<Book> GetAllBooks();
        void CreateBook(Book newBook);
    }
}
