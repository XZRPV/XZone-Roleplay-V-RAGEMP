using Microsoft.EntityFrameworkCore;
using XZRPV.Models;

namespace XZRPV.Database
{
    public class DbConn : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<UserCharacter> UserCharacters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var server = "127.0.0.1";
            var port = "3306";
            var database = "xzrpv";
            var user = "xzrpv_user";
            var password = "123";

            optionsBuilder.UseMySql($"server={server};port={port};database={database};user={user};password={password};");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .Property(e => e.Money)
                .HasColumnType("decimal(10, 2)")
                .HasDefaultValue(0.00m);

            builder.Entity<User>()
                .Property(e => e.BankBalance)
                .HasColumnType("decimal(10, 2)")
                .HasDefaultValue(0.00m);
        }
    }
}
