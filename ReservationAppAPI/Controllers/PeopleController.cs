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
    public class PeopleController : ControllerBase
    {

        private readonly ILogger<ReservationContext> _logger;
        private readonly ReservationContext _reservationContext;

        public PeopleController(ILogger<ReservationContext> logger, ReservationContext reservationContext)
        {
            _logger = logger;
            _reservationContext = reservationContext;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _reservationContext.GetPeople();
        }
    }
}
