using AutoMapper;
using MediatR;
using MyFastProject.Repositories.Interfaces;

namespace MyFastProject.Core.Student.Command;

public class UpdateStudent
{
	public record UpdateStudentCommand(int id, Service.Models.ViewModel.Student student):IRequest<Service.Models.ViewModel.Student>;

	public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Service.Models.ViewModel.Student>
	{
		/// <summary>The student repository</summary>
		private readonly IStudentRepository _studentRepository;
		private readonly IMapper _mapper;

		public UpdateStudentCommandHandler(IMapper mapper ,IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
			_mapper = mapper;
		}
		/// <param name="request">The request</param>
		/// <param name="cancellationToken">Cancellation token</param>
		/// <returns>Response from the request</returns>
		public async Task<Service.Models.ViewModel.Student> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
		{
			var rusult =  _mapper.Map<Model.Entites.Student>(request.student);
			rusult.LastModified = DateTimeOffset.Now;
			rusult.LastModifiedBy = "Raj";
			rusult.Id = request.id;
			return await _studentRepository.Update(request.id,rusult);
		}
	}

}
