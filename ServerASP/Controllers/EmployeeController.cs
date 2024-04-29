using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServerASP.Models;
using ServerASP.Models.DTO.Outgoing;
using ServerASP.Services.Interfaces;

namespace ServerASP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private IEmployeeService employeeService;
        private IMapper mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            this.employeeService = employeeService;
            this.mapper = mapper;
        }

        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees()
        {
            return Ok(employeeService.GetAllEmployee());
        }

        [HttpGet("GetEmployee")]
        public IActionResult GetEmployee([FromQuery]EmployeeGetDTO employee)
        {
            try
            {
                var currentEmployer = mapper.Map<Employer>(employee);
                currentEmployer = employeeService.GetEmployee(currentEmployer);
                return Ok(currentEmployer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpPost("PostEmployee")]
        public IActionResult PostEmployee(Employer employee)
        {
            try
            {
                employeeService.AddEmployee(employee);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return BadRequest();
            }
        }

        [HttpPut("PutEmployee")]
        public IActionResult PutEmployee(Employer employee)
        {
            try
            {
                employeeService.UpdateEmployee(employee);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpDelete("DeleteEmployee")]
        public IActionResult DeleteEmployee(EmployeeGetDTO employeeGet)
        {
            try
            {
                Employer currentEmployer = mapper.Map<Employer>(employeeGet);

                currentEmployer = employeeService.GetEmployee(currentEmployer);

                employeeService.DeleteEmployee(currentEmployer);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }
    }
}
