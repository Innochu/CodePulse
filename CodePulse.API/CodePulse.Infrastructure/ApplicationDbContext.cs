using CodePulse.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=INNOCHU;Database=BookLibrary;Trusted_Connection=true;TrustServerCertificate = true");
        }


        public DbSet<BookPost> BookPosts { get; set; }
        public DbSet<Category> Categories { get; set; } 
    }
}