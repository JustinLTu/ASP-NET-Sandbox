using Microsoft.EntityFrameworkCore;
namespace ZonePostings.Models
{
    public class PostingContext : DbContext
    {
        public PostingContext(DbContextOptions<PostingContext> options)
            : base(options)
        {
        }

        public DbSet<Posting> Posting { get; set; }
    }
}
