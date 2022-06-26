using System.ComponentModel.DataAnnotations.Schema;

namespace SmallOnlineLibrary.Models {
  public class Book {
    public int Id { get; set; }
    public String Name { get; set; } = String.Empty;
    [ForeignKey("Teacher")]
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public List<Category> Categories { get; set; }
  }
}