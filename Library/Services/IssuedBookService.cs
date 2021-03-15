using Library.DAL.Interfaces;
using Library.Models;
using Library.Services.Interfaces;
using Library.SignarR;
using Microsoft.AspNetCore.SignalR;

namespace Library.Services
{
    public class IssuedBookService : IIssuedBookService
    {
        private readonly IIssuedBookDAL _IIssuedBookDAL;
        private readonly IHubContext<SignalRHub> _signalRHub;
        public IssuedBookService(IIssuedBookDAL IIssuedBookDAL, IHubContext<SignalRHub> signalRHub)
        {
            _IIssuedBookDAL = IIssuedBookDAL;
            _signalRHub = signalRHub;
        }
        public IssuedBooksViewModel GetAllIssuedBook()
        {
            var issuedBooks = _IIssuedBookDAL.GetAllIssuedBooks();
            IssuedBookViewModel newRes;
            IssuedBooksViewModel rvm = new IssuedBooksViewModel();
            if (issuedBooks != null)
                foreach (var r in issuedBooks)
                {
                    var title = _IIssuedBookDAL.GetBookTitleById(r.BookId);
                    var userName = _IIssuedBookDAL.GetUserNameById(r.UserId);
                    newRes = new IssuedBookViewModel() { Date = r.Date,  BookTitle = title, UserName = userName, BookId = r.BookId, UserId = r.UserId, IssuedBookId = r.IssuedBookId };
                    rvm.IssuedBooks.Add(newRes);
                }
            return rvm;
        }
        public IssuedBooksViewModel GetAllIssuedBooksByUser(string userId)
        {
            var issuedBooks = _IIssuedBookDAL.GetAllIssuedBooksByUser(userId);
            IssuedBookViewModel newRes;
            IssuedBooksViewModel rvm = new IssuedBooksViewModel();
            if (issuedBooks != null)
                foreach (var r in issuedBooks)
                {
                    var title = _IIssuedBookDAL.GetBookTitleById(r.BookId);
                    var userName = _IIssuedBookDAL.GetUserNameById(r.UserId);
                    newRes = new IssuedBookViewModel() { Date = r.Date, BookTitle = title, UserName = userName, BookId = r.BookId, UserId = r.UserId, IssuedBookId = r.IssuedBookId };
                    rvm.IssuedBooks.Add(newRes);
                }
            return rvm;
        }
        public bool FindUserRole(string userId)
        {
            return _IIssuedBookDAL.FindUserRole(userId);
        }

        public void CreateIssuedBook(int reservationId, string userId, int bookId)
        {
            _IIssuedBookDAL.DeleteReservation(reservationId);
            _signalRHub.Clients.All.SendAsync("IssuedBookCreated", reservationId);
            _IIssuedBookDAL.CreateIssuedBook(userId, bookId);
        }

        public void ReturnBook(int issuedBook)
        {
            IssuedBook ReturnedBook = _IIssuedBookDAL.ReturnBook(issuedBook);
        }
    }
}
