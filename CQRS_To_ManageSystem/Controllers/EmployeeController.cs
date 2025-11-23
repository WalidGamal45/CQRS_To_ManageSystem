using CQRS_Layer1.CQRS.Commands;
using CQRS_Layer1.CQRS.Handelers;
using CQRS_Layer1.CQRS.Queries;
using CQRS_Layer1.Dmains;
using CQRS_Layer1.Rebos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_To_ManageSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;
        private readonly IMediator _mediator;

        public EmployeeController(IEmployee employee, IMediator mediator)
        {
            _employee = employee;
            _mediator = mediator;
        }
        // Mediator With CQRS APIs 

        [HttpGet]
        public async Task <IActionResult> GetAllEmps()
        {
            var emps = await _mediator.Send(new GetAllEmpsQuery());
            return Ok(emps);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmp(int id)
        {
            var emp = await _mediator.Send(new GetEmpQuery(id));
            if (emp == null) 
                return NotFound();
            return Ok(emp);
        }
        [HttpPost]
        public async Task<IActionResult> InsertEmp(Employee employee)
        {
           var emp = await _mediator.Send(new InsertEmpCommand(employee));
            return Ok(emp);
        }
        [HttpPut]
        public async Task<IActionResult> EditEmp(int id , Employee employee)
        {
            var oldemp = await _mediator.Send(new EditEmpCommand(id, employee));
            if(oldemp == null)
                return NotFound();
            return Ok(oldemp);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmp(int id)
        {
            var emp = await _mediator.Send(new  DeleteEmpCommand(id));
            if(emp == null)
                return NotFound();
            return Ok(emp);
        }

       


        // RESTfull APIs Normal
        //[HttpGet]
        //public IActionResult GetAllEmps()
        //{
        //    var emps=_employee.GetEmployees();
        //    return Ok(emps);
        //}
        //[HttpGet("{id}")]
        //public IActionResult GetEmpById(int id)
        //{
        //    var emp = _employee.GetEmployeeById(id);
        //    if (emp == null)
        //        return NotFound();
        //    return Ok(emp);

        //}
        //[HttpPost]
        //public IActionResult AddEmp(Employee employ)
        //{
        //    _employee.AddEmployee(employ);

        //    return CreatedAtAction("GetEmpById", new {id=employ.Id},employ);
        //}
        //[HttpPut]
        //public IActionResult UpdateEmp(int id,Employee employ1)
        //{
        //    var emp = _employee.EditEmployee(id, employ1);
        //    if (emp == null)
        //        return NotFound();
        //    return Ok(emp);
        //} 
        //[HttpDelete]
        //public IActionResult DeleteEmp(int id)
        //{
        //    var emp = _employee.GetEmployeeById(id);
        //    if(emp == null)
        //        return NotFound();
        //    _employee.DeleteEmployee(id);
        //    return Ok("is deleted");
        //}
    }
}
