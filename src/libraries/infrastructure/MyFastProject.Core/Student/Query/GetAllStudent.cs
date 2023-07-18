using AutoMapper;
using MediatR;
using MyFastProject.Repositories.Interfaces;

namespace MyFastProject.Core.Student.Query;

public class GetAllStudent
{
	public record GetAllStudentQuery():IRequest<IEnumerable<Service.Models.ViewModel.Student>>;
	public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQuery, IEnumerable<Service.Models.ViewModel.Student>>
	{
		private readonly IStudentRepository _studentRepository;
		public GetAllStudentQueryHandler(IStudentRepository studentRepository, IMapper mapper)
		{
			_studentRepository = studentRepository;
		}
		public async Task<IEnumerable<Service.Models.ViewModel.Student>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
		{
			var result = await _studentRepository.GetAll();
			return result;
		}
	}
}
