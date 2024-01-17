using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;

namespace Medhavi_MVC.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }




        public DbSet<Hello> Hello { get; set; }
        public DbSet<Friend> Friend { get; set; }
    }
}
