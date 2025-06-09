using Microsoft.EntityFrameworkCore;

namespace apbd15_test2.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
}