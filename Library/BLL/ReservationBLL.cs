using Library.BLL.Interfaces;
using Library.DAL.Interfaces;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.BLL.Interfaces
{
    public class ReservationBLL : IReservationBLL
    {
        private readonly IReservationDAL _IReservationDAL;
        public ReservationBLL(IReservationDAL IReservationDAL)
        {
            _IReservationDAL = IReservationDAL;
        }

        public void CreateReservation(Reservation newReservation)
        {
            _IReservationDAL.CreateReservation(newReservation);
        }

        public bool FindUserRole(string userId)
        {
            return _IReservationDAL.FindUserRole(userId);
        }

        public List<Reservation> GetAllReservations()
        {
            return _IReservationDAL.GetAllReservations();
        }
    }
}
