using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Domain.Entities;
using static System.Net.WebRequestMethods;

namespace WhiteLagoon.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }

        public DbSet<Villa> Villas { get; set; } //krijon tabelen te db
        public DbSet<VillaNumber> VillaNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Villa>().HasData(
              new Villa
              {
                  Id = 1,
                  Name = "Royal Villa",
                  Description = "Description",
                  ImageUrl = "https://placehold.co/600x480",
                  Occupancy = 4,
                  Price = 200,
                  Sqft = 559,
              },
              new Villa
              {
                  Id = 2,
                  Name = "Premium Pool Villa",
                  Description = "Description",
                  ImageUrl = "https://placehold.co/600x481",
                  Occupancy = 4,
                  Price = 308,
                  Sqft = 5598,
              },
              new Villa
              {
                  Id = 3,
                  Name = "Luxury Pool Villa",
                  Description = "Description",
                  ImageUrl = "https://placehold.co/600x492",
                  Occupancy = 4,
                  Price = 408,
                  Sqft = 7598
              });

            modelBuilder.Entity<VillaNumber>().HasData(
                new VillaNumber
                {
                    Villa_Number = 101,
                    VillaId = 1,
                },
                new VillaNumber
                {
                    Villa_Number = 102,
                    VillaId = 1,
                },
                new VillaNumber
                {
                    Villa_Number = 103,
                    VillaId = 1,
                },
                new VillaNumber
                {
                    Villa_Number = 104,
                    VillaId = 1,
                },
                new VillaNumber
                {
                    Villa_Number = 201,
                    VillaId = 2,
                },
                new VillaNumber
                {
                    Villa_Number = 202,
                    VillaId = 2,
                },
                new VillaNumber
                {
                    Villa_Number = 203,
                    VillaId = 2,
                },
                new VillaNumber
                {
                    Villa_Number = 301,
                    VillaId = 3,
                },
                new VillaNumber
                {
                    Villa_Number = 302,
                    VillaId = 3,
                });
        }
    }
}
