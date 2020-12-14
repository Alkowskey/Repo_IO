using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using ReservationAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ReservationAppAPI.Models
{
    //[Owned]
    public class Customer : Person
    {
        [Required]
        public long CustomerId { get; set; }
        [Required]
        public string Address { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Ticket> Ticekts { get; set; }
        public double Balance { get; set; }

    }
}