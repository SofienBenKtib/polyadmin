using BackofficePfa.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackofficePfa.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
    }
}
