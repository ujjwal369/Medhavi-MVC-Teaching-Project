using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Medhavi_MVC.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions):
            base(dbContextOptions) { }
        
        public DbSet<Hello> Hello { get; set; }
        public DbSet<Friend> Friend { get; set; }
    }
}
