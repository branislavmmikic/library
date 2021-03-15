using Library.Models;

namespace Library.Services.Interfaces
{
    public interface IReservationService
    {
        public ReservationsViewModel GetAllReservations();
        public bool FindUserRole(string userId);
        Result Create(int bookId, string userId);
        void DeleteReservation(int reservationId);
        ReservationsViewModel GetAllReservationsByUser(string userId);
    }
}
