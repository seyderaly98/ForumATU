using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForumATU.Models.Data
{
    public class ForumContext : IdentityDbContext<User>
    {
        public  DbSet<User> Users { get; set; }
        
        public ForumContext(DbContextOptions<ForumContext> options) : base(options) {}
    }
}