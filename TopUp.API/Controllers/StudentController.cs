
using Microsoft.AspNetCore.Mvc;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Features.Students.Commands;
using TopUp.Application.Features.Students.Queries;
using TopUp.Domain.Entities;

namespace TopUp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> GetAll()
        {
            try
            {
                return await _mediator.Send(new GetStudentsQuery());
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                return Enumerable.Empty<Student>();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { StudentId = id });
        }
    }
}
