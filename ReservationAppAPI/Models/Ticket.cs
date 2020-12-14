using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using ReservationAppAPI.Models;
using Microsoft.EntityFrameworkCore;

using ReservationAppAPI.Serializers;

namespace ReservationAppAPI.Models
{
    public class Ticket
    {
        public Ticket() { }
        public Ticket(TicketSerializer ticketSerializer, Customer customer, Reservation reservation)
        {
            Message = ticketSerializer.Message;
            Customer = customer;
            Reservation = reservation;
        }
        [Required]
        public long TicketId { get; set; }
        [Required]
        public string Message { get; set; }

        [Required]
        public Customer Customer { get; set; }
        public Reservation Reservation { get; set; }


    }
}