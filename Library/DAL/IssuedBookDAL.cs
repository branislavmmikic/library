using Library.DAL.Interfaces;
using Library.Data;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class IssuedBookDAL : IIssuedBookDAL
    {
        private ApplicationDbContext _context;
        public IssuedBookDAL(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateIssuedBook(IssuedBook newIssuedBook)
        {
            _context.IssuedBooks.Add(newIssuedBook);
            _context.SaveChanges();
        }

        public bool FindUserRole(string userId)
        {
            var role = _context.UserRoles.Where(x => x.UserId == userId).FirstOrDefault();
            if (role.RoleId == "1") return true;
            else return false;
        }

        public List<IssuedBook> GetAllIssuedBooks()
        {
            return _context.IssuedBooks.ToList();
        }
    }
}
