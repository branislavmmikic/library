﻿using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface IIssuedBookDAL
    {
        List<IssuedBook> GetAllIssuedBooks();
        void CreateIssuedBook(IssuedBook newIssuedBook);
        bool FindUserRole(string userId);
    }
}
