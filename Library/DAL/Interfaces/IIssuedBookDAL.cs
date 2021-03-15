using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface IIssuedBookDAL
    {
        List<IssuedBook> GetAllIssuedBooks();
        bool FindUserRole(string userId);
        public void DeleteReservation(int reservationId);
        void CreateIssuedBook(string userId, int bookId);
        string GetBookTitleById(int bookId);
        string GetUserNameById(string userId);
        List<IssuedBook> GetAllIssuedBooksByUser(string userId);
        IssuedBook ReturnBook(int issuedBook);
    }
}
