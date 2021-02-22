using Cinematron.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cinematron.DAL
{
    public class CinematronDbContext : IdentityDbContext<User>
    {
        public CinematronDbContext(DbContextOptions<CinematronDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Show> Shows {get; set;}
        public DbSet<Movie> Movies {get; set;}
        public DbSet<Episode> Episodes {get; set;}
    }
}
