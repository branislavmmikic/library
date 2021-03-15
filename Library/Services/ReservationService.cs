using Library.DAL.Interfaces;
using Library.Models;
using Library.Services.Interfaces;
using Library.SignarR;
using Microsoft.AspNetCore.SignalR;
using System;

namespace Library.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationDAL _IReservationDAL;
        private readonly IBookDAL _bookDal;
        private readonly IHubContext<SignalRHub> _signalRHub;
        public ReservationService(
            IReservationDAL reservationDAL,
            IBookDAL bookDal,
            IHubContext<SignalRHub> signalRHub)
        {
            _IReservationDAL = reservationDAL;
            _bookDal = bookDal;
            _signalRHub = signalRHub;
        }
        public ReservationsViewModel GetAllReservations()
        {
            var reservations = _IReservationDAL.GetAllReservations();
            ReservationViewModel newRes;
            ReservationsViewModel rvm = new ReservationsViewModel();
            if (reservations != null)
                foreach (var r in reservations)
                {
                    var title = _IReservationDAL.GetBookTitleById(r.BookId);
                    var userName = _IReservationDAL.GetUserNameById(r.UserId);
                    newRes = new ReservationViewModel() {ReservationId = r.ReservationId, BookTitle = title, UserName = userName, BookId = r.BookId, UserId = r.UserId};
                    rvm.Reservations.Add(newRes);
                }
            return rvm;
        }
        public ReservationsViewModel GetAllReservationsByUser(string userId)
        {
            var reservations = _IReservationDAL.GetAllReservationsByUser(userId);
            ReservationViewModel newRes;
            ReservationsViewModel rvm = new ReservationsViewModel();
            if(reservations != null)
                foreach (var r in reservations)
                {
                    var title = _IReservationDAL.GetBookTitleById(r.BookId);
                    var userName = _IReservationDAL.GetUserNameById(r.UserId);
                    newRes = new ReservationViewModel() { ReservationId = r.ReservationId, BookTitle = title, UserName = userName, BookId = r.BookId, UserId = r.UserId };
                    rvm.Reservations.Add(newRes);
                }
            return rvm;
        }
        public Result Create(int bookId, string userId)
        {
            if (_IReservationDAL.IsBookReservedByUser(bookId, userId)) 
            {
                throw new Exception("Book is already reserved by user");
            }

            var book = _bookDal.GetBookById(bookId);
            if (book == null)
            {
                throw new Exception("The book does not exist.");
            }

            if (book.Quantity < 1)
            {
                throw new Exception("There are no available book units");
            }


            var reservation = new Reservation() { BookId = bookId, UserId = userId};
            _IReservationDAL.CreateReservation(reservation);
            --book.Quantity;
            _bookDal.UpdateBook(book);
            _signalRHub.Clients.All.SendAsync("ReservationCreated", reservation.ReservationId, reservation.BookId, reservation.UserId, _IReservationDAL.GetBookTitleById(reservation.BookId), _IReservationDAL.GetUserNameById(reservation.UserId));
            Console.WriteLine(reservation.ReservationId);
            return Result.Success;
        }

        public bool FindUserRole(string userId)
        {
            return _IReservationDAL.FindUserRole(userId);
        }

        public void DeleteReservation(int ReservationId)
        {
            _IReservationDAL.DeleteReservation(ReservationId);
        }
    }
}
