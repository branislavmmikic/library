using Library.Models;
using Library.Services.Interfaces;
using Library.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class IssuedBookService : IIssuedBookService
    {
        private readonly IIssuedBookUI _IIssuedBookUI;
        public IssuedBookService(IIssuedBookUI IIssuedBookUI)
        {
            _IIssuedBookUI = IIssuedBookUI;
        }
        public IssuedBookViewModel Index()
        {
            var issuedBooks = _IIssuedBookUI.GetAllIssuedBooks();
            IssuedBookViewModel ibvm = new IssuedBookViewModel();
            ibvm.issuedBooks = issuedBooks;
            return ibvm;
        }
        public void Create(IssuedBook newIssuedBook)
        {
            _IIssuedBookUI.CreateIssuedBook(newIssuedBook);
        }

        public bool FindUserRole(string userId)
        {
            return _IIssuedBookUI.FindUserRole(userId);
        }
    }
}
