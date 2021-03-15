using Library.Models;

namespace Library.Services.Interfaces
{
    public interface IBookService
    {
        public BooksViewModel GetAllBooks(string userId);
        public void Create(Book newBook);
        public bool FindUserRole(string userId);
    }
}
