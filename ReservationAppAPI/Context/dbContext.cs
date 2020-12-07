using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;

using ReservationAppAPI.Models;



namespace ReservationAppAPI.Context
{
    public class ReservationContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public ReservationContext(DbContextOptions<ReservationContext> options) : base(options)
        {

        }

        public DbSet<Person> GetPeople() => People;
    }
}