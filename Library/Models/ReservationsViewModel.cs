using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class ReservationsViewModel
    {
        public List<ReservationViewModel> Reservations = new List<ReservationViewModel>();
    }

    public class ReservationViewModel
    {
        public int ReservationId { get; set; }
        public string UserName { get; set; }
        public string BookTitle { get; set; }
        public string UserId { get; set; }
        public int BookId { get; set; }
    }
}
