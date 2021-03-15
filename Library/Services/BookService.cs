using Library.DAL.Interfaces;
using Library.Models;
using Library.Services.Interfaces;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly IBookDAL _IBookDAL;
        public BookService(IBookDAL IBookDAL)
        {
            _IBookDAL = IBookDAL;
        }
        public BooksViewModel GetAllBooks(string userId)
        {
            var books = _IBookDAL.GetAllBooks();
            bool res;
            BookViewModel newBook;
            BooksViewModel bvm = new BooksViewModel();
            foreach(var b in books)
            {
                res = _IBookDAL.IsReservable(b.BookId, userId);
                newBook = new BookViewModel() { Author = b.Author, BookId = b.BookId, Quantity = b.Quantity, Title = b.Title, Clickable = res };
                bvm.Books.Add(newBook);
            }
            return bvm;
        }
        public void Create(Book newBook)
        {
            _IBookDAL.CreateBook(newBook);
        }

        public bool FindUserRole(string userId)
        {
            return _IBookDAL.FindUserRole(userId);
        }

    }
}
