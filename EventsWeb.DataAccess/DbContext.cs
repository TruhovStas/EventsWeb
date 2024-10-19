using EventsWeb.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using EventsWeb.Domain.Entities;

namespace EventsWeb.DataAccess
{
    public class DbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options) { }
        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
