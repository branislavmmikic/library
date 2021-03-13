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
    }
}
