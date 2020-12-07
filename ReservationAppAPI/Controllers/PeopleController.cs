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
        [HttpGet("{id}")]
        public Person Get(long id)
        {
            return _reservationContext.GetPerson(id);
        }
        [HttpDelete("{id}")]
        public bool DeletePerson(long id)
        {
            return _reservationContext.DeletePerson(id);
        }

        [HttpPost]
        public Person addUser(Person person)
        {
            return _reservationContext.addPerson(person);
        }

        /*[HttpPost("toRoom")]
        public User addUserToRoom([FromBody] UserToRoom userToRoom)
        {
            User user = userToRoom.User;
            Room room = userToRoom.Room;
            return _dbContext.addUserToRoom(user, room);
        }*/

    }
}
