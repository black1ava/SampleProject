
namespace SmallOnlineLibrary.Models {
  public class Category {
    public int Id { get; set; }
    public String Name { get; set; } = String.Empty;
    public List<Book> Books { get; set; }
  }
}