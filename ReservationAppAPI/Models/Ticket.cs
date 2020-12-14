using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using ReservationAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ReservationAppAPI.Models
{
    public class Ticket
    {
        [Required]
        public long TicketId { get; set; }
        [Required]
        public string Message { get; set; }

        [Required]
        public Customer Customer { get; set; }
        public Reservation Reservation { get; set; }


    }
}