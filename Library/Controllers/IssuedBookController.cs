using Library.Models;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Authorize]
    public class IssuedBookController : Controller
    {
        private readonly IIssuedBookService _service;
        public IssuedBookController(IIssuedBookService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (_service.FindUserRole(userId).Equals(true))
            {
                IssuedBooksViewModel bvm = _service.GetAllIssuedBook();
                return View(bvm);
            }
            else
            {
                IssuedBooksViewModel bvm = _service.GetAllIssuedBooksByUser(userId);
                return View("UserIndex", bvm);
            }
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult UserIndex(IssuedBookViewModel bvm)
        {
            return View(bvm);
        }
        //[HttpPost]
        //public ActionResult Create(IssuedBook newIssuedBook)
        //{
        //    _service.Create(newIssuedBook);
        //    return RedirectToAction("Reservation");
        //}
        public IActionResult CreateIssuedBook([FromForm(Name = "reservationId")] int ReservationId, [FromForm(Name = "userId")] string UserId, [FromForm(Name = "bookId")] int BookId)
        {
            _service.CreateIssuedBook(ReservationId, UserId, BookId);
            return RedirectToAction("Index", "Reservation");
        }
        [HttpPost]
        public IActionResult ReturnBook([FromForm(Name = "issuedBookId")] int IssuedBookId)
        {
            _service.ReturnBook(IssuedBookId);
            return RedirectToAction("Index", "IssuedBook");
        }
    }
}
