using System.ComponentModel.DataAnnotations;
using System;
using ReservationAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ReservationAppAPI.Models
{
    [Owned]
    public class User
    {

        [Required]
        public long UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string PESEL { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}