using Microsoft.EntityFrameworkCore;
using SampleCRUDusingDotNetAndCSharp2.Models.Entities;

namespace SampleCRUDusingDotNetAndCSharp2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
