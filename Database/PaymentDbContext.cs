using Microsoft.EntityFrameworkCore;
using Profile;

namespace Database
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {

        }

        public DbSet<Request> Requests { get; set; }
        public DbSet<PayState> PayStates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

}
