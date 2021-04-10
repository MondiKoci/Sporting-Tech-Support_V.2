using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GBCSporting2021_TheDevelopers.Models
{
    public class SportContext : DbContext
    {
        public SportContext(DbContextOptions<SportContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Jim",
                    LastName = "Doe",
                    Email = "jdoe@email.com",
                    Address = "1 Main street",
                    PostalCode = "1M1 2M2",
                    City = "Toronto",
                    Province = "ON",
                    CountryId = 1,
                    Phone = "123-123-1234"
                    
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "jane@email.com",
                    Address = "11 Main street",
                    PostalCode = "1M1 2M2",
                    City = "Toronto",
                    Province = "ON",
                    CountryId = 1,
                    Phone = "123-123-1234"
                },
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Marie",
                    LastName = "Moe",
                    Email = "marie@email.com",
                    Address = "111 Main street",
                    PostalCode = "1M1 2M2",
                    City = "Toronto",
                    Province = "ON",
                    CountryId = 1,
                    Phone = "123-123-1234"
                }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Code = "T1012",
                    Name = "Visual Studio Pro",
                    Price = 22.5,
                    ReleaseDate = new DateTime(2020, 04, 14)

                },
                new Product
                {
                    ProductId = 2,
                    Code = "T1013",
                    Name = "Photoshop",
                    Price = 42.5,
                    ReleaseDate = new DateTime(2020, 01, 14)

                },
                new Product
                {
                    ProductId = 3,
                    Code = "T1013",
                    Name = "Illustrator",
                    Price = 442.5,
                    ReleaseDate = new DateTime(2019, 01, 14)

                }
                );

            modelBuilder.Entity<Technician>().HasData(
                new Technician
                {
                    TechnicianId = 1,
                    FirstName = "James",
                    LastName = "Doe",
                    Email = "jamesdoe@mail.com",
                    Phone = "123-123-4444"
                },
                new Technician
                {
                    TechnicianId = 2,
                    FirstName = "Jannete",
                    LastName = "Doe",
                    Email = "jannete@mail.com",
                    Phone = "444-123-4444"
                }
                );

            modelBuilder.Entity<Incident>().HasData(
                new Incident
                {
                    IncidentId = 1,
                    Title = "Key Not Working",
                    CustomerId = 1,
                    ProductId = 1,
                    TechnicianId = 1,
                    Description = "The key fell of the keyboard",
                    DateOpened = new DateTime(2019, 01, 14)
                },
                new Incident
                {
                    IncidentId = 2,
                    Title = "Github Not Fun",
                    CustomerId = 2,
                    ProductId = 1,
                    TechnicianId = 1,
                    Description = "Git for Visual Studio is a pain",
                    DateOpened = new DateTime(2019, 01, 14),
                    DateClosed = new DateTime(2021, 01, 12)
                },
                new Incident
                {
                    IncidentId = 3,
                    Title = "Orphan Incident",
                    CustomerId = 2,
                    ProductId = 1,
                    Description = "This incident is an orphan",
                    DateOpened = new DateTime(2019, 01, 14),
                },
                new Incident
                {
                    IncidentId = 4,
                    Title = "Open Incident",
                    CustomerId = 2,
                    TechnicianId = 1,
                    ProductId = 1,
                    Description = "This incident is an open incident",
                    DateOpened = new DateTime(2019, 01, 14),
                }
                );
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 2, Name = "Canada" },
                new Country { CountryId = 4, Name = "Japan" },
                new Country { CountryId = 5, Name = "Albania" },
                new Country { CountryId = 1, Name = "Italy" }
                );
            modelBuilder.Entity<Registration>().HasData(
                new Registration
                {
                    RegistrationId = 1,
                    CustomerId = 1,
                    ProductId = 1
                },
                new Registration
                {
                    RegistrationId = 2,
                    CustomerId = 2,
                    ProductId = 1
                }
                );
        }
    }
}
