using Library.BLL.Interfaces;
using Library.DAL.Interfaces;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.BLL
{
    public class IssuedBookBLL : IIssuedBookBLL
    {
        private readonly IIssuedBookDAL _IIssuedBookDAL;
        public IssuedBookBLL(IIssuedBookDAL IIssuedBookDAL)
        {
            _IIssuedBookDAL = IIssuedBookDAL;
        }

        public void CreateIssuedBook(IssuedBook newIssuedBook)
        {
            _IIssuedBookDAL.CreateIssuedBook(newIssuedBook);
        }

        public bool FindUserRole(string userId)
        {
            return _IIssuedBookDAL.FindUserRole(userId);
        }

        public List<IssuedBook> GetAllIssuedBooks()
        {
            return _IIssuedBookDAL.GetAllIssuedBooks();
        }
    }
}
