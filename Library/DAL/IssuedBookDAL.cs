using Library.DAL.Interfaces;
using Library.Data;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class IssuedBookDAL : IIssuedBookDAL
    {
        private ApplicationDbContext _context;
        public IssuedBookDAL(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateIssuedBook(IssuedBook newIssuedBook)
        {
            _context.IssuedBooks.Add(newIssuedBook);
            _context.SaveChanges();
        }

        public bool FindUserRole(string userId)
        {
            var role = _context.UserRoles.Where(x => x.UserId == userId).FirstOrDefault();
            if (role.RoleId == "1") return true;
            else return false;
        }

        public List<IssuedBook> GetAllIssuedBooks()
        {
            return _context.IssuedBooks.ToList();
        }
        public void DeleteReservation(int reservationId)
        {
            var res = _context.Reservations.Where(r => r.ReservationId == reservationId).FirstOrDefault();
            if (res != null)
            {
                _context.Remove(res);
                _context.SaveChanges();
            }
        }

        public void CreateIssuedBook(string userId, int bookId)
        {
            IssuedBook ib = new IssuedBook() { BookId = bookId, UserId = userId, Date = DateTime.Today.AddMonths(1) };
            _context.IssuedBooks.Add(ib);
            _context.SaveChanges();
        }

        public string GetBookTitleById(int id)
        {
            return _context.Books.Where(r => r.BookId == id).FirstOrDefault().Title.ToString();
        }

        public string GetUserNameById(string id)
        {
            return _context.Users.Where(r => r.Id == id).FirstOrDefault().UserName.ToString();
        }

        public List<IssuedBook> GetAllIssuedBooksByUser(string userId)
        {
            return _context.IssuedBooks.Where(r => r.UserId == userId).ToList();
        }

        public IssuedBook ReturnBook(int BookIssueId)
        {
            var res = _context.IssuedBooks.Where(r => r.IssuedBookId == BookIssueId).FirstOrDefault();
            if (res != null)
            {
                var book = _context.Books.Where(r => r.BookId == res.BookId).FirstOrDefault();
                if (book != null)
                    ++book.Quantity;
                _context.Remove(res);
                _context.SaveChanges();
            }
            return res;
        }
    }
}
