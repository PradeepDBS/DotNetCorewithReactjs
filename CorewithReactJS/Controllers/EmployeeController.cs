using CorewithReactJS.Models;
using CorewithReactJS.WorkerService.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorewithReactJS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }
        [HttpGet]
        public IActionResult Get(int employeeid)
        {
            List<EmployeeModel> list = employeeService.GetEmployees(employeeid);
            return StatusCode(StatusCodes.Status200OK, list);

        }
        public IActionResult InsertUpdateEmployee(EmployeeModel model)
        {
            bool status = employeeService.InsertUpdateEmployees(model);
            return StatusCode(StatusCodes.Status200OK, status);

        }
        public IActionResult DeleteEmployee(int employeeid)
        {
            bool status= employeeService.DeleteEmployee();
            return StatusCode(StatusCodes.Status200OK, status);

        }



    }
}
