using Microsoft.EntityFrameworkCore;
using _231895urmenitaMVCCRUDOPERATION.Models;

namespace _231895urmenitaMVCCRUDOPERATION.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<_231895urmenitaSTUDENT> Students { get; set; }
        public DbSet<_231895urmenitaCOURSE> Courses { get; set; }
        public DbSet<_231895urmenitaUSER> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<_231895urmenitaSTUDENT>().ToTable("231895urmenitaSTUDENT");
            modelBuilder.Entity<_231895urmenitaCOURSE>().ToTable("231895urmenitaCOURSE");
            modelBuilder.Entity<_231895urmenitaUSER>().ToTable("231895urmenitaUSER");
        }
    }
}
