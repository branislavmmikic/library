using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface IBookDAL
    {
        List<Book> GetAllBooks();
        void CreateBook(Book newBook);
        bool FindUserRole(string userId);
        Book GetBookById(int bookId);
        void UpdateBook(Book book);
        bool IsBookReservedByUser(int bookId, string userId);
        List<Reservation> GetAllReservationsByUser(string userId);
        public bool IsReservable(int bookId, string Id);
    }
}
