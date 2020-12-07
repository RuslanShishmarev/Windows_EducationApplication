using Microsoft.EntityFrameworkCore;

namespace EducationApp.Model
{
    class ApplicationContext: DbContext
    {
        public DbSet<EducationObject> EducationObjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserEducationList> UserEducationLists { get; set; }

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=educationappdb;Trusted_Connection=True;");
        }
    }
}
