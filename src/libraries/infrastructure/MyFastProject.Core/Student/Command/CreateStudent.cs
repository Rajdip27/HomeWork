using AutoMapper;
using MediatR;
using MyFastProject.Repositories.Interfaces;
using MyFastProject.Shared.Enums;

namespace MyFastProject.Core.Student.Command;

public class CreateStudent
{
	public record CreateStudentCommand(Service.Models.ViewModel.Student Student):IRequest<Service.Models.ViewModel.Student>;

	public class CreateStudentCommandHanlder : IRequestHandler<CreateStudentCommand, Service.Models.ViewModel.Student>
	{
		private readonly IStudentRepository _studentRepository;
		private readonly IMapper _mapper;

		public CreateStudentCommandHanlder(IMapper mapper,IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
			_mapper = mapper;
		}
		public async Task<Service.Models.ViewModel.Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
		{
			var result= _mapper.Map<Model.Entites.Student>(request.Student);


			result.Status = EntityStatus.Created;
			result.CreatedBy = "Raj";
				return await _studentRepository.Add(result);
		}
	}
}
