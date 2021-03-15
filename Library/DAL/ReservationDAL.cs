using Library.DAL.Interfaces;
using Library.Data;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class ReservationDAL : IReservationDAL
    {
        private ApplicationDbContext _context;
        public ReservationDAL(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateReservation(Reservation newReservation)
        {
            _context.Reservations.Add(newReservation);
            _context.SaveChanges();
        }

        public void DeleteReservation(int reservationId)
        {
            var res = _context.Reservations.Where(r => r.ReservationId == reservationId).FirstOrDefault();
            if(res != null)
            {
                var book = _context.Books.Where(r => r.BookId == res.BookId).FirstOrDefault();
                if (book != null)
                    ++book.Quantity;
                _context.Remove(res);
                _context.SaveChanges();
            }
        }

        public bool FindUserRole(string userId)
        {
            var role = _context.UserRoles.Where(x => x.UserId == userId).FirstOrDefault();
            if (role.RoleId == "1") return true;
            else return false;
        }

        public List<Reservation> GetAllReservations()
        {
            return _context.Reservations.ToList();
        }

        public List<Reservation> GetAllReservationsByUser(string userId)
        {
            return _context.Reservations.Where(r => r.UserId == userId).ToList();
        }

        public string GetBookTitleById(int id)
        {
            return _context.Books.Where(r => r.BookId == id).FirstOrDefault().Title.ToString();
        }

        public string GetUserNameById(string id)
        {
            return _context.Users.Where(r => r.Id == id).FirstOrDefault().UserName.ToString();
        }

        public bool IsBookReservedByUser(int bookId, string userId)
        {
            return _context.Reservations.FirstOrDefault(r => r.UserId == userId && r.BookId == bookId) != null;
        }
    }
}
