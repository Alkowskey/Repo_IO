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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Flight> Flights { get; set; }

        public ReservationContext(DbContextOptions<ReservationContext> options) : base(options)
        {

        }

        //People part
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
        //Flights
        internal IEnumerable<Flight> GetFlights()
        {
            return Flights;
        }
        internal Flight addFlight(Flight flight)
        {
            Flights.Add(flight);
            this.SaveChanges();
            return flight;
        }

        internal bool DeleteFlight(long id)
        {
            Flight f = Flights.FirstOrDefault(f => f.FlightId == id);
            try
            {
                Flights.Remove(f);
            }
            catch (NullReferenceException e)
            {
                throw e;

            }

            this.SaveChanges();

            return true;
        }

        internal Flight GetFlight(long id)
        {
            return Flights.FirstOrDefault(f => f.FlightId == id);
        }

        //Customers

        public IEnumerable<Person> GetCustomers()
        {
            return Customers;
        }

        public Person GetCustomer(long id)
        {
            return Customers.Include(c => c.Reservations).ThenInclude(r => r.Flight).FirstOrDefault(c => c.CustomerId == id);
        }

        public Customer addCustomer(Customer customer)
        {
            Customers.Add(customer);
            this.SaveChanges();
            return customer;
        }

        public bool DeleteCustomer(long id)
        {
            Customer c = Customers.FirstOrDefault(c =>c.CustomerId == id);
            try
            {
                Customers.Remove(c);
            }
            catch (NullReferenceException e)
            {
                throw e;

            }

            this.SaveChanges();

            return true;
        }
    }
}