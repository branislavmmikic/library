using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IBookService
    {
        public BookViewModel Index();
        public void Create(Book newBook);
        public bool FindUserRole(string userId);
    }
}
