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
        private ApplicationDbContext _context;
        public BookDAL(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateBook(Book newBook)
        {
            _context.Books.Add(newBook);
            _context.SaveChanges();
        }

        public bool FindUserRole(string userId)
        {
            var role = _context.UserRoles.Where(x => x.UserId == userId).FirstOrDefault();
            if (role.RoleId == "1") return true;
            else return false;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }
    }
}
