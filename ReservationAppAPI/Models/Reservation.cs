﻿using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using ReservationAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ReservationAppAPI.Models
{
    public class Reservation
    {
        [Required]
        public long ReservationId { get; set; }
        public Flight Flight { get; set; }
        public DateTime Date_Of_Reservation { get; set; }

    }
}