using Library.Models;

namespace Library.Services.Interfaces
{
    public interface IIssuedBookService
    {
        public bool FindUserRole(string userId);
        void CreateIssuedBook(int reservationId, string userId, int bookId);
        public IssuedBooksViewModel GetAllIssuedBooksByUser(string userId);
        public IssuedBooksViewModel GetAllIssuedBook();
        void ReturnBook(int issuedBook);
    }
}
