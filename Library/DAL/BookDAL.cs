using Library.DAL.Interfaces;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public Book GetBookById(int bookId)
        {
            return _context.Books.FirstOrDefault(b => b.BookId == bookId);
        }

        public void UpdateBook(Book book)
        {
            var dbBook = _context.Books.FirstOrDefault(b => b.BookId == book.BookId);
            if (dbBook != null)
            {
                dbBook.Author = book.Author;
                dbBook.Quantity = book.Quantity;
                dbBook.Title = book.Title;
                _context.SaveChanges();
            }
        }
        public List<Reservation> GetAllReservationsByUser(string userId)
        {
            return _context.Reservations.Where(r => r.UserId == userId).ToList();
        }

        public bool IsBookReservedByUser(int bookId, string userId)
        {
            return _context.Reservations.FirstOrDefault(r => r.UserId == userId && r.BookId == bookId) != null;
        }
        public bool IsBookIssuedToUser(int bookId, string userId)
        {
            return _context.IssuedBooks.FirstOrDefault(r => r.UserId == userId && r.BookId == bookId) != null;
        }
        public bool IsReservable(int bookId, string Id)
        {
            List<Reservation> list = GetAllReservationsByUser(Id);
            Book b = GetBookById(bookId);
            if (IsBookReservedByUser(bookId, Id) == true) return false;
            else if (list.Count > 4) return false;
            else if (b.Quantity < 1) return false;
            else if (IsBookIssuedToUser(bookId, Id) == true) return false;
            return true;
        }
    }
}
