using FindJobWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FindJobWebApi.DataBase
{
    public class AppDBContext : DbContext
    {
        public DbSet<Candidtate> Candidtates { get; set; }
        public DbSet<Firm> Firms { get; set; }
        public DbSet<FirmAddress> FirmAddresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
    }
}
