using CQRS.Command;
using CQRS.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1_ITI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department department)
        {
            if (department == null)
                return BadRequest("Empty Item");
            var reuslt = await _mediator.Send(new AddDepartmentCommand()
            {
                Department = department
            });

            return Ok(reuslt);
        }
    }
}
