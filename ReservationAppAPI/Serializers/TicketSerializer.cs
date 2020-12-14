using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using ReservationAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ReservationAppAPI.Serializers
{
    public class TicketSerializer
    {
        [Required]
        public long TicketId { get; set; }
        [Required]
        public string Message { get; set; }

        [Required]
        public long CId { get; set; }
        public long RId { get; set; }


    }
}