using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using ReservationAppAPI.Context;

using ReservationAppAPI.Models;

namespace ReservationAppAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationsController : ControllerBase
    {

        private readonly ILogger<ReservationContext> _logger;
        private readonly ReservationContext _reservationContext;

        public ReservationsController(ILogger<ReservationContext> logger, ReservationContext reservationContext)
        {
            _logger = logger;
            _reservationContext = reservationContext;
        }

        [HttpGet]
        public IEnumerable<Reservation> Get()
        {
            return _reservationContext.GetReservations();
        }
        [HttpGet("{id}")]
        public Reservation Get(long id)
        {
            return _reservationContext.GetReservation(id);
        }
        [HttpDelete("{id}")]
        public bool DeleteReservation(long id)
        {
            return _reservationContext.DeleteReservation(id);
        }

        [HttpPost]
        public Reservation addReservation(Reservation reservation)
        {
            return _reservationContext.addReservation(reservation);
        }


    }
}
