using CodeScanner.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace WindowsFormsApp1
{
    public class ApplicationContextBuffer : DbContext
    {
        public DbSet<DatabaseTemplate> Buffer { get; set; }

        public ApplicationContextBuffer()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost\SQLEXPRESS;Database=buffer_db;Trusted_Connection=True;"
            );
        }
    }

    public class ApplicationContextArchive : DbContext
    {
        public DbSet<DatabaseTemplate> Archive { get; set; }

        public ApplicationContextArchive()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost\SQLEXPRESS;Database=archive_db;Trusted_Connection=True;"
            );
        }
    }
}
