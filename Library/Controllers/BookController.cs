using Library.Models;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService _service;
        private readonly IReservationService _reservationService;
        public BookController(IBookService service, IReservationService reservationService)
        {
            _service = service;
            _reservationService = reservationService;
        }
        public async Task<IActionResult> Index()
        {
            var authResult = await HttpContext.AuthenticateAsync();
            var userId = authResult.Principal.FindFirst(ClaimTypes.NameIdentifier).Value;
            BooksViewModel bvm =_service.GetAllBooks(userId);
            if (_service.FindUserRole(userId).Equals(true))
                return View(bvm);
            else
                return View("UserIndex", bvm);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult UserIndex(BooksViewModel bvm)
        {
            return View(bvm);
        }
        [HttpPost]
        public IActionResult Create(Book newBook)
        {
            _service.Create(newBook);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromForm(Name = "bookId")] int bookId)
        {
            var authResult = await HttpContext.AuthenticateAsync();
            var userId = authResult.Principal.FindFirst(ClaimTypes.NameIdentifier).Value.ToString();
            var result = _reservationService.Create(bookId, userId);
            return RedirectToAction("Index", "Book");
        }
    }
}
