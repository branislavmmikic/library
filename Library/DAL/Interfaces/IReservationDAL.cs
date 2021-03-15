using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface IReservationDAL
    {
        bool FindUserRole(string userId);
        void CreateReservation(Reservation newReservation);
        List<Reservation> GetAllReservations();
        bool IsBookReservedByUser(int bookId, string userId);
        List<Reservation> GetAllReservationsByUser(string userId);
        void DeleteReservation(int reservationId);
        string GetBookTitleById(int id);
        string GetUserNameById(string id);
    }
}
