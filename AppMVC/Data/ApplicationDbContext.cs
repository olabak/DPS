using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AppMVC.Models;

namespace AppMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AppMVC.Models.Patient>? Patient { get; set; }
        public DbSet<AppMVC.Models.ProjectRole>? ProjectRole { get; set; }
        public DbSet<AppMVC.Models.AppUser>? AppUser { get; set; }
    }
}