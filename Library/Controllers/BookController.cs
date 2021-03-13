using Library.Models;
using Library.Services.Interfaces;
using Library.UI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _service;
        public BookController(IBookService service, IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            string userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Index()
        {
            BookViewModel bvm =_service.Index();
            return View(bvm);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book newBook)
        {
            _service.Create(newBook);
            return RedirectToAction("Index");
        }
    }
}
