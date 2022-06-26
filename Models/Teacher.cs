namespace SmallOnlineLibrary.Models {
  public class Teacher {
    public int Id { get; set; }
    public String Name { get; set; } = String.Empty;
    public List<Book> Books { get; set; }
  }
}