using Library.Models;
using Library.Services.Interfaces;
using Library.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationUI _IReservationUI;
        public ReservationService(IReservationUI IReservationUI)
        {
            _IReservationUI = IReservationUI;
        }
        public ReservationViewModel Index()
        {
            var reservations = _IReservationUI.GetAllReservations();
            ReservationViewModel rvm = new ReservationViewModel();
            rvm.reservations = reservations;
            return rvm;
        }
        public void Create(Reservation newReservation)
        {
            _IReservationUI.CreateReservation(newReservation);
        }

        public bool FindUserRole(string userId)
        {
            return _IReservationUI.FindUserRole(userId);
        }
    }
}
