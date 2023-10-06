using Microsoft.EntityFrameworkCore;
using WebAPILnkdn.Model;

namespace WebAPILnkdn.Data
{
    public class APIDbContext:DbContext 
    {
        public APIDbContext( DbContextOptions<APIDbContext> options): base(options)
        {

        }

        public DbSet<Person> people { get; set; }

        public DbSet<Position> positions { get; set; }

        public DbSet<Salary> salaries { get; set; }

        public DbSet<PersonDetail> personDetails { get; set; }

        public DbSet<Department> departments { get; set; }
    }
}
