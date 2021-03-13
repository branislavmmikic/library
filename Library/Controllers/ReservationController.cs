using Library.Models;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _service;
        private readonly string _userId;
        public ReservationController(IReservationService service, IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            _userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public IActionResult Index()
        {
            ReservationViewModel bvm = _service.Index();
            if (_service.FindUserRole(_userId).Equals(true))
                return View(bvm);
            else
                return NotFound();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Reservation newReservation)
        {
            _service.Create(newReservation);
            return RedirectToAction("Index");
        }
    }
}
