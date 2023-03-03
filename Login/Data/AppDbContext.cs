using Login.Entities;
using Microsoft.EntityFrameworkCore;

namespace Login.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<SignUp> SignUpSet { get; set; }
}