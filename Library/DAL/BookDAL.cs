using Library.DAL.Interfaces;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class BookDAL : IBookDAL
    {
        private readonly ApplicationDbContext _context;
        public BookDAL(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateBook(Book newBook)
        {
            _context.Books.Add(newBook);
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }
    }
}
