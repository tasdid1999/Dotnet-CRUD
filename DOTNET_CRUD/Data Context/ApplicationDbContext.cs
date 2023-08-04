using Microsoft.EntityFrameworkCore;
using QuadTheoryTestProject.Models;

namespace QuadTheoryTestProject.Data_Access
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> students { get; set; }
        public DbSet<Class> classes { get; set; }

    }
}
