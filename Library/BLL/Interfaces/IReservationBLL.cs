using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.BLL.Interfaces
{
    public interface IReservationBLL
    {
        List<Reservation> GetAllReservations();
        bool FindUserRole(string userId);
        void CreateReservation(Reservation newReservation);
    }
}
