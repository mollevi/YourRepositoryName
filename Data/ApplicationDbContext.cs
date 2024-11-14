using Microsoft.EntityFrameworkCore;
using ZeneApp.Models;

namespace ZeneApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) {}

        public required DbSet<Zene> Zenek {get; set; }

    }
}