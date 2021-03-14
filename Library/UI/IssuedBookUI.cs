using Library.BLL.Interfaces;
using Library.Models;
using Library.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.UI
{
    public class IssuedBookUI : IIssuedBookUI
    {
            private readonly IIssuedBookBLL _IIssuedBookBLL;
            public IssuedBookUI(IIssuedBookBLL IIssuedBookBLL)
            {
                _IIssuedBookBLL = IIssuedBookBLL;
            }

            public bool FindUserRole(string userId)
            {
                return _IIssuedBookBLL.FindUserRole(userId);
            }

            public void CreateIssuedBook(IssuedBook newIssuedBook)
            {
                _IIssuedBookBLL.CreateIssuedBook(newIssuedBook);
            }

            List<IssuedBook> IIssuedBookUI.GetAllIssuedBooks()
            {
                return _IIssuedBookBLL.GetAllIssuedBooks();
            }
    }
}
