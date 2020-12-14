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
    public class FlightsController : ControllerBase
    {

        private readonly ILogger<ReservationContext> _logger;
        private readonly ReservationContext _reservationContext;

        public FlightsController(ILogger<ReservationContext> logger, ReservationContext reservationContext)
        {
            _logger = logger;
            _reservationContext = reservationContext;
        }

        [HttpGet]
        public IEnumerable<Flight> Get()
        {
            return _reservationContext.GetFlights();
        }
        [HttpGet("{id}")]
        public Flight Get(long id)
        {
            return _reservationContext.GetFlight(id);
        }
        [HttpDelete("{id}")]
        public bool DeleteCustomer(long id)
        {
            return _reservationContext.DeleteFlight(id);
        }

        [HttpPost]
        public Flight addCustomer(Flight flight)
        {
            return _reservationContext.addFlight(flight);
        }


    }
}
