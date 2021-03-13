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
    }
}
