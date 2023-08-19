using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyFastProject.Core.Student.Command;
using MyFastProject.Core.Student.Query;
using static MyFastProject.Core.Student.Command.CreateStudent;
using static MyFastProject.Core.Student.Command.DeleteStudent;
using static MyFastProject.Core.Student.Command.UpdateStudent;
using static MyFastProject.Core.Student.Query.GetStudentByIdQuery;


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
	/// <summary>
	/// Create Student
	/// </summary>
	/// <param name="qurey"></param>
	/// <returns></returns>
	[HttpPost]
	public async Task<ActionResult<Service.Models.ViewModel.Student>> Create([FromBody] Service.Models.ViewModel.Student qurey)
	{
		var result = await _mediator.Send(new CreateStudentCommand(qurey));
		return Ok(result);
	}
	/// <summary>
	/// Get Student By Id
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	[HttpGet("{id}")]
	public async Task<ActionResult<Service.Models.ViewModel.Student>> GetStudentById(int id)
	{
		var result= await _mediator.Send(new GetStudentQueryById(id));
		return Ok(result);
	}
	/// <summary>
	/// Update Student
	/// </summary>
	/// <param name="commandstudent"></param>
	/// <param name="id"></param>
	/// <returns></returns>
	[HttpPut("{id:int}")]
	public async Task<ActionResult<Service.Models.ViewModel.Student>> UpdateStudent([FromBody]Service.Models.ViewModel.Student commandstudent,int id)
	{
		var result= await _mediator.Send(new UpdateStudentCommand(id,commandstudent));
		return Ok(result);
	}
	/// <summary>
	/// Delete Student
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	[HttpDelete("{id:int}")]
	public async Task<ActionResult<Service.Models.ViewModel.Student>>DeleteStudent(int id)
	{
	  await _mediator.Send(new DeleteStudentCommand(id));
		return Ok(new { Message = "Delete Successfully" });
	}
	[HttpGet]
	public async Task<ActionResult<Service.Models.ViewModel.Student>> GetAllStudent()
	{
		var data= await _mediator.Send(new GetAllStudent.GetAllStudentQuery());
		return Ok(data);

	}
}
