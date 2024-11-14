using Microsoft.EntityFrameworkCore;
using ZeneApp.Models;

namespace ZeneApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) {}

        public DbSet<Music> MusicLibrary { get; set; }
    }
}