using Library.BLL.Interfaces;
using Library.Models;
using Library.UI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.UI
{
    public class BookUI : IBookUI
    {
        private readonly IBookBLL _IBookBLL;
        public BookUI(IBookBLL IBookBLL)
        {
            _IBookBLL = IBookBLL;
        }
        void IBookUI.CreateBook(Book newBook)
        {
            _IBookBLL.CreateBook(newBook);
        }

        List<Book> IBookUI.GetAllBooks()
        {
            return _IBookBLL.GetAllBooks();
        }
    }
}
