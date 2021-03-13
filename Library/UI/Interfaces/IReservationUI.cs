using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.UI.Interfaces
{
    public interface IReservationUI
    {
        List<Reservation> GetAllReservations();
        bool FindUserRole(string userId);
        void CreateReservation(Reservation newReservation);
    }
}
