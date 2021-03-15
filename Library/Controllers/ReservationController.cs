using Library.Models;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IReservationService _service;
        public ReservationController(IReservationService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (_service.FindUserRole(userId).Equals(true))
            {
                var bvm = _service.GetAllReservations();
                return View(bvm);
            }
            else
            {
                var bvm = _service.GetAllReservationsByUser(userId);
                return View("UserIndex", bvm);
            }
        }
        [HttpPost]
        public IActionResult DeleteReservation([FromForm(Name = "reservationId")] int ReservationId)
        {
            _service.DeleteReservation(ReservationId);
            return RedirectToAction("Index", "Reservation");
        }
    }
}
