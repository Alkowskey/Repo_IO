using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;

using ReservationAppAPI.Models;
using System;

namespace ReservationAppAPI.Context
{
    public class ReservationContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public ReservationContext(DbContextOptions<ReservationContext> options) : base(options)
        {

        }

        public DbSet<Person> GetPeople() => People;
        public Person addPerson(Person person) {
            People.Add(person);
            this.SaveChanges();

            return person;
        }

        public Person GetPerson(long id)
        {
            return People.FirstOrDefault(p => p.PersonId == id);
        }

        public bool DeletePerson(long id)
        {
            Person p = GetPerson(id);
            try { 
                People.Remove(p);
            }
            catch(NullReferenceException e) {
                throw e;

            }

            this.SaveChanges();

            return true;
        }
    }
}