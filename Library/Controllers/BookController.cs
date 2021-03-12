using Library.Models;
using Library.UI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookUI _IBookUI;
        public BookController(IBookUI IBookUI)
        {
            _IBookUI = IBookUI;
        }
        public IActionResult Index()
        {
            var books = _IBookUI.GetAllBooks();
            BookViewModel bvm = new BookViewModel();
            bvm.books = books;
            return View(bvm);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book newBook)
        {
            _IBookUI.CreateBook(newBook);
            return RedirectToAction("Index");
        }
    }
}
