using Library.Models;
using Library.Services.Interfaces;
using Library.UI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly IBookUI _IBookUI;
        public BookService(IBookUI IBookUI)
        {
            _IBookUI = IBookUI;
        }
        public BookViewModel Index()
        {
            var books = _IBookUI.GetAllBooks();
            BookViewModel bvm = new BookViewModel();
            bvm.books = books;
            return bvm;
        }
        public void Create(Book newBook)
        {
            _IBookUI.CreateBook(newBook);
        }

        public bool FindUserRole(string userId)
        {
            return _IBookUI.FindUserRole(userId);
        }
    }
}
