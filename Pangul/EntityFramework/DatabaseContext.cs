using Microsoft.EntityFrameworkCore;
using Pangul.Entities;

namespace Pangul.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Url> Urls { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
