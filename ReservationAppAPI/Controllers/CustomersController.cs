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
    public class CustomersController : ControllerBase
    {

        private readonly ILogger<ReservationContext> _logger;
        private readonly ReservationContext _reservationContext;

        public CustomersController(ILogger<ReservationContext> logger, ReservationContext reservationContext)
        {
            _logger = logger;
            _reservationContext = reservationContext;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _reservationContext.GetCustomers();
        }
        [HttpGet("{id}")]
        public Customer Get(long id)
        {
            return _reservationContext.GetCustomer(id);
        }
        [HttpDelete("{id}")]
        public bool DeleteCustomer(long id)
        {
            return _reservationContext.DeleteCustomer(id);
        }

        [HttpPost]
        public Customer addCustomer(Customer customer)
        {
            return _reservationContext.addCustomer(customer);
        }


    }
}
