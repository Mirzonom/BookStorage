using BookStorage.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStorage.Data;

public class ApiDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    {
    }
}