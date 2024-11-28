
using FinalG5.Models;
using Microsoft.EntityFrameworkCore;


namespace FinalG5.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
    }
}
