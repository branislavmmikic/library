using Library.BLL.Interfaces;
using Library.Models;
using Library.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.UI
{
    public class ReservationUI : IReservationUI
    {
        private readonly IReservationBLL _IReservationBLL;
        public ReservationUI(IReservationBLL IReservationBLL)
        {
            _IReservationBLL = IReservationBLL;
        }
        public bool FindUserRole(string userId)
        {
            return _IReservationBLL.FindUserRole(userId);
        }

        void IReservationUI.CreateReservation(Reservation newReservation)
        {
            _IReservationBLL.CreateReservation(newReservation);
        }
        List<Reservation> IReservationUI.GetAllReservations()
        {
            return _IReservationBLL.GetAllReservations();
        }
    }
}
