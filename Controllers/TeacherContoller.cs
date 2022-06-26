using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SmallOnlineLibrary.Data;
using SmallOnlineLibrary.Models;

namespace SmallOnlineLibrary.Controllers {
  public class TeacherController: Controller {
    private readonly ApplicationDbContext context;
    public TeacherController(ApplicationDbContext context){
      this.context = context;
    }
    public async Task<IActionResult> Index(){
      // select * from Teachers;
      var teachers = await this.context.Teachers.ToListAsync();

      List<Teacher> listOfTeachers = new List<Teacher>();

      foreach(Teacher teacher in teachers){
        listOfTeachers.Add(new Teacher {
          Id = teacher.Id,
          Name = teacher.Name
        });
      }

      return Json(new {
        status = 200, // request success
        data = listOfTeachers
      });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Teacher teacher){ // String Name

      await this.context.Teachers.AddAsync(teacher);
      await this.context.SaveChangesAsync();

      return Json(new {
        status = 200, // create success
        data = teacher // return data back to frontend
      });
    }

    public async Task<IActionResult> Detail(int id){
      var teacher = await this.context.Teachers.FirstOrDefaultAsync(teacher => teacher.Id == id);

      if(teacher == null){
        return Json(new {
          status = 404, //not found
          message = "Data not found"
        });
      }

      return Json(new {
        status = 200,
        data = new {
          id = teacher.Id,
          name = teacher.Name
        }
      });
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] Teacher teacher){
      this.context.Update(teacher);
      await this.context.SaveChangesAsync();

      return Json(new {
        status = 200,
        data = new {
          id = teacher.Id,
          name = teacher.Name
        }
      });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id){
      var teacher = await this.context.Teachers.FirstOrDefaultAsync(teacher => teacher.Id == id);

      Console.WriteLine(id);

      if(teacher == null){
        return Json(new {
          status = 404, //not found
          message = "Data not found"
        });
      }

      this.context.Teachers.Remove(teacher);
      await this.context.SaveChangesAsync();

      return Json(new {
        status = 200
      });
    }
  }
}