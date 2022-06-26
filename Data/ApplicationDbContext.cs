using Microsoft.EntityFrameworkCore;
using SmallOnlineLibrary.Models;

namespace SmallOnlineLibrary.Data {
  public class ApplicationDbContext: DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {

    }

    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
  }
}