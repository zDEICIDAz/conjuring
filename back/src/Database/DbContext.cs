using conjuring.Models;
using Microsoft.EntityFrameworkCore;

namespace conjuring.Database;

public class ConjuringDbContext(DbContextOptions<ConjuringDbContext> options) : DbContext(options) {
    public DbSet<UserEntity> Users { get; set; }
}
