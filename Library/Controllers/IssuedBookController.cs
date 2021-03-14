using Library.Models;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class IssuedBookController : Controller
    {
        private readonly IIssuedBookService _service;
        private readonly string _userId;
        public IssuedBookController(IIssuedBookService service, IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            _userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Index()
        {
            IssuedBookViewModel bvm = _service.Index();
            if (_service.FindUserRole(_userId).Equals(true))
                return View(bvm);
            else
                return View("UserIndex", bvm);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult UserIndex(IssuedBookViewModel bvm)
        {
            return View(bvm);
        }
        [HttpPost]
        public ActionResult Create(IssuedBook newIssuedBook)
        {
            _service.Create(newIssuedBook);
            return RedirectToAction("Index");
        }
    }
}
