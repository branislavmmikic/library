using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IIssuedBookService
    {
        public IssuedBookViewModel Index();
        public void Create(IssuedBook newIssuedBook);
        public bool FindUserRole(string userId);
    }
}
