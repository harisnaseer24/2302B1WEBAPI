using _2302b1testAPI.Data;
using _2302b1testAPI.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2302b1testAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly _2302b1apiContext db;
        public TestController(_2302b1apiContext context)
        {
            db = context; 
            
        }

        [HttpGet("{num}")]
        public IActionResult GetData(int num) {
            int number = num;

            if (number < 10)
            {
                return BadRequest("number is not valid");
            }
            else
            {

                return Ok("valid number");
            }
        }

        [HttpGet]
        public IActionResult GetStudents() {

            return Ok(db.Students.ToList());

        }

        //[HttpPost]
        //public IActionResult AddStudent(Student std)
        //{
        //    if (std != null) {

        //      var newStd=  db.Students.Add(std);
        //        db.SaveChanges();
        //        return Ok(newStd.Entity);
        //    }
        //    else
        //    {
        //        return BadRequest("Student details needed");
        //    }

        //}

        [HttpPost]
        public IActionResult CreateStudent(StudentDTO std)
        {
            if (ModelState.IsValid)
            {
                //Object mapping
                Student a = new Student()
                {
                    Name=std.Name,
                    Address=std.Address,
                    Email=std.Email,
                    ContactNo=std.ContactNo
                };

                var newStd = db.Students.Add(a);
                db.SaveChanges();
                return Ok(newStd.Entity);

            }
            else
            {
                return BadRequest("Student details needed");
            }

        }


        [HttpDelete]
        public IActionResult RemoveStudent(int id)
        {
            if (id !=null)
            {

                var checkStd = db.Students.FirstOrDefault(o => o.Id == id);
                if(checkStd != null)
                {
                    var deletedStd = db.Students.Remove(checkStd);
                    db.SaveChanges();
                    return Ok(deletedStd.Entity.Name +" has been deleted successfully.");
                }
                else
                {
                    return NotFound("Student not found");
                }

            }
            else
            {
                return BadRequest("Student details needed");
            }

        }


    }
}
