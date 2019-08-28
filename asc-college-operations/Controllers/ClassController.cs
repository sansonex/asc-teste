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
    public class ClassController : ControllerBase
    {
        private IClassService classService;

        public ClassController(IClassService classService)
        {
            this.classService = classService;
        }
        [HttpGet]
        public ActionResult<ICollection<Class>> Get()
        {
            return this.Ok(classService.GetAllClasses());
        }

        [HttpPost]
        public ActionResult Create([FromBody] Class request)
        {
            this.classService.CreateClass(request);
            return this.Accepted();
        }

        [HttpPost("{id:int}/students")]
        public ActionResult AddStudent([FromRoute] int classId, [FromBody] Student request)
        {
            this.classService.AddStudent(classId, request);
            return this.Accepted();
        }

        [HttpPost("{classId:int}/students/{studentId:int}/exams")]
        public ActionResult AddStudent([FromRoute] int classId, [FromRoute]int studentId, [FromBody] Exam request)
        {
            this.classService.AddExam(classId, studentId, request);
            return this.Accepted();
        }
    }
}