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
        //Customers

        internal IEnumerable<Person> GetCustomers()
        {
            return Customers;
        }

        internal Person GetCustomer(long id)
        {
            return Customers.Include(c => c.Reservations).ThenInclude(r => r.Flight).FirstOrDefault(c => c.CustomerId == id);
        }

        internal Customer addCustomer(Customer customer)
        {
            Customers.Add(customer);
            this.SaveChanges();
            return customer;
        }

        internal bool DeleteCustomer(long id)
        {
            Customer temp = Customers.FirstOrDefault(C => C.CustomerId == id);
            if(temp!=null)
                Customers.Remove(temp);
            this.SaveChanges();
            throw new NotImplementedException();
        }
    }
}