using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(employeeService.GetAllEmployee());
        }
    }
}
