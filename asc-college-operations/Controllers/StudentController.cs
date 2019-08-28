using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asc_college_operations.Abstractions.Services;
using asc_college_operations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace asc_college_operations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public ActionResult<ICollection<Student>> Get()
        {
            return this.Ok(this.studentService.GetAllStudents());
        }

        [HttpPost]
        public ActionResult Create([FromBody] Student request)
        {
            this.studentService.CreateStudent(request);
            return this.Accepted();
        }
    }
}