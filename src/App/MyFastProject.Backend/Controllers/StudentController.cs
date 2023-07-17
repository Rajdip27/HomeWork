using MediatR;
using Microsoft.AspNetCore.Mvc;
using static MyFastProject.Core.Student.Command.CreateStudent;

namespace MyFastProject.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
	private readonly IMediator _mediator;
	public StudentController(IMediator mediator)
	{
		_mediator = mediator;
	}
	[HttpPost("Create")]
	public async Task<ActionResult<Service.Models.ViewModel.Student>> Create([FromBody] Service.Models.ViewModel.Student qurey)
	{
		var result = await _mediator.Send(new CreateStudentCommand(qurey));
		return Ok(result);
	}
}
