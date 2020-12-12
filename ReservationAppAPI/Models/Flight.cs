using System.ComponentModel.DataAnnotations;
using System;
using ReservationAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ReservationAppAPI.Models
{
    public class Flight
    {
        [Required]
        public long FlightId { get; set; }
        [Required]
        public string Airline { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }
        [Required]
        public string AirportName { get; set; }
        [Required]
        public double MaxFreeWeight { get; set; }
    }
}