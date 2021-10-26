using Microsoft.EntityFrameworkCore;
using mycrud.Models;


namespace mycrud.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
    }
}
