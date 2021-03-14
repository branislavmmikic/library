using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.BLL.Interfaces
{
    public interface IIssuedBookBLL
    {
        List<IssuedBook> GetAllIssuedBooks();
        void CreateIssuedBook(IssuedBook newIssuedBook);
        bool FindUserRole(string userId);
    }
}
