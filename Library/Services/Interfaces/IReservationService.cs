using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IReservationService
    {
        public ReservationViewModel Index();
        public void Create(Reservation newReservation);
        public bool FindUserRole(string userId);
    }
}
