using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.AspNetCore.Routing;
using HelpdeskTicketing.Services;
using HelpdeskTicketing.Models;

namespace HelpdeskTicketing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {


       
        private readonly DepartmentService _departmentService;

        
        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public ActionResult<List<Department>> Get() =>
            _departmentService.Get();


        [HttpGet("{Id}", Name = "GetDepartment")]
        public ActionResult<Department> Get(string id)
        {
            var department = _departmentService.Get(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        [HttpPost]
        public ActionResult<Department> Create(Department department)
        {
            _messageService.Create(department);

            return CreatedAtRoute("GetDepartment", new { id = department.Id.ToString() }, department);
        }

        [HttpPut("{Id}")]
        public IActionResult Update(string id, Department departmentIn)
        {
            var department = _departmentService.Get(id);

            if (department == null)
            {
                return NotFound();
            }

            _departmentService.Update(id, departmentIn);

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(string id)
        {
            var department = _departmentService.Get(id);

            if (department == null)
            {
                return NotFound();
            }

            _departmentService.Remove(department.Id);

            return NoContent();
        }
    }
}
