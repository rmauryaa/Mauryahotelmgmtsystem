using HotelMgmtsSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Models
{
    public class HotelBindasDbContext : IdentityDbContext<User>
    {
        public HotelBindasDbContext(DbContextOptions<HotelBindasDbContext> options) : base(options)
        {

        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payment { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
