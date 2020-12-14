﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ReservationAppAPI.Context;

namespace ReservationAppAPI.Migrations
{
    [DbContext(typeof(ReservationContext))]
    partial class ReservationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ReservationAppAPI.Models.Flight", b =>
                {
                    b.Property<long>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Airline")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AirportName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("MaxFreeWeight")
                        .HasColumnType("double precision");

                    b.HasKey("FlightId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("ReservationAppAPI.Models.Person", b =>
                {
                    b.Property<long>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PESEL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PersonId");

                    b.ToTable("People");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("ReservationAppAPI.Models.Reservation", b =>
                {
                    b.Property<long>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<long?>("CustomerPersonId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date_Of_Reservation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("FlightId")
                        .HasColumnType("bigint");

                    b.HasKey("ReservationId");

                    b.HasIndex("CustomerPersonId");

                    b.HasIndex("FlightId");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("ReservationAppAPI.Models.Ticket", b =>
                {
                    b.Property<long>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<long>("CustomerPersonId")
                        .HasColumnType("bigint");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("ReservationId")
                        .HasColumnType("bigint");

                    b.HasKey("TicketId");

                    b.HasIndex("CustomerPersonId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("ReservationAppAPI.Models.Customer", b =>
                {
                    b.HasBaseType("ReservationAppAPI.Models.Person");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Balance")
                        .HasColumnType("double precision");

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("ReservationAppAPI.Models.Reservation", b =>
                {
                    b.HasOne("ReservationAppAPI.Models.Customer", null)
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerPersonId");

                    b.HasOne("ReservationAppAPI.Models.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId");

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("ReservationAppAPI.Models.Ticket", b =>
                {
                    b.HasOne("ReservationAppAPI.Models.Customer", "Customer")
                        .WithMany("Ticekts")
                        .HasForeignKey("CustomerPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReservationAppAPI.Models.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId");

                    b.Navigation("Customer");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("ReservationAppAPI.Models.Customer", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Ticekts");
                });
#pragma warning restore 612, 618
        }
    }
}
