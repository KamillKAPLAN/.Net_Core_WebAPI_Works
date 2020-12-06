using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelFinder.DataAccess
{
    public class HotelDbContext : DbContext
    {
        /*
         * Microsoft.EntityFrameworkCore.SqlServer installed
         * Microsoft.EntityFrameworkCore.Tools     installed : migration kullanabilmek için projeye dahil ettik.
         */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=IMPORTANTPC\KAMILKAPLAN; Database=HotelDb;uid=sa;pwd=1");
        }

        public DbSet<Hotel> Hotels { get; set; }
    }
}