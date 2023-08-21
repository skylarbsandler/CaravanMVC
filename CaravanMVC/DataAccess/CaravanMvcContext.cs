using Microsoft.EntityFrameworkCore;
using CaravanMVC.Models;
using System.Reflection.Emit;

namespace CaravanMVC.DataAccess
{
    public class CaravanMvcContext : DbContext
    {
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Wagon> Wagons { get; set; }

        public CaravanMvcContext(DbContextOptions<CaravanMvcContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wagon>().HasData(
               new Wagon { Id = 1, Name = "Old Faithful", NumWheels = 4, Covered = false},
               new Wagon { Id = 2, Name = "Prairie Pioneer", NumWheels = 6, Covered = true },
               new Wagon { Id = 3, Name = "Westward Wanderer", NumWheels = 8, Covered = true }
           );

            modelBuilder.Entity<Passenger>().HasData(
                new Passenger { Id = 1, Name = "Skylar", Age = 26, Destination = "Denver", WagonId = 1 },
                new Passenger { Id = 2, Name = "Scott", Age = 34, Destination = "Denver", WagonId = 1 },
                new Passenger { Id = 3, Name = "Kaila", Age = 18, Destination = "San Francisco", WagonId = 2 },
                new Passenger { Id = 4, Name = "Gabe", Age = 45, Destination = "San Francisco", WagonId = 2 },
                new Passenger { Id = 5, Name = "Meghan", Age = 60, Destination = "Portland", WagonId = 3 },
                new Passenger { Id = 6, Name = "Griffin", Age = 39, Destination = "Portland", WagonId = 3 }
            );
        }
    }
}
