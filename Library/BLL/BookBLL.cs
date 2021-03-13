using Library.BLL.Interfaces;
using Library.DAL.Interfaces;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.BLL
{
    public class BookBLL : IBookBLL
    {
        private readonly IBookDAL _IBookDAL;
        public BookBLL(IBookDAL IBookDAL)
        {
            _IBookDAL = IBookDAL;
        }

        public void CreateBook(Book newBook)
        {
            _IBookDAL.CreateBook(newBook);
        }

        public bool FindUserRole(string userId)
        {
            return _IBookDAL.FindUserRole(userId);
        }

        public List<Book> GetAllBooks()
        {
            return _IBookDAL.GetAllBooks();
        }
    }
}
