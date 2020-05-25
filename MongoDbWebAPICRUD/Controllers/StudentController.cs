using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Linq;
using MongoDbModel;
using MongoDbModel.Model;
using MongoDbWebAPICRUD.Business;

namespace MongoDbWebAPICRUD.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();
        }

        [Route("GetServerName")]
        [HttpGet]
        public ActionResult GetServerName()
        {
            var serverDT = System.Environment.MachineName + "_" + System.DateTime.Now;
            return Ok(serverDT);
        }      

        [HttpGet]
        [Route("GetStudentById/{id}")]
        public IActionResult GetStudentById(string id)
        {
            var student = _studentService.Get(id);
             return Ok(student);
        }
     
        [Route("GetAllStudents")]
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var student = _studentService.All;
            return Ok(student);
        }
        [HttpPost]
        [Route("InsertStudent")]
        public void  InsertStudent(Student student)
        {
            _studentService.Insert(student);
           
        }

        [HttpPost]
        [Route("InsertManyStudent")]
        public void InsertManyStudent(List<Student> student)
        {
            _studentService.Insert(student);

        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public void DeleteStudent(string id)
        {
            _studentService.Delete(id);
        }
        [HttpPut]
        [Route("UpdateStudent")]
        public void UpdateStudent(Student student)
        {
            _studentService.Update(student);
        }
    }
}
