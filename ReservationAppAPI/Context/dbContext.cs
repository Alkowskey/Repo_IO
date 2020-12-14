using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;

using ReservationAppAPI.Models;
using ReservationAppAPI.Serializers;
using System;

namespace ReservationAppAPI.Context
{
    public class ReservationContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

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
        //Reservations
        internal IEnumerable<Reservation> GetReservations()
        {
            return Reservations.Include(r=>r.Flight);
        }

        internal Reservation GetReservation(long id)
        {
            return Reservations.Include(r => r.Flight).FirstOrDefault(r => r.ReservationId == id);
        }

        internal bool DeleteReservation(long id)
        {
            Reservation r = GetReservation(id);
            try
            {
                Reservations.Remove(r);
            }
            catch (NullReferenceException e)
            {
                throw e;

            }

            this.SaveChanges();

            return true;
        }

        internal Reservation addReservation(Reservation reservation)
        {
            throw new NotImplementedException();
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
        internal IEnumerable<Ticket> GetTickets() => Tickets;
        internal Ticket GetTicket(long id)
        {
            return Tickets.Include(t => t.Customer).FirstOrDefault(t => t.TicketId == id);
        }


        internal Ticket addTicket(TicketSerializer ticket)
        {
            Customer c = GetCustomer(ticket.CId);
            Reservation r = null; // Just for now
            Ticket t = new Ticket(ticket, c, r);
            Tickets.Add(t);
            this.SaveChanges();
            return t;
        }

        internal bool DeleteTicket(long id)
        {
            Ticket t = Tickets.FirstOrDefault(t => t.TicketId == id);
            try
            {
                Tickets.Remove(t);
            }
            catch (NullReferenceException e)
            {
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

        public IEnumerable<Customer> GetCustomers()
        {
            return Customers;
        }

        public Customer GetCustomer(long id)
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