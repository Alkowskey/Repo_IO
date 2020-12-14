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
    public class TicketsController : ControllerBase
    {

        private readonly ILogger<ReservationContext> _logger;
        private readonly ReservationContext _reservationContext;

        public TicketsController(ILogger<ReservationContext> logger, ReservationContext reservationContext)
        {
            _logger = logger;
            _reservationContext = reservationContext;
        }

        [HttpGet]
        public IEnumerable<Ticket> Get()
        {
            return _reservationContext.GetTickets();
        }
        [HttpGet("{id}")]
        public Ticket Get(long id)
        {
            return _reservationContext.GetTicket(id);
        }
        [HttpDelete("{id}")]
        public bool DeleteTicket(long id)
        {
            return _reservationContext.DeleteTicket(id);
        }

        [HttpPost]
        public Ticket addCustomer(Ticket ticket)
        {
            return _reservationContext.addTicket(ticket);
        }


    }
}
